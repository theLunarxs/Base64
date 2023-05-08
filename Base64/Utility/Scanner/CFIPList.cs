using Microsoft.VisualBasic.Devices;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Windows.Forms.Design;

namespace Base64.Utility.Scanner
{
    public class CFIPList
    {
        // IPsDirectory, where the files containing IPs are at.
        public readonly string IPsDirectory;

        // this enum delcares where we have received our IPs from, whether it's from server (API) or LocalFile coming with program(Local)
        //      or it's received manually from user (Input).
        public readonly ListStatus IPListStatus;

        // this is the path where "Local" is at.
        private const string _cfpath = @"\services\cfIPlist.txt";

        // this is where the IPs files will be written at.
        private const string _defPath = @$"/IPRanges";

        private Dictionary<string, List<string>> _ipRanges;
        
        public enum ListStatus
        {
            Local,
            API,
            Input
        }

        // this CTOR manages the object initialization when the given file is RangesFile ** e.g contains "192.168.1.1/24"
        public CFIPList(string filePath, bool append, bool isIPsFile = false)
        {

            string[] cfList;

            if (!(Directory.Exists(filePath)) || !(Directory.GetFiles(filePath).Length > 1))
            {
                // if the given file has any problem (doesn't exist or the directory is wrong or else), we'll read the default file
                // (fallback)
                cfList = File.ReadAllLines(_cfpath);
                // and we set the status to local because we read the default file.
                IPListStatus = ListStatus.Local;
            }

            else
            {
                // if the given file is healthy and working, we store all of it's contents in cfList ( cloudflare List).
                cfList = File.ReadAllLines(filePath);
                // and we set our Object's ListStatus to Input because we've received our IPs from User.
                IPListStatus = ListStatus.Input;
            }

            if (isIPsFile && IPListStatus == ListStatus.Input)
            {
                // if the file contains IPs, we sort them by IPranges
                cfList.SortIPArrayByIPRange(out _ipRanges);

                _ = IPAddressExtension.WriteRangeToDisk(_ipRanges, append);
            }

            // in case the given file is Ranges File: ( in format of 192.168.1.1/24 for example)
            else
            {
                // we Generate all the IPs in the given ranges using this function. for more info, read the function
                List<List<string>> IPList = GenerateIP(cfList);

                foreach (var IP in IPList)
                {
                    // and now I write each range to a separate file because I want to reduce memory usage 
                    // when reading them.
                    // for example, if the result is 250k IPs, I don't want to store them all in one file with 250k lines
                    //      instead, I divied them into multiple files, this way each time I for example scan 192 range, I wouldn't
                    //      be having range 23 stored in my memory, and when I'm done with 192, the file closes, the RAM cleans itself,
                    //      and I proceed to range 23 and so on.
                    _ = IPAddressExtension.WriteRangeToDisk(IP, append).Result;
                }
            }

            // the IPsDirectory points to where all these ranges are written to disk at.
            IPsDirectory = _defPath;
        }

        // in this CTOR I'll be receiving my IPs from API address on a Server containing all these IPs.
        public CFIPList(string APIAddress, string ISP, bool append)
        {
            try
            {
                // Object is initiated using APIAddress showing what the domain is, for example "domain.com"
                APIService _apiService = new(APIAddress);

                // this code will point to the /ToScan/{ISP} endpoint of the domain and receive IPs from it.
                //      it will also store them in a string Array.
                string[] IPs = _apiService.GetIPAddressesToScanAsync(ISP).GetAwaiter().GetResult();

                IPs.SortIPArrayByIPRange(out _ipRanges);
                // this code will sort the IPs received from the API before Writing them to list, to help with the readibility
                _ = IPAddressExtension.WriteRangeToDisk(_ipRanges, append);
                //_ = IPAddressExtension.WriteRangeToDisk(IPs.OrderBy(ip => IPAddress.Parse(ip)).ToArray(), $"{ISP} - {DateTime.Now}.txt");
                // 
                IPsDirectory = _defPath;
                IPListStatus = ListStatus.API;
            }

            catch
            {
                throw new Exception("Network Unreachable");
            }
        }
        // In this CTOR I will be receiving IPs directly from user in a textbox for example.
        public CFIPList(string[] UserIPS, bool append)
        {
            // this Dictionary is in string,List<string> format
            //      the first string is the IP range e.g 192.168.1
            //      the List<string> is all the IPs lying in that range.

            UserIPS.SortIPArrayByIPRange(out _ipRanges);


            // finally it will write each range to a different file.
            _ = IPAddressExtension.WriteRangeToDisk(_ipRanges, append);
            IPsDirectory = _defPath;
        }

