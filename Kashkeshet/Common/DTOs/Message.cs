using System;

namespace Common.DTOs
{
    [Serializable]
    public class Message
    {
        public readonly string To; 
        public readonly object Content;
        public readonly MessageContentType ContentType;

        public Message(string to, object content, MessageContentType contentType)
        {
            To = to;
            Content = content;
            ContentType = contentType;
        }
    }
}
