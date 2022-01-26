using Common.Communicators.Abstractions;
using Common.DTOs;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public abstract class ClientHandlerBase
    {
        protected readonly IRequestReceiver RequestReceiver;
        protected readonly IDictionary<RequestType, RequestHandlerBase> RequestHandlers;

        protected ClientHandlerBase(IRequestReceiver requestReceiver,
            IDictionary<RequestType, RequestHandlerBase> requestHandlers)
        {
            RequestReceiver = requestReceiver;
            RequestHandlers = requestHandlers;
        }

        public abstract void HandleClient(ICommunicator communicator);
    }
}
