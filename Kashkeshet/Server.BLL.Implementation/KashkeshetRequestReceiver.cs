using Common.Communicators.Abstractions;
using Common.DTOs;
using log4net;
using Server.BLL.Core;
using System.Reflection;

namespace Server.BLL.Implementation
{
    public class KashkeshetRequestReceiver : IRequestReceiver
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Request Receive(ICommunicator communicator)
        {
            _log.Debug("Receive message using communicator");
            Request request = (Request)communicator.Receive();
            return request;
        }
    }
}
