using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;
using Server.BLL.Implementation.Chats;
using System.Linq;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class NewChatRequestHandler : RequestHandlerBase
    {
        private readonly IConnectionsSelector _connectionsSelector;
        public NewChatRequestHandler(IResponseFactory responseFactory,
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
            string responseContent = $"Chat {request.ClientMessage.To} created";
            Response response = ResponseFactory.CreateResponse("SYSTEM",
                responseContent,
                request.ClientMessage.ContentType);
            IList<string> members = (IList<string>)request.ClientMessage.Content;
            members.Add(request.From);
            IChat groupChat = new GroupChat(new Queue<Response>(), members);
            chats.Add(groupChat);
            var recipientsConnections = _connectionsSelector.GetRecipientsCommunicators(connections, members);
            ResponseSender.SendResponse(response, recipientsConnections);
        }
    }
}
