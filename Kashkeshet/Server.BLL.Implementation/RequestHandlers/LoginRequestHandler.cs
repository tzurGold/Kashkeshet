using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;
using Server.BLL.Implementation.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class LoginRequestHandler : RequestHandlerBase
    {
        private readonly IConnectionsSelector _connectionsSelector;

        public LoginRequestHandler(IResponseFactory responseFactory,
            IResponseSender responseSender,
            IConnectionsSelector connectionsSelector)
            : base(responseFactory, responseSender)
        {
            _connectionsSelector = connectionsSelector;
        }

        public override void HandleRequest(Request request,
            IDictionary<string, ICommunicator> connections,
            IList<ChatBase> chats)
        {
            string responseContent = $"{request.From} logged in";
            Response response = ResponseFactory.CreateResponse("SYSTEM",
                responseContent,
                MessageContentType.Text);
            ResponseSender.SendResponse(response, connections);
            string clientName = request.From;
            foreach (var chat in chats)
            {
                IList<string> members = null;
                if (chat is GroupChat)
                {
                    members = ((GroupChat)chat).GetMembers();
                }
                if (!(chat is GroupChat) || 
                    ((GroupChat)chat).GetMembers().Contains(clientName))
                {
                    var responses = chat.GetChatHistory();
                    var recipientsConnections = _connectionsSelector.GetRecipientsCommunicators(connections, members);
                    foreach (var historyResponse in responses)
                    {
                        ResponseSender.SendResponse(response, recipientsConnections);
                    }
                }
            }
        }
    }
}
