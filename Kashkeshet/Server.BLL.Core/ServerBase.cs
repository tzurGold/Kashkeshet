namespace Server.BLL.Core
{
    public abstract class ServerBase
    {
        protected readonly uint Port;
        protected readonly uint Ip;

        protected ServerBase(uint port, uint ip)
        {
            Port = port;
            Ip = ip;
        }

        public abstract void Connect();
        public abstract void Serve();
    }
}
