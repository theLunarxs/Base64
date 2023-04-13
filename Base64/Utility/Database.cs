using Renci.SshNet;
using System.Diagnostics;
using static Base64.Utility.Tools;
using static Base64.Utility.Configuration;

namespace Base64.Utility
{
    public static class Database
    {
        public static bool FetchDBFromServer(Server ClientServer)
        {
            var connectionInfo = new ConnectionInfo(ClientServer.IP, int.Parse(ClientServer.Port), ClientServer.Username,
                new PasswordAuthenticationMethod(ClientServer.Username, ClientServer.Password));

            using (var sftpClient = new SftpClient(connectionInfo))
            {
                try
                {
                    sftpClient.Connect();
                    Debug.WriteLine("SFTP Connected");

                    // Download file from remote server
                    using (var fileStream = File.Create(@"F:\test\testo1.db"))
                    {
                        try
                        {
                            sftpClient.DownloadFile("/etc/x-ui/x-ui.db", fileStream);
                            Debug.WriteLine("File downloaded");
                        }
                        catch
                        {
                            return false;
                        }
                    }

                    sftpClient.Disconnect();
                }
                catch
                {
                    return false;
                }
            }
            Debug.WriteLine("Disconnected");

            return true;
        }
    }
}