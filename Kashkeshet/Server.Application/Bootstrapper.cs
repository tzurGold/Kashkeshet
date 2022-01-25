using Server.BLL.Core;
using Server.BLL.Implementation;
using System.Net;

namespace Server.Application
{
    public class Bootstrapper
    {
        public ServerBase Initialize()
        {
            return new KashkeshetServer(8080, IPAddress.Parse("127.0.0.1"));
        }
    }
}
