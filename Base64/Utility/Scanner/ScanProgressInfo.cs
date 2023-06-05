namespace Base64.Utility.Scanner
{
    public class ScanProgressInfo
    {
        public bool isScanRunning = false;
        public string currentIPRange = "";
        public string lastErrMessage = "";
        public bool hasError = false;
        public bool stopRequested = false; // is requested to stop scan
        public bool pauseRequested = false; // is requested to pause scan
        public bool resumeRequested = false;
        internal string lastCheckedIP;
        //internal ScanResults scanResults;
        internal bool skipCurrentIPRange;
        internal int totalIPRanges;
        internal int currentIPRangesNumber = 0;
        internal int currentIPRangeTotalIPs = 0;
        internal int totalCheckedIPInCurIPRange = 0;
        internal int totalCheckedIP = 0;
        //internal ExceptionMonitor downloadUploadExceptions = new("Download Upload Errors");
        //internal ExceptionMonitor frontingExceptions = new("Fronting Errors");
        internal int curentWorkingThreads = 0;
        //internal ScanStatus scanStatus = ScanStatus.STOPPED;
        internal int indexOfCLRange = 0;

        public float getCurrentRangePercentIsDone()
        {
            if (currentIPRangeTotalIPs == 0)
                return 0;

            return ((float)totalCheckedIPInCurIPRange / currentIPRangeTotalIPs) * 100;
        }
    }
}
