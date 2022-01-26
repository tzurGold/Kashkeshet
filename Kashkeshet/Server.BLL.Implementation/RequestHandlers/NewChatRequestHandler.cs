using System.Collections.Generic;
using System.Reflection;
using Common.Communicators.Abstractions;
using Common.DTOs;
using log4net;
using Server.BLL.Core;
using Server.BLL.Core.Chats;
using Server.BLL.Implementation.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class NewChatRequestHandler : RequestHandlerBase
    {
        private readonly IConnectionsSelector _connectionsSelector;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public NewChatRequestHandler(IResponseFactory responseFactory,
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
            string chatName = request.ClientMessage.To;
            string responseContent = $"Chat {chatName} created";
            Response response = ResponseFactory.CreateResponse(chatName,
                "System",
                responseContent,
                request.ClientMessage.ContentType);
            _log.InfoFormat("Sending: {0}/{1} to {2} content: {3}",
                response.ChatName,
                response.From,
                request.From,
                response.Content);
            IList<string> members = (IList<string>)request.ClientMessage.Content;
            members.Add(request.From);
            ChatBase groupChat = new GroupChat(chatName, new Queue<Response>(), members);
            chats.Add(groupChat);
            var recipientsConnections = _connectionsSelector.GetRecipientsCommunicators(connections, members);
            ResponseSender.SendResponse(response, recipientsConnections);
        }
    }
}
