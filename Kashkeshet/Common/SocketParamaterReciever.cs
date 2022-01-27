using System.Configuration;
using System.Net;

namespace PingPong.Common
{
    public class SocketParamaterReciever
    {
        public string GetSocketIPAddress()
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            return ip;
        }

        public int GetSocketPort()
        {
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            return port;
        }
    }
}
