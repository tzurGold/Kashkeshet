using Common.Communicators.Abstractions;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace Common.Communicators.Implementations
{
    public class TcpCommunicator : ICommunicator
    {
        private TcpClient _client;
        private NetworkStream _clientStream;
        private IFormatter _formatter;

        public TcpCommunicator(TcpClient client, IFormatter formatter)
        {
            _client = client;
            _formatter = formatter;
            Initializer();
        }

        public object Receive()
        {
            object obj = _formatter.Deserialize(_clientStream);
            return obj;
        }

        public void Send(object obj)
        {
            _formatter.Serialize(_clientStream, obj);
        }

        private void Initializer()
        {
            _clientStream = _client.GetStream();
        }

    }
}
