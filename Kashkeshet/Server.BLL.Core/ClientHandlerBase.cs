using Common.Communicators.Abstractions;
using Common.DTOs;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public abstract class ClientHandlerBase
    {
        private readonly IRequestReceiver _requestReceiver;
        private readonly IDictionary<RequestType, IResponder> _responders;

        protected ClientHandlerBase(IRequestReceiver requestReceiver, IDictionary<RequestType, IResponder> responders)
        {
            _requestReceiver = requestReceiver;
            _responders = responders;
        }

        public abstract void HandleClient(ICommunicator communicator);

        /*private void HandleClient(TcpClient client)
        {
            while (true)
            {
                Request request = (Request)communicator.Receive();
                // addConnection()
                // processing + 
                // response

            }
        }*/
    }
}
