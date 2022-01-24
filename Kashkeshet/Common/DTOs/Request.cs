using System;

namespace Common.DTOs
{
    [Serializable]
    public class Request
    {
        private readonly Chat _chat;
        private readonly Message _message;

        public Request(Chat chat, Message message)
        {
            _chat = chat;
            _message = message;
        }
    }
}
