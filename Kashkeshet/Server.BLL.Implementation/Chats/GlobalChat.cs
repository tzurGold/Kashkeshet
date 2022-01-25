using System.Collections.Generic;
using Common.DTOs;
using Server.BLL.Core.Chats;

namespace Server.BLL.Implementation.Chats
{
    public class GlobalChat : ChatInMemoryBase
    {
        public GlobalChat(Queue<Response> responses) : base(responses)
        {

        }
    }
}
