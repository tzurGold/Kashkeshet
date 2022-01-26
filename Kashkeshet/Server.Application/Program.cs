using Server.BLL.Core;

namespace Server.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bootstrapper bootstrapper = new Bootstrapper();

            ServerBase server = bootstrapper.Initialize();

            if(server.TryListen())
            {
                server.Serve();
            }
        }
    }
}
