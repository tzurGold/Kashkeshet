using Server.BLL.Core;
using System;

namespace Server.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();

            ServerBase server = bootstrapper.Initialize();

            server.Listen();

            server.Serve();
        }
    }
}
