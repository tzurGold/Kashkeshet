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
    public class LoginRequestHandler : RequestHandlerBase
    {
        private readonly IConnectionsSelector _connectionsSelector;
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            Response response = ResponseFactory.CreateResponse("GlobalChat",
                "System",
                responseContent,
                MessageContentType.Text);
            _log.InfoFormat("Sending: {0}/{1} to {2} content: {3}",
                response.ChatName,
                response.From,
                request.From,
                response.Content);
            ResponseSender.SendResponse(response, connections);
            string clientName = request.From;
            IList<string> members = new List<string>();
            members.Add(clientName);
            foreach (var chat in chats)
            { 
                if (!(chat is GroupChat) || 
                    ((GroupChat)chat).GetMembers().Contains(clientName))
                {
                    var responses = chat.GetChatHistory();
                    var recipientsConnections = _connectionsSelector.GetRecipientsCommunicators(connections, members);
                    _log.InfoFormat("Sending {0} chat history: ", chat.Name);
                    foreach (var historyResponse in responses)
                    {
                        _log.InfoFormat("{0}/{1}: {2}",
                            historyResponse.ChatName,
                            historyResponse.From,
                            historyResponse.Content);
                        ResponseSender.SendResponse(historyResponse, recipientsConnections);
                    }
                }
            }
        }
    }
}
