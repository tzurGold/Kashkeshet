using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core.Chats;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public abstract class RequestHandlerBase
    {
        protected readonly IResponseFactory ResponseFactory;
        protected readonly IResponseSender ResponseSender;

        protected RequestHandlerBase(IResponseFactory responseFactory, IResponseSender responseSender)
        {
            ResponseFactory = responseFactory;
            ResponseSender = responseSender;
        }
        
        public abstract void HandleRequest(Request request,
            IDictionary<string, ICommunicator> connections,
            IList<IChat> chats);
    }
}
