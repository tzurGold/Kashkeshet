using System.Collections.Generic;
using Common.DTOs;
using System.Linq;

namespace Server.BLL.Core.Chats
{
    public abstract class ChatInMemoryBase : ChatBase
    {
        private readonly Queue<Response> _responses;

        protected ChatInMemoryBase(string name, Queue<Response> responses) : base(name)
        {
            _responses = responses;
        }

        public override IEnumerable<Response> GetChatHistory()
        {
            return _responses.ToList();
        }

        public override void SaveMessage(Response response)
        {
            _responses.Enqueue(response);
        }
    }
}