        private static List<List<string>> GenerateIP(string[] IPlist)
        {
            try
            {
                // create a List of Lists to store IP ranges
                List<List<string>> result = new();

                // loop through each IP in the HashSet, we made HashSet to avoid any duplicates.
                foreach (var Line in new HashSet<string>(IPlist))
                {
                    // check if IP is not null, has 4 octets, and contains a forward slash
                    if (Line != null && Line.Split(".").Length == 4 && Line.Contains('/'))
                    {
                        // if IP is valid, generate a list of all IPs in the range and add it to the result
                        var IPsFromIPRange = IPAddressExtension.GetAllIPsFromIPRange(Line);

                        result.Add(IPsFromIPRange);
                    }
                }

                // return the final result
                return result;
            }
            catch (Exception e)
            {
                // if an exception occurs, throw a new exception with the message
                throw new Exception($"{e.Message}");
            }
        }

        // work more on this
        // This method takes a folder path and a Scanner delegate as input,
        // and returns an IEnumerable of string objects.
        private static IEnumerable<string> Scanit(string FolderPath, Action<string> Scanner)
        {
            // Iterate over each file in the specified folder.
            foreach (var filepath in Directory.GetFiles(FolderPath))
            {
                // Open the file for reading using a StreamReader.
                using (StreamReader reader = new StreamReader(filepath))
                {
                    // Declare a variable to hold each line of text.
                    string IP;

                    // Read each line of text in the file until the end is reached.
                    while ((IP = reader.ReadLine()) != null)
                    {
                        // Use the yield keyword to return the line of text as an element in the IEnumerable.
                        yield return IP;

                        // Call the Scanner delegate, passing the line of text as an argument.
                        Scanner(IP);
                    }
                }
            }
        }

        // A method that divides a given file into multiple files based on the given number of files
        // This method takes a path to an existing file and the number of new files to create,
        // and returns a boolean indicating whether the operation was successful.
        private static bool DivideFileToFiles(string oldFilePath, int countNewFiles)
        {
            // Read all lines of the old file into an array.
            var oldFile = File.ReadAllLines(oldFilePath);

            // Count the number of lines in the old file.
            int lines = CountLines(oldFilePath);

            // Calculate the number of lines to allocate to each new file.
            int linesEachFile = lines / countNewFiles;

            // Get the base name of the old file without the extension.
            string fileNameBase = Path.GetFileNameWithoutExtension(oldFilePath);

            // Loop over each new file to be created.
            for (int i = 0; i < countNewFiles; i++)
            {
                // Construct the path to the new file.
                string newFilePath = $"{fileNameBase}_{i}.txt";

                // Create a new StreamWriter to write to the new file.
                using (StreamWriter writer = new(newFilePath))
                {
                    // Loop over the lines of the old file to write to the new file.
                    for (int j = i * linesEachFile; j < (i + 1) * linesEachFile; j++)
                    {
                        // Check if the index is within the bounds of the old file array.
                        if (j < oldFile.Length)
                        {
                            // Write the line to the new file.
                            writer.WriteLine(oldFile[j]);
                        }
                        else
                        {
                            // If the index is out of bounds, exit the loop.
                            break;
                        }
                    }
                }
            }

            // Return true to indicate that the operation was successful.
            return true;
        }


        // A method that counts the number of lines in a given file
        private static int CountLines(string FilePath)
        {
            int count = 0;
            using (StreamReader reader = new(FilePath))
            {
                foreach (string line in File.ReadLines(FilePath))
                {
                    count++;
                }
            }
            return count;
        }
    }

    public static class IPAddressExtension
    {
        private const string _filePath = @$"/IPRanges";

