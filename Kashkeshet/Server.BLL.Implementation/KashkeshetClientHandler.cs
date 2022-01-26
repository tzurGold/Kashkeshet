using System.Collections.Concurrent;
using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;

namespace Server.BLL.Implementation
{
    public class KashkeshetClientHandler : ClientHandlerBase
    {
        private readonly IDictionary<string, ICommunicator> _conntections;
        private IList<IChat> _chats;
        public KashkeshetClientHandler(IRequestReceiver requestReceiver,
            IDictionary<RequestType, IRequestHandler> requestHandlers,
            IList<IChat> chats)
            : base(requestReceiver, requestHandlers)
        {
            _conntections = new ConcurrentDictionary<string, ICommunicator>();
            _chats = chats;
        }

        public override void HandleClient(ICommunicator communicator)
        {
            try
            {
                Request request = RequestReceiver.Receive(communicator);
                RequestHandlers[RequestType.Login].HandleRequest(request, _conntections, out _chats);
                RequestHandlers[request.RequestType].HandleRequest(request, _conntections, out _chats);
                while (request.RequestType != RequestType.Logout)
                {
                    request = RequestReceiver.Receive(communicator);
                    RequestHandlers[request.RequestType].HandleRequest(request, _conntections, out _chats);
                }
            }
            catch
            {

            }
        }
    }
}
