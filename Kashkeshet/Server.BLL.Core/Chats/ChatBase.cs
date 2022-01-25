using System.Collections.Generic;
using Common.DTOs;
using System.Linq;

namespace Server.BLL.Core.Chats
{
    public abstract class ChatBase : IChat
    {
        private Queue<Response> _responses;

        protected ChatBase(Queue<Response> responses)
        {
            _responses = responses;
        }

        public IEnumerable<Response> GetChatHistory()
        {
            return _responses.ToList();
        }

        public void SaveMessage(Response response)
        {
            _responses.Enqueue(response);
        }
    }
}
