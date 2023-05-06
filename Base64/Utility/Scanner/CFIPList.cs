using Microsoft.VisualBasic.Devices;
using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms.Design;

namespace Base64.Utility.Scanner
{
    public class CFIPList
    {
        public readonly string IPsDirectory;
        public readonly ListStatus IPListStatus;
        private const string _cfpath = @"\services\cfIPlist.txt";
        private const string _defPath = @$"/IPRanges";
        public enum ListStatus
        {
            Local,
            API,
            Input
        }
        //prepare IP list to Scan either by Receiving from API or Reading from File or Be given from user

        public CFIPList(string filePath)
        {

            string[] cfList;

            if (!(Directory.Exists(filePath)) || !(Directory.GetFiles(filePath).Length > 1))
            {
                cfList = File.ReadAllLines(_cfpath);
                IPListStatus = ListStatus.Local;
            }

            else
            {
                cfList = File.ReadAllLines(filePath);
                IPListStatus = ListStatus.Input;
            }

            List<List<string>> IPList = GenerateIP(cfList);

            foreach (var IP in IPList)
            {
                _ = IPAddressExtension.WriteRangeToDisk(IP).Result;
            }

            IPsDirectory = Path.GetDirectoryName(filePath)!;
        }

        //public CFIPList(string filePath, bool isRangeFile)
        //{

        //    if (isRangeFile)
        //    {
        //        string[] cfList;
        //        if (!(Directory.Exists(filePath)) || !(Directory.GetFiles(filePath).Length > 1))
        //        {
        //            cfList = File.ReadAllLines(_cfpath);
        //            IPListStatus = ListStatus.Local;
        //        }
        //        else
        //        {
        //            cfList = File.ReadAllLines(filePath);
        //            IPListStatus = ListStatus.Input;
        //        }

        //        var path = cfList.IPRangeToIPs().Result;

        //        _ = IPAddressExtension.WriteRangeToDisk(path).Result;

        //        _IPsDirectory = Path.GetDirectoryName(filePath)!;
        //    }
        //}

        public CFIPList(string APIAddress, string ISP)
        {
            try
            {
                APIService apiService = new(APIAddress);
                var IPs = apiService.GetIPAddressesToScanAsync(ISP).GetAwaiter().GetResult();

                _ = IPAddressExtension.WriteRangeToDisk(IPs.OrderBy(ip => IPAddress.Parse(ip)).ToArray(), $"{ISP} - {DateTime.Now}.txt");
                IPsDirectory = _defPath;
                IPListStatus = ListStatus.API;
            }

            catch
            {
                throw new Exception("Network Unreachable");
            }
        }
        public CFIPList(string[] UserIPS)
        {
            HashSet<string> UniqueIPs = new(UserIPS);
            Dictionary<string, List<string>> ipRanges = new();

            foreach (var IPAddress in UniqueIPs)
            {
                var ipRange = IPAddress.Substring(0, IPAddress.LastIndexOf('.'));
                if (!ipRanges.ContainsKey(ipRange))
                {
                    ipRanges.Add(ipRange, new List<string>());
                }
                ipRanges[ipRange].Add(IPAddress);
            }
            _ = IPAddressExtension.WriteRangeToDisk(ipRanges);
            IPsDirectory = _defPath;
        }

