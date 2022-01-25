using Client.BLL.Core;
using System.Net.Sockets;

namespace Client.BLL.Implementation
{
    public class KashkeshetClientConnection : ClientConnectionBase
    {
        private readonly TcpClient _tcpClient;
        public KashkeshetClientConnection(int port, string ip, TcpClient client) : base(port, ip)
        {
            _tcpClient = client;
        }

        public override void CloseConnection()
        {
            _tcpClient.Close();
        }

        public override void Connect()
        {
            _tcpClient.Connect(Ip, Port);
        }
    }
}
