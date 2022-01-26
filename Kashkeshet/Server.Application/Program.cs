using Server.BLL.Core;
using log4net.Config;
using log4net;
using System.Reflection;

namespace Server.Application
{
    public class Program
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Main(string[] args)
        {
            XmlConfigurator.Configure(); // only once

            _log.Debug("Program starts");

            Bootstrapper bootstrapper = new Bootstrapper();

            ServerBase server = bootstrapper.Initialize();

            if(server.TryListen())
            {
                server.Serve();
            }

            _log.Debug("Program ends");
        }
    }
}
