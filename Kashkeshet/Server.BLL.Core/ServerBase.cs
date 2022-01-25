﻿using System.Net;

namespace Server.BLL.Core
{
    public abstract class ServerBase
    {
        protected readonly int Port;
        protected readonly IPAddress Ip;

        protected ServerBase(int port, IPAddress ip)
        {
            Port = port;
            Ip = ip;
        }

        public abstract void Listen();
        public abstract void Serve();
    }
}
