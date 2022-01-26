using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Responders;

namespace Server.BLL.Implementation
{
    public class KashkeshetClientHandler : ClientHandlerBase
    {

        public KashkeshetClientHandler(IConnectionResponder connectionResponder,
            IMessageResponder messageResponder)
            : base(requestReceiver, responders)
        {
        }

        public override void HandleClient(ICommunicator communicator)
        {
            Request request = (Request)communicator.Receive();
            // respond login + send history
            do
            {
                //request.

                request = (Request)communicator.Receive();
            } while (true);
            while (true)
            {
                //request.
                
                request = (Request)communicator.Receive();
            }
        }
    }
}
