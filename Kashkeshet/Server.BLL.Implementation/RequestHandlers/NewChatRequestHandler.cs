using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;
using Server.BLL.Implementation.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class NewChatRequestHandler : RequestHandlerBase
    {
        public NewChatRequestHandler(IResponseFactory responseFactory,
            IResponseSender responseSender)
            : base(responseFactory, responseSender)
        {
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
            IChat groupChat = new GroupChat(new Queue<Response>(), members);
            chats.Add(groupChat);
            //ResponseSender.SendResponse(response, );
        }
    }
}
