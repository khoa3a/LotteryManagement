using System.Configuration;

namespace Common.Utils
{
    public class ConfigUtils
    {
        private static ConfigUtils _instance = null;
        public static ConfigUtils Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (typeof(ConfigUtils))
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigUtils();
                        }
                    }
                }
                return _instance;
            }
        }

        public string LotteryServiceUrl = ConfigurationManager.AppSettings["LotteryServiceUrl"];
        //public string CititransSecretKey = ConfigurationManager.AppSettings["CititransSecretKey"];
        //public string CititransAgentId = ConfigurationManager.AppSettings["CititransAgentId"];

        public int CacheDayDuration
        {
            get
            {
                var success = int.TryParse(ConfigurationManager.AppSettings["CacheDayDuration"], out int parsed);
                return success ? parsed : 30;
            }
        }

        public int CititransServerTimeOffset
        {
            get
            {
                var success = int.TryParse(ConfigurationManager.AppSettings["CititransServerTimeOffset"], out int parsed);
                return success ? parsed : 8;
            }
        }

        public int DefaultTimeOutMinute
        {
            get
            {
                var success = int.TryParse(ConfigurationManager.AppSettings["DefaultTimeOutMinute"], out int parsed);
                return success ? parsed : 10;
            }
        }
    }
}
