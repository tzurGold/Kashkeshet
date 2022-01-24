namespace Server.BLL.Core
{
    public abstract class ServerBase
    {
        private readonly uint _port;
        private readonly uint _ip;

        protected ServerBase(uint port, uint ip)
        {
            _port = port;
            _ip = ip;
        }

        public abstract void Connect();
        public abstract void Serve();
    }
}
