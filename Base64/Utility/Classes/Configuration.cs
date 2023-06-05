using static Base64.Utility.Classes.Inbound;

namespace Base64.Utility.Classes
{
    public class Configuration
    {
        public Server ClientServer;
        public IOConfig IOconfig;
        public TaskConfiguration TaskConfig;
        public Configuration(Server ClientServer, IOConfig Ioconfig, TaskConfiguration TaskConfig)
        {
            IOconfig = Ioconfig;
            this.ClientServer = ClientServer;
            this.TaskConfig = TaskConfig;
        }

        public struct Server
        {
            public string IP;
            public string Port;
            public string Username;
            public string Password;
            public PanelType PanelType;
        }
        public struct TaskConfiguration
        {
            public bool SeperatePermutations;
            public string IPFilePath;
            public bool IPsection;
            public bool IosCompatible;
        }
        public struct IOConfig
        {
            public string path;
            public string text;
            public bool unique;
            public bool useNumberAndLetter;
            public string Seedname;
        }
    }
}
