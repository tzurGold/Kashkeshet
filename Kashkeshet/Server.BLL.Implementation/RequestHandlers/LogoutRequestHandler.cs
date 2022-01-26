using System.Collections.Generic;
using System.Reflection;
using Common.Communicators.Abstractions;
using Common.DTOs;
using log4net;
using Server.BLL.Core;
using Server.BLL.Core.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class LogoutRequestHandler : RequestHandlerBase
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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
            Response response = ResponseFactory.CreateResponse("GloabalChat",
                "System",
                responseContent,
                request.ClientMessage.ContentType);
            _log.InfoFormat("Sending: {0}/{1} to {2} content: {3}",
                response.ChatName,
                response.From,
                request.From,
                response.Content);
            connections.Remove(request.From);
            ResponseSender.SendResponse(response, connections);
        }
    }
}
