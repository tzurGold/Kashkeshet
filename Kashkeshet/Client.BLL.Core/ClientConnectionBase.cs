namespace Client.BLL.Core
{
    public abstract class ClientConnectionBase
    {
        private readonly uint _port;
        private readonly string _ip;

        protected ClientConnectionBase(uint port, string ip)
        {
            _port = port;
            _ip = ip;
        }

        public abstract void Connect();
        public abstract void CloseConnection();
    }
}
