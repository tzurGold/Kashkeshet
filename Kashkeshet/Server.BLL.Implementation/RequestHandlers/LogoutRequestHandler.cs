using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class LogoutRequestHandler : RequestHandlerBase
    {
        public LogoutRequestHandler(IResponseFactory responseFactory,
            IResponseSender responseSender)
            : base(responseFactory, responseSender)
        {

        }

        public override void HandleRequest(Request request,
            IDictionary<string, ICommunicator> connections,
            IList<ChatBase> chats)
        {
            string responseContent = $"{request.From} {request.ClientMessage.Content}";
            Response response = ResponseFactory.CreateResponse("SYSTEM",
                responseContent,
                request.ClientMessage.ContentType);
            connections.Remove(request.From);
            ResponseSender.SendResponse(response, connections);
        }
    }
}
