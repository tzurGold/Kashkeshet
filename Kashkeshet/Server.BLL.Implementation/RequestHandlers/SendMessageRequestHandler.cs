using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class SendMessageRequestHandler : RequestHandlerBase
    {
        private readonly IConnectionsSelector _connectionsSelector;

        public SendMessageRequestHandler(IResponseFactory responseFactory,
            IResponseSender responseSender,
            IConnectionsSelector connectionsSelector)
            : base(responseFactory, responseSender)
        {
            _connectionsSelector = connectionsSelector;
        }

        public override void HandleRequest(Request request,
            IDictionary<string, ICommunicator> connections,
            IList<IChat> chats)
        {
            
            Response response = ResponseFactory.CreateResponse(request.From,
                request.ClientMessage.Content,
                request.ClientMessage.ContentType);
            
            IList<string> members = request.ClientMessage.To
          
            //var recipientsConnections = _connectionsSelector.GetRecipientsCommunicators(connections, members);
            //ResponseSender.SendResponse(response, recipientsConnections);
        }
    }
}
