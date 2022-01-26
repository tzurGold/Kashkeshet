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
        private readonly IList<ChatBase> _chats;
        public KashkeshetClientHandler(IRequestReceiver requestReceiver,
            IDictionary<RequestType, RequestHandlerBase> requestHandlers,
            IList<ChatBase> chats)
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
                _conntections.Add(request.From, communicator);
                RequestHandlers[RequestType.Login].HandleRequest(request, _conntections, _chats);
                RequestHandlers[request.RequestType].HandleRequest(request, _conntections, _chats);
                while (request.RequestType != RequestType.Logout)
                {
                    request = RequestReceiver.Receive(communicator);
                    RequestHandlers[request.RequestType].HandleRequest(request, _conntections, _chats);
                }
            }
            catch
            {

            }
        }
    }
}
