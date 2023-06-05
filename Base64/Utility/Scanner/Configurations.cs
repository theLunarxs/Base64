using static Base64.Utility.Scanner.ClientConfig;

namespace Base64.Utility.Scanner
{
    public class Configurations
    {
        public struct CheckIPConfigurations
        {
            public double targetDownloadSpeed;
            public double targetUploadSpeed;
            public ClientConfig ClientConfig;
            public bool checkFronting;
            public int timeoutSec;
            public bool toCheckSpeed;
            public int checkTargetVolume;
            public short numOfProccess;
        }
        public struct ClientConfiguration
        {
            public ConfigType ConfigType;
            public int Port;
            public string UUID;
            public string Host;
            public string Path;
            public string SNI;
            public string IP;
            public NetworkType NetworkType;
        }
        public struct V2rayProcessConfig
        {
            public int _targetVolume;
            public double _downloadTimeout;
            public float _downloadDuration;
            public double _targetDLSpeed;
            public double _targetUPSpeed;
        }
    }
}