        private static List<List<string>> GenerateIP(string[] IPlist)
        {
            try
            {
                HashSet<string> UniqueIPs = new(IPlist);
                List<List<string>> result = new();

                foreach (var Line in UniqueIPs)
                {
                    if (Line != null && Line.Split(".").Length == 4 && Line.Contains('/'))
                    {
                        var IPsFromIPRange = IPAddressExtension.GetAllIPsFromIPRange(Line);
                        result.Add(IPsFromIPRange);
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
        // work more on this
        private static IEnumerable<string> Scanit(string FolderPath, Action<string> Scanner)
        {
            foreach (var filepath in Directory.GetFiles(FolderPath))
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    string IP;
                    while ((IP = reader.ReadLine()) != null)
                    {
                        yield return IP;
                        Scanner(IP);
                    }
                }
            }
        }

        private static bool DivideFileToFiles(string oldFilePath, int countNewFiles)
        {
            var oldFile = File.ReadAllLines(oldFilePath);
            int lines = CountLines(oldFilePath);
            int linesEachFile = lines / countNewFiles;
            string fileNameBase = Path.GetFileNameWithoutExtension(oldFilePath);

            for (int i = 0; i < countNewFiles; i++)
            {
                string newFilePath = $"{fileNameBase}_{i}.txt";
                using (StreamWriter writer = new(newFilePath))
                {
                    for (int j = i * linesEachFile; j < (i + 1) * linesEachFile; j++)
                    {
                        if (j < oldFile.Length)
                        {
                            writer.WriteLine(oldFile[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return true;
        }


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

        public static async Task<List<string>> IPRangeToIPs(this string[] IPs)
        {
            HashSet<string> TotalIPS = new(IPs);

            foreach (var Line in TotalIPS)
            {
                if (Line != null && Line.Split(".").Length == 4 && Line.Contains('/'))
                {
                    var res = GetAllIPsFromIPRange(Line);
                    return res;
                }
            }
            throw new Exception("Error Converting IPRange to File!");
        }
        public static List<string> GetAllIPsFromIPRange(string IP)
        {
            List<string> IPList = new();
            // 192.168.1.1/24

            string[] splitted = IP.Split('/');
            (uint start, uint end, uint total) = GetIPInfo(splitted[0], int.Parse(splitted[1]));

            if (total > 0)
            {
                for (uint i = start; i <= end; i++)
                {
                    IPList.Add(new IPAddress(BitConverter.GetBytes(i).Reverse().ToArray()).ToString());
                }
            }
            return IPList;
        }

        private static (uint start, uint end, uint total) GetIPInfo(string IP, int hostLength)
        {
            uint start;
            uint end;
            uint total;

            IPAddress netAddr = SubnetMask.CreateByHostBitLength(hostLength);

            byte[] mask = netAddr.GetAddressBytes();
            byte[] iprev = IPAddress.Parse(IP).GetAddressBytes();
            byte[] netid = BitConverter.GetBytes(BitConverter.ToUInt32(iprev, 0) & BitConverter.ToUInt32(mask, 0));
            byte[] inv_mask = mask.Select(r => (byte)~r).ToArray();
            byte[] brCast = BitConverter.GetBytes(BitConverter.ToUInt32(netid, 0) ^ BitConverter.ToUInt32(inv_mask, 0));

            start = BitConverter.ToUInt32(netid.Reverse().ToArray(), 0) + 1;
            end = BitConverter.ToUInt32(brCast.Reverse().ToArray(), 0);

            total = end - start;
            return (start, end, total);
        }

        public static async Task<string> WriteRangeToDisk(List<string> IPs)
        {

            string filename = IPs[0].Split(".")[0] + '-' + IPs[0].Split(".")[1];
            string fullPath = Path.Combine(_filePath, filename);
            try
            {
                await File.WriteAllLinesAsync(fullPath, IPs);

                return fullPath;
            }
            catch
            {
                throw new IOException($"Error Writing File {filename}");
            }
        }
        public static async Task WriteRangeToDisk(string[] IPs, string filename)
        {
            string fullPath = Path.Combine(_filePath, filename);
            try
            {
                await File.WriteAllLinesAsync(fullPath, IPs);

            }
            catch
            {
                throw new IOException($"Error Writing File {filename}");
            }
        }
        public static async Task WriteRangeToDisk(ِDictionary<string, List<string>> IPRanges)
        {
            try
            {
                foreach (var ipRange in IPRanges)
                {
                    var fileName = $"{ipRange.Key.Replace(".", "-")}.txt";
                    string fullPath = Path.Combine(_filePath, fileName);
                    await File.WriteAllLinesAsync(fullPath, ipRange.Value.OrderBy(ip => IPAddress.Parse(ip)));
                }
            }
            catch
            {
                throw new IOException($"Error Writing File");
            }
        }
    }
}