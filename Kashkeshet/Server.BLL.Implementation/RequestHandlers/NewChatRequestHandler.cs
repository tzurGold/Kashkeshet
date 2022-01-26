using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;

namespace Server.BLL.Implementation.RequestHandlers
{
    public class NewChatRequestHandler : IRequestHandler
    {
        public void HandleRequest(Request request,
            IDictionary<string, ICommunicator> connections,
            IList<IChat> chats)
        {
            
        }
    }
}
