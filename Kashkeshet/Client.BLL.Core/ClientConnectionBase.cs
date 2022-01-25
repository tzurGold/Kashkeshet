namespace Client.BLL.Core
{
    public abstract class ClientConnectionBase
    {
        protected readonly int Port;
        protected readonly string Ip;

        protected ClientConnectionBase(int port, string ip)
        {
            Port = port;
            Ip = ip;
        }

        public abstract void Connect();
        public abstract void CloseConnection();
    }
}
