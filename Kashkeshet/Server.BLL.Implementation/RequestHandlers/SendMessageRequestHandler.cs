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
        private readonly IChatSelector _chatSelector;
        private readonly IMembersSelector _membersSelector;

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
            Response response = ResponseFactory.CreateResponse(request.From,
                request.ClientMessage.Content,
                request.ClientMessage.ContentType);
            ChatBase chat = _chatSelector.SelectChat(request.ClientMessage.To, chats);
            chat?.SaveMessage(response);
            IList<string> members = _membersSelector.GetMembersNames(request.ClientMessage.To, chat);
            var recipientsConnections = _connectionsSelector.GetRecipientsCommunicators(connections, members);
            ResponseSender.SendResponse(response, recipientsConnections);
        }
    }
}
