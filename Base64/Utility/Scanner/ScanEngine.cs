using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Base64.Utility.Scanner
{
    public class ScanEngine
    {
        public CFIPList ipListLoader;
        private string[] cfIPRangeList;
        private CancellationTokenSource cts;
        public List<ResultItem>? workingIPsFromPrevScan { get; set; }
        public string v2rayDiagnosingMessage { get; private set; }
        public bool isV2rayExecutionSuccess { get; private set; }

        public int concurrentProcess = 4;
        public float targetSpeed;
        public ClientConfig scanConfig;
        public int downloadTimeout = 2;
        private Stopwatch curRangeTimer;

        public ScanEngine()
        {
            resetProgressInfo();
            // load cf ip list
            loadCFIPList();
        }

        public bool Start(List<string> IPsToScan)
        {
            parallelScan(IPsToScan);
            return true;
        }
        // scan in all cloudflare ip range
        private void scanInCfIPRanges(int startIndex = 0)
        {
            bool isFirstIterate = true;
            for (int index = startIndex; index < cfIPRangeList.Length; index++)
            {
                string? cfRange = cfIPRangeList[index];

                // don't reset stats if we are resuming, only on first iterate
                if (!isFirstIterate || !progressInfo.resumeRequested)
                {
                    progressInfo.totalCheckedIPInCurIPRange = 0;
                    progressInfo.scanResults.totalFoundWorkingIPsCurrentRange = 0;
                    currentRangeDoneIPs.Clear();
                }

                isFirstIterate = false;

                if (isValidIPRange(cfRange))
                {
                    int origTotal;
                    List<string> rangeIPs = getCurrentRangeIPs(cfRange, out origTotal);
                    progressInfo.currentIPRange = cfRange;
                    progressInfo.currentIPRangeTotalIPs = origTotal;
                    LogControl.Write(String.Format("Start scanning {0} ip in {1}", rangeIPs.Count, cfRange));
                    logMessages.Add($"Starting range: {cfRange} ...");
                    curRangeTimer = Stopwatch.StartNew();

                    // scan
                    parallelScan(rangeIPs);

                    LogControl.Write(String.Format("End of scanning {0} {1} ip in {2} sec\n\n", cfRange, rangeIPs.Count, curRangeTimer.Elapsed.TotalSeconds));

                    progressInfo.currentIPRangesNumber++;

                    // skip current range?
                    if (progressInfo.skipCurrentIPRange == true)
                    {
                        LogControl.Write(String.Format("IP range skipped by user {0}", cfRange));
                        progressInfo.skipCurrentIPRange = false;
                    }
                }
            } // for

            progressInfo.currentIPRangesNumber--; // undo last extra +
        }

        private List<string> getCurrentRangeIPs(string cfRange, out int origTotal)
        {
            List<string> allIPs = IPAddressExtensions.getAllIPInRange(cfRange);

            origTotal = allIPs.Count;

            // if scan paused then exclude already done IPs
            allIPs = excludeDoneIPs(allIPs);

            if (isRandomScan)
            {
                Random rnd = new Random();
                allIPs = allIPs.OrderBy(x => rnd.Next()).ToList();
            }

            return allIPs;
        }

        // for paused scans
        private List<string> excludeDoneIPs(List<string> allIPs)
        {
            return allIPs.Except(currentRangeDoneIPs.ToList()).ToList();
        }

        public void setCFIPRangeList(string[] list)
        {
            this.cfIPRangeList = list;
        }

        private bool isValidIPRange(string cfIP)
        {
            return cfIP != "" && cfIP.Contains('/') && cfIP.Contains('.');
        }

        private ConcurrentBag<string> currentRangeDoneIPs = new ConcurrentBag<string>();

        private void parallelScan(List<string> ipRange)
        {
            cts = new CancellationTokenSource();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = cts.Token;
            po.MaxDegreeOfParallelism = concurrentProcess; //System.Environment.ProcessorCount;
            ParallelLoopResult result;

            try
            {
                object locker = new object();
                result = Parallel.ForEach(ipRange, po, (ip, state, index) =>
                {
                    lock (locker)
                    {
                        progressInfo.curentWorkingThreads++;
                    }
                    var checker = new CheckIPWorking(ip, targetSpeed, scanConfig, downloadTimeout, isDiagnosing);
                    bool isOK = checker.check();

                    lock (locker)
                    {
                        progressInfo.curentWorkingThreads--;
                        progressInfo.lastCheckedIP = ip;
                        progressInfo.totalCheckedIPInCurIPRange++;
                        progressInfo.totalCheckedIP++;
                    }

                    //Thread.Sleep(1);
                    LogControl.Write($"{ip.PadRight(15)} is {isOK.ToString().PadRight(5)} front in: {checker.frontingDuration:n0} ms, dl in: {checker.downloadDuration:n0} ms");

                    if (isOK)
                    {
                        progressInfo.scanResults.addIPResult(checker.downloadDuration, ip);
                    }

                    setDiagnoseMessage(checker);

                    // should we auto skip?
                    checkForAutoSkips();

                    // monitoring exceptions rate
                    monitorExceptions(checker);

                    currentRangeDoneIPs.Add(ip);

                    // pause or stop?
                    if (progressInfo.pauseRequested)
                    {
                        // pause and keep state of current scan
                        state.Break();
                    }
                    else if (progressInfo.skipCurrentIPRange || progressInfo.stopRequested)
                    {
                        // stop and go for next range
                        state.Stop();
                    }
                }
                );

            }
            catch (OperationCanceledException ex)
            {
                //logMessages.Add("Scan cancel requested.");
            }
            catch (Exception ex)
            {
                logMessages.Add($"Unknown Error on Scan Engine: {ex.Message}");
            }
            finally
            {
                cts.Dispose();
            }

        }

        private void setDiagnoseMessage(CheckIPWorking checker)
        {
            if (isDiagnosing)
            {
                this.isV2rayExecutionSuccess = checker.isV2rayExecutionSuccess;
                if (checker.isV2rayExecutionSuccess == false && checker.downloadException != "")
                {
                    this.v2rayDiagnosingMessage = checker.downloadException;
                }
            }
        }

        private void monitorExceptions(CheckIPWorking checker)
        {
            // monitoring exceptions rate
            if (checker.downloadException != "")
                progressInfo.downloadExceptions.addError(checker.downloadException);
            else
                progressInfo.downloadExceptions.addScuccess();

            if (checker.frontingException != "")
                progressInfo.frontingExceptions.addError(checker.frontingException);
            else
                progressInfo.frontingExceptions.addScuccess();
        }

        private void checkForAutoSkips()
        {

            // skip after 3 minute
            if (skipAfterAWhileEnabled)
            {
                if (curRangeTimer.Elapsed.TotalMinutes >= 3)
                {
                    if (!progressInfo.skipCurrentIPRange)
                        logMessages.Add($"Auto skipping {progressInfo.currentIPRange} after 3 minutes of scanning.");

                    skipCurrentIPRange();
                }
            }

            // skip after found 5 IPs
            if (skipAfterFoundIPsEnabled)
            {
                if (progressInfo.scanResults.totalFoundWorkingIPsCurrentRange >= 5)
                {
                    if (!progressInfo.skipCurrentIPRange)
                        logMessages.Add($"Auto skipping {progressInfo.currentIPRange} after found 5 working IPs.");

                    skipCurrentIPRange();
                }
            }

            // skip after percent done
            if (skipAfterPercentDone && skipMinPercent > 0)
            {
                if (progressInfo.getCurrentRangePercentIsDone() >= skipMinPercent)
                {
                    if (!progressInfo.skipCurrentIPRange)
                        logMessages.Add($"Auto skipping {progressInfo.currentIPRange} after {skipMinPercent}% of range is scanned.");

                    skipCurrentIPRange();
                }
            }
        }

        protected void resetProgressInfo()
        {
            progressInfo = new ScanProgressInfo();
        }

        public List<string> fetchLogMessages()
        {
            List<string> curLogMessages = logMessages;
            logMessages = new();
            return curLogMessages;
        }


        public bool loadCFIPList(string fileName = "cf.local.iplist")
        {
            CFIPList ipList = new CFIPList(fileName);
            if (ipList.isIPListValid())
            {
                cfIPRangeList = ipList.getIPList();
                ipListLoader = ipList;
                return true;
            }

            progressInfo.lastErrMessage = "Invalid cloudflare IP list";
            progressInfo.hasError = true;
            return false;
        }

        internal void stop()
        {
            try
            {
                if (progressInfo.isScanRunning)
                {
                    progressInfo.stopRequested = true;
                    //cts.Cancel();
                }
            }
            catch (Exception)
            { }
        }

        public void pause()
        {
            stop();
            if (progressInfo.isScanRunning)
            {
                progressInfo.pauseRequested = true;
            }
        }

        public void skipCurrentIPRange()
        {
            progressInfo.skipCurrentIPRange = true;
            //cts.Cancel();
        }

        internal void setSkipAfterFoundIPs(bool enabled)
        {
            this.skipAfterFoundIPsEnabled = enabled;
        }

        internal void setSkipAfterAWhile(bool enabled)
        {
            this.skipAfterAWhileEnabled = enabled;
        }

        internal void setSkipAfterScanPercent(bool enabled, int minPercent)
        {
            this.skipAfterPercentDone = enabled;
            this.skipMinPercent = minPercent;
        }

        // add just one item
        internal void setPrevResults(ResultItem resultItem)
        {
            var list = new List<ResultItem>();
            list.Add(resultItem);
            setPrevResults(list);
        }

        // add as list of items
        internal void setPrevResults(List<ResultItem> resultItems)
        {
            workingIPsFromPrevScan = resultItems;
        }
    }
}
