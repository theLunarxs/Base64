using System.Text.Json;
using static Base64.Utility.Scanner.ClientConfig;
using static Base64.Utility.Scanner.Configurations;

namespace Base64.Utility.Scanner
{
    public class ScanEngine
    {
        private CancellationTokenSource _cts; // CancellationTokenSource for canceling the scan
        private readonly short _NumOfProcesses; // Number of parallel processes for scanning
        private ScanProgressInfo _progressInfo; // Scan progress information
        private CheckIPConfigurations _checkIPConfigurations; // Configuration settings for IP checking
        private ClientConfig _clientConfig; // Client configuration settings
        private bool toCheckSpeed; // Flag indicating whether to check IP speed
        private const string _ScanResultsPath = "/Results/"; // Path to store scan results
        private readonly string _folderToScan; // Folder path to scan
        private List<ResultItem> _scanResults; // List to store scan results

        public ScanEngine(string FolderPath, ClientConfiguration ClientConfigSettings, CheckIPConfigurations CheckIPSettings)
        {
            _folderToScan = FolderPath;
            _scanResults = new(); // Initialize the list of scan results
            _clientConfig = new(ClientConfigSettings); // Initialize the client configuration
            _checkIPConfigurations = CheckIPSettings; // Initialize the IP checking configurations
            toCheckSpeed = CheckIPSettings.toCheckSpeed; // Set the flag to check IP speed
            _NumOfProcesses = CheckIPSettings.numOfProccess;
        }

        public bool Start()
        {
            return Scanit(_folderToScan, ParallelScan); // Start the scan
        }

        private bool Scanit(string FolderPath, Func<List<string>, List<ResultItem>> Scanner)
        {
            try
            {
                // Iterate over each file in the specified folder.
                foreach (var filepath in Directory.GetFiles(FolderPath))
                {
                    // Open the file for reading using a StreamReader.
                    List<string> content = new HashSet<string>(File.ReadAllLines(filepath)).ToList(); // Read the file content into a list
                    if (content.Count > 0)
                    {
                        var result = Scanner(content); // Perform scanning on the content
                        _ = WriteListToJson(result); // Write the scan results to JSON
                    }
                }
                return true; // Scan completed successfully
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); // Handle and propagate any exceptions
            }
        }

        private List<ResultItem> ParallelScan(List<string> ipRange)
        {
            _cts = new CancellationTokenSource(); // Create a CancellationTokenSource for parallel tasks
            ParallelOptions po = new ParallelOptions()
            {
                CancellationToken = _cts.Token, // Set the cancellation token for parallel tasks
                MaxDegreeOfParallelism = _NumOfProcesses // Set the maximum number of parallel processes
            };

            ParallelLoopResult result;

            try
            {
                object locker = new(); // Object for locking thread-safe operations
                result = Parallel.ForEach(ipRange, po, (ip, state, index) =>
                {
                    lock (locker)
                    {
                        _progressInfo.curentWorkingThreads++; // Increment the count of currently working threads
                    }

                    // implement config checker here
                    _clientConfig.ConvertIP(ip); // Convert IP address in the client configuration
                    IPChecker checker = new(_clientConfig, _checkIPConfigurations); // Create an IPChecker instance

                    bool IPWorking = checker.CheckIPWorking(toCheckSpeed); // Check if the IP is working

                    lock (locker)
                    {
                        _progressInfo.curentWorkingThreads--; // Decrement the count of currently working threads
                        _progressInfo.lastCheckedIP = ip; // Update the last checked IP
                        _progressInfo.totalCheckedIPInCurIPRange++; // Increment the count of total checked IPs in the current IP range
                        _progressInfo.totalCheckedIP++; // Increment the count of total checked IPs
                    }

                    if (IPWorking)
                    {
                        _scanResults.Add(
                        new ResultItem()
                        {
                            Address = ip,
                            DownloadSpeed = checker.v2rayProcess.DownloadSpeed,
                            UploadSpeed = checker.v2rayProcess.UploadSpeed,
                            Ping = checker.v2rayProcess.Ping
                        }); // Add the scan result to the list of scan results
                    }

                    //Thread.Sleep(1);

                    //if (isOK)
                    //{
                    //    _progressInfo.scanResults.addIPResult(checker.downloadDuration, checker.uploadDuration, ip);
                    //}

                    //// monitoring exceptions rate
                    //monitorExceptions(checker);

                    //currentRangeDoneIPs.Add(ip);

                    // pause or stop?
                    if (_progressInfo.pauseRequested)
                    {
                        // pause and keep state of current scan
                        state.Break(); // Pause the scan
                    }
                    else if (_progressInfo.skipCurrentIPRange || _progressInfo.stopRequested)
                    {
                        // stop and go for next range
                        state.Stop(); // Stop the scan for the current IP range and move to the next range
                    }
                });

                return _scanResults; // Return the list of scan results
            }
            catch (OperationCanceledException ex)
            {
                throw new Exception(ex.Message); // Handle and propagate the cancellation exception
            }
            catch (Exception ex)
            {
                throw new Exception($"Unknown Error on Scan Engine: {ex.Message}"); // Handle and propagate any unknown exceptions
            }
            finally
            {
                _cts.Dispose(); // Dispose the CancellationTokenSource
            }
        }

        private static async Task<bool> WriteListToJson(List<ResultItem> resultList)
        {
            try
            {
                // Convert the list to JSON
                string json = JsonSerializer.Serialize(resultList);
                string filename = $"ScanResults{DateTime.Now.ToLocalTime}"; // Generate a unique filename based on the current timestamp
                                                                            // Write the JSON string to a file
                string fullPath = Path.Combine(_ScanResultsPath, filename); // Create the full path for the file
                await File.WriteAllTextAsync(fullPath, json); // Write the JSON to the file
                return true; // Writing to JSON completed successfully
            }
            catch (Exception ex)
            {
                throw new IOException(ex.Message); // Handle and propagate any exceptions during file writing
            }
        }
    }

}
