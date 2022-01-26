using System;
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
    public class GetGroupsListRequestHandler : RequestHandlerBase
    {
        private readonly IConnectionsSelector _connectionsSelector;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public GetGroupsListRequestHandler(IResponseFactory responseFactory,
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
            string clientName = request.From;
            IList<string> groupsList = new List<string>();
            foreach (var chat in chats)
            {
                if (chat is GroupChat && ((GroupChat)chat).GetMembers().Contains(clientName))
                {
                    groupsList.Add(chat.Name);
                }
            }
            string responseContent = string.Join(", ", groupsList);
            if (groupsList.Count == 0)
            {
                responseContent = "You are not member in any group";
            }
            _log.DebugFormat("groups list: {0}", responseContent);
            Response response = ResponseFactory.CreateResponse("PrivateMessage",
                "System",
                responseContent,
                MessageContentType.Text);
            _log.InfoFormat("Sending: {0}/{1} to {2} content: {3}",
                response.ChatName,
                response.From,
                request.From,
                response.Content);
            IList<string> connectionsNamesList = new List<string>();
            connectionsNamesList.Add(clientName);
            var clientConnection = _connectionsSelector.GetRecipientsCommunicators(connections, connectionsNamesList);
            ResponseSender.SendResponse(response, clientConnection);
        }
    }
}
