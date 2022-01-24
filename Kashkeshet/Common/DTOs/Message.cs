using System;

namespace Common.DTOs
{
    [Serializable]
    public class Message
    {
        private readonly string _to; 
        private readonly object _content;
        private  readonly MessageContentType _contentType;

        public Message(string to, object content, MessageContentType contentType)
        {
            _to = to;
            _content = content;
            _contentType = contentType;
        }
    }
}
