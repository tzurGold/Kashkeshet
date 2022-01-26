using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Common.Communicators.Abstractions;
using Common.Communicators.Implementations;
using Server.BLL.Core;

namespace Server.BLL.Implementation
{
    public class KashkeshetServer : ServerBase
    {
        private readonly TcpListener _listener;
        private readonly ClientHandlerBase _clientHandler;
        private readonly IFormatter _formatter; 
        public KashkeshetServer(int port,
            IPAddress ip,
            ClientHandlerBase clientHandler,
            IFormatter formatter) : base(port, ip)
        {
            _listener = new TcpListener(ip, port);
            _clientHandler = clientHandler;
            _formatter = formatter;
        }

        public override bool TryListen()
        {
            try
            {
                _listener.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void Serve()
        {
            while (true)
            {
                TcpClient client = _listener.AcceptTcpClient();
                ICommunicator communicator = new TcpCommunicator(client, _formatter);
                Task.Run(() => _clientHandler.HandleClient(communicator));
            }
        }
    }
}