        public static void SortIPArrayByIPRange(this string[] IPs, out Dictionary<string, List<string>> SortedResult)
        {
            // this Dictionary has the range as Key and all the IPs in that range as values
            Dictionary<string, List<string>> ipRanges = new();

            // this foreach loop will:
            //      first split the Network from the Home part => for example: input: "192.168.1.1" output: "192.168.1" and "1"
            //      then it will check if we already have a key for that range in Dictionary, if not, it will add a key by the name
            //              of that network.
            //      on the last line it will add the IPaddress as the value to it's corresponding key.
            //

            // we make a HashSet to avoid any duplicates
            foreach (var IPAddress in new HashSet<string>(IPs))
            {
                // we separate the Range from the home network
                var ipRange = IPAddress.Substring(0, IPAddress.LastIndexOf('.'));
                // if we don't have a key for that range, we add it to the dictionary
                if (!ipRanges.ContainsKey(ipRange))
                {
                    ipRanges.Add(ipRange, new List<string>());
                }
                // we add the corresponding IPs to the range key.
                ipRanges[ipRange].Add(IPAddress);
            }
            SortedResult = ipRanges;
        }

        // This extension method takes an array of string IPs and returns a list of all IPs within the specified IP ranges.
        public static async Task<List<string>> IPRangeToIPs(this string[] IPs)
        {
            // Create a hash set to hold all unique IP addresses.
            HashSet<string> TotalIPS = new(IPs);

            // Iterate over each IP address in the set.
            foreach (var Line in TotalIPS)
            {
                // Check if the line is not null, contains four parts separated by periods, and contains a slash indicating an IP range.
                if (Line != null && Line.Split(".").Length == 4 && Line.Contains('/'))
                {
                    // If the line matches the criteria, call the GetAllIPsFromIPRange method to get all IPs in the range.
                    var res = GetAllIPsFromIPRange(Line);
                    return res;
                }
            }

            // If no IP ranges are found in the input, throw an exception.
            throw new Exception("Error Converting IPRange to File!");
        }

        // This method takes an IP range in the format "192.168.1.1/24" and returns a list of all IPs within that range.
        public static List<string> GetAllIPsFromIPRange(string IP)
        {
            // Create a new list to hold the resulting IPs.
            List<string> IPList = new();

            // Split the input into the IP address and the prefix length.
            string[] splitted = IP.Split('/');

            // Call the GetIPInfo method to get the start and end IPs for the range, as well as the total number of IPs.
            (uint start, uint end, uint total) = GetIPInfo(splitted[0], int.Parse(splitted[1]));

            // If there are any IPs in the range, add them to the IPList.
            if (total > 0)
            {
                for (uint i = start; i <= end; i++)
                {
                    IPList.Add(new IPAddress(BitConverter.GetBytes(i).Reverse().ToArray()).ToString());
                }
            }

            // Return the list of IPs.
            return IPList;
        }


        // This method takes an IP address and a prefix length (e.g. 24 for a /24 network) and returns the start and end IPs for that subnet,
        // as well as the total number of IPs in the subnet.
        private static (uint start, uint end, uint total) GetIPInfo(string IP, int hostLength)
        {
            uint start;
            uint end;
            uint total;

            // Create a new SubnetMask object using the given prefix length.
            IPAddress netAddr = SubnetMask.CreateByHostBitLength(hostLength);

            // Get the subnet mask as a byte array and the input IP address as a byte array.
            byte[] mask = netAddr.GetAddressBytes();
            byte[] iprev = IPAddress.Parse(IP).GetAddressBytes();

            // Calculate the network ID for the subnet by bitwise-ANDing the IP address with the subnet mask.
            byte[] netid = BitConverter.GetBytes(BitConverter.ToUInt32(iprev, 0) & BitConverter.ToUInt32(mask, 0));

            // Calculate the inverse of the subnet mask (i.e. the broadcast mask) by bitwise-NOTting the subnet mask.
            byte[] inv_mask = mask.Select(r => (byte)~r).ToArray();

            // Calculate the broadcast address for the subnet by bitwise-XORing the network ID with the broadcast mask.
            byte[] brCast = BitConverter.GetBytes(BitConverter.ToUInt32(netid, 0) ^ BitConverter.ToUInt32(inv_mask, 0));

            // Calculate the start and end IPs for the subnet, skipping the network ID and broadcast address.
            start = BitConverter.ToUInt32(netid.Reverse().ToArray(), 0) + 1;
            end = BitConverter.ToUInt32(brCast.Reverse().ToArray(), 0);

            // Calculate the total number of IPs in the subnet.
            total = end - start;

            // Return a tuple containing the start and end IPs for the subnet, as well as the total number of IPs.
            return (start, end, total);
        }


