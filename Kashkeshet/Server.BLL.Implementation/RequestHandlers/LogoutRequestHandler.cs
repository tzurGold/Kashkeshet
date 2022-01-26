using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class LogoutRequestHandler : IRequestHandler
    {
        private readonly IResponseSender _responseSender;

        public LogoutRequestHandler(IResponseSender responseSender)
        {
            _responseSender = responseSender;
        }

        public void HandleRequest(Request request,
            IDictionary<string, ICommunicator> connections,
            IList<IChat> chats)
        {
            Response response = new Response(request.From,
                request.ClientMessage.Content,
                request.ClientMessage.ContentType);
            connections.Remove(request.From);
            _responseSender.SendResponse(response, connections);
        }
    }
}
