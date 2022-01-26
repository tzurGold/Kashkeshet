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
        public LoginRequestHandler(IResponseFactory responseFactory,
            IResponseSender responseSender)
            : base(responseFactory, responseSender)
        {

        }

        public override void HandleRequest(Request request,
            IDictionary<string, ICommunicator> connections,
            IList<IChat> chats)
        {
            string responseContent = $"{request.From} logged in";
            Response response = ResponseFactory.CreateResponse("SYSTEM",
                responseContent,
                MessageContentType.Text);
            ResponseSender.SendResponse(response, connections);
            string clientName = request.From;
            foreach (var chat in chats)
            {
                //var chatMembersConnections = 
                if (!(chat is GroupChat) || 
                    ((GroupChat)chat).GetMembers().Contains(clientName))
                {
                    var responses = chat.GetChatHistory();
                    foreach (var historyResponse in responses)
                    {
                        ResponseSender.SendResponse(response, connections);
                    }
                }
            }
        }
    }
}
