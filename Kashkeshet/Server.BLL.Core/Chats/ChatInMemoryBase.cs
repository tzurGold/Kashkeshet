using System.Collections.Generic;
using Common.DTOs;
using System.Linq;

namespace Server.BLL.Core.Chats
{
    public abstract class ChatInMemoryBase : IChat
    {
        private readonly Queue<Response> _responses;

        protected ChatInMemoryBase(Queue<Response> responses)
        {
            _responses = responses;
        }

        public virtual IEnumerable<Response> GetChatHistory()
        {
            return _responses.ToList();
        }

        public virtual void SaveMessage(Response response)
        {
            _responses.Enqueue(response);
        }
    }
}
