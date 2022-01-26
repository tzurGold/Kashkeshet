using System.Collections.Generic;
using System.Reflection;
using Common.Communicators.Abstractions;
using Common.DTOs;
using log4net;
using Server.BLL.Core;
using Server.BLL.Core.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class SendMessageRequestHandler : RequestHandlerBase
    {
        private readonly IConnectionsSelector _connectionsSelector;
        private readonly IChatSelector _chatSelector;
        private readonly IMembersSelector _membersSelector;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public SendMessageRequestHandler(IResponseFactory responseFactory,
            IResponseSender responseSender,
            IConnectionsSelector connectionsSelector,
            IChatSelector chatSelector,
            IMembersSelector membersSelector)
            : base(responseFactory, responseSender)
        {
            _connectionsSelector = connectionsSelector;
            _chatSelector = chatSelector;
            _membersSelector = membersSelector;
        }

        public override void HandleRequest(Request request,
            IDictionary<string, ICommunicator> connections,
            IList<ChatBase> chats)
        {
            ChatBase chat = _chatSelector.SelectChat(request.ClientMessage.To, chats);
            string chatName = chat == null ? "PrivateMessage" : chat.Name;
            Response response = ResponseFactory.CreateResponse(chatName,
                request.From,
                request.ClientMessage.Content,
                request.ClientMessage.ContentType);
            _log.InfoFormat("Sending: {0}/{1} to {2} content: {3}",
                response.ChatName,
                response.From,
                request.From,
                response.Content);
            chat?.SaveMessage(response);
            IList<string> members = _membersSelector.GetMembersNames(request.ClientMessage.To, chat);
            var recipientsConnections = _connectionsSelector.GetRecipientsCommunicators(connections, members);
            ResponseSender.SendResponse(response, recipientsConnections);
        }
    }
}
