using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;
using Server.BLL.Implementation.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class LoginRequestHandler : IRequestHandler
    {
        private readonly IResponseSender _responseSender;

        public LoginRequestHandler(IResponseSender responseSender)
        {
            _responseSender = responseSender;
        }

        public void HandleRequest(Request request,
            IDictionary<string, ICommunicator> connections,
            IList<IChat> chats)
        {
            string responseContent = $"{request.From} logged in";
            Response response = new Response("SYSTEM",
                responseContent,
                MessageContentType.Text);
            _responseSender.SendResponse(response, connections);
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
                        _responseSender.SendResponse(response, connections);
                    }
                }
            }
        }
    }
}
