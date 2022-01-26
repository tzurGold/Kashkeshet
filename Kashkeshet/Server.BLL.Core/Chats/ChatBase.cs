using Common.DTOs;
using System.Collections.Generic;

namespace Server.BLL.Core.Chats
{
    public abstract class ChatBase
    {
        public readonly string Name;

        protected ChatBase(string name)
        {
            Name = name;
        }

        public abstract void SaveMessage(Response response);

        public abstract IEnumerable<Response> GetChatHistory(); 
    }
}
