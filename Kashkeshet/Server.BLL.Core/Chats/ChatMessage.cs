using Common.DTOs;
using System;

namespace Server.BLL.Core.Chats
{
    public class ChatMessage
    {
        public Response Content;
        public DateTime CreationTime;

        public ChatMessage(Response content, DateTime creationTime)
        {
            Content = content;
            CreationTime = creationTime;
        }
    }
}