        // This method writes a list of IP addresses to a file on disk.
        // The file name is constructed from the first two octets of the first IP address.
        // The full path to the file is determined using a static variable _filePath.
        public static async Task<string> WriteRangeToDisk(List<string> IPs, bool append)
        {
            // Extract the first two octets of the first IP address to use as the filename.
            string filename = IPs[0].Split(".")[0] + '-' + IPs[0].Split(".")[1];

            // Construct the full path to the file using the static _filePath variable.
            string fullPath = Path.Combine(_filePath, filename);

            try
            {
                if(append)
                {
                    // If "append" is true, append the list of IP addresses to the existing file if it exists.
                    await File.AppendAllLinesAsync(fullPath, IPs);
                }
                else
                {
                    // If "append" is false, check if a file with the same name already exists.
                    if (File.Exists(fullPath))
                    {
                        // If a file with the same name already exists, construct a new filename with the current date and time appended to it.
                        fullPath = Path.Combine(_filePath, $"{Path.GetFileNameWithoutExtension(fullPath) + '-' + DateTime.Now.TimeOfDay}.txt");
                    }
                    // Write the list of IP addresses to the file asynchronously.
                    await File.WriteAllLinesAsync(fullPath, IPs);

                }

                // Return the full path to the file.
                return fullPath;
            }
            catch
            {
                // If an exception occurs during the file write, throw an IOException with a custom error message.
                throw new IOException($"Error Writing File {filename}");
            }
        }

        // This method writes an array of IP addresses to a file on disk with the given filename.
        // The full path to the file is determined using a static variable _filePath.
        public static async Task WriteRangeToDisk(string[] IPs, string filename)
        {
            // Construct the full path to the file using the static _filePath variable and the given filename.
            string fullPath = Path.Combine(_filePath, filename);

            try
            {
                // Write the array of IP addresses to the file asynchronously.
                await File.WriteAllLinesAsync(fullPath, IPs);

            }
            catch
            {
                // If an exception occurs during the file write, throw an IOException with a custom error message.
                throw new IOException($"Error Writing File {filename}");
            }
        }

        // This method writes a dictionary of IP ranges to separate files on disk.
        // The keys of the dictionary represent the names of the IP ranges, and the values are lists of IP addresses.
        // If the bool parameter "append" is true, the IP addresses are appended to the existing file if it exists.
        // If "append" is false, a new file is created with the current date and time appended to the filename if a file with the same name already exists.
        // The full path to the files is determined using a static variable _filePath.
        public static async Task WriteRangeToDisk(Dictionary<string, List<string>> IPRanges, bool append)
        {
            try
            {
                // Loop through each key-value pair in the dictionary.
                foreach (var ipRange in IPRanges)
                {
                    // Construct a filename for the current IP range by replacing periods with hyphens.
                    var fileName = $"{ipRange.Key.Replace(".", "-")}.txt";

                    // Construct the full path to the file using the static _filePath variable and the filename.
                    string fullPath = Path.Combine(_filePath, fileName);

                    // Order the list of IP addresses by their numeric value.
                    var content = ipRange.Value.OrderBy(ip => IPAddress.Parse(ip));

                    if (append)
                    {
                        // If "append" is true, append the list of IP addresses to the existing file if it exists.
                        await File.AppendAllLinesAsync(fullPath, content);
                    }
                    else
                    {
                        // If "append" is false, check if a file with the same name already exists.
                        if (File.Exists(fullPath))
                        {
                            // If a file with the same name already exists, construct a new filename with the current date and time appended to it.
                            fullPath = Path.Combine(_filePath, $"{Path.GetFileNameWithoutExtension(fileName) + '-' + DateTime.Now.TimeOfDay}.txt");
                        }

                        // Write the list of IP addresses to a new file with the constructed filename.
                        await File.WriteAllLinesAsync(fullPath, content);
                    }
                }
            }
            catch
            {
                // If an exception occurs during the file write, throw an IOException with a custom error message.
                throw new IOException($"Error Writing File");
            }
        }

    }
}