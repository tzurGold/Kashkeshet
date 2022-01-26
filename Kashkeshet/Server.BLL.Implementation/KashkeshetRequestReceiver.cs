using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;

namespace Server.BLL.Implementation
{
    public class KashkeshetRequestReceiver : IRequestReceiver
    {
        public Request Receive(ICommunicator communicator)
        {
            Request request = (Request)communicator.Receive();
            return request;
        }
    }
}
