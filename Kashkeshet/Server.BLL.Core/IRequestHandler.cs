using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core.Chats;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public interface IRequestHandler
    {
        void HandleRequest(Request request, IDictionary<string, ICommunicator> connections, IList<IChat> chats);
    }
}
