using System.Collections.Generic;
using Common.DTOs;
using System.Linq;
using System;

namespace Server.BLL.Core.Chats
{
    public abstract class ChatInMemoryBase : ChatBase
    {
        private readonly Queue<ChatMessage> _chatMessages;

        protected ChatInMemoryBase(string name, Queue<ChatMessage> chatMessages) : base(name)
        {
            _chatMessages = chatMessages;
        }

        public override IEnumerable<Response> GetChatHistory()
        {
            IList<Response> messagesContents = new List<Response>();
            foreach (var chatMessage in _chatMessages)
            {
                messagesContents.Add(chatMessage.Content);
            }
            return messagesContents;
        }

        public override void SaveMessage(Response response)
        {
            ChatMessage chatMessage = new ChatMessage(response, DateTime.Now);
            _chatMessages.Enqueue(chatMessage);
        }

        protected void DeleteMessage()
        {
            if (_chatMessages.Count != 0)
            {
                _chatMessages.Dequeue();
            }
        }

        protected ChatMessage GetFirstMessage()
        {
            ChatMessage chatMessage = null;
            if (_chatMessages.Count != 0)
            {
                chatMessage = _chatMessages.Peek();
            }
            return chatMessage;
        }
    }
}
