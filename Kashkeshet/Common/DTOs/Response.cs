using System;

namespace Common.DTOs
{
    [Serializable]
    public class Response
    {
        private readonly string _from;
        private readonly object _content;
        private readonly MessageContentType _contentType;

        public Response(string from, object content, MessageContentType contentType)
        {
            _from = from;
            _content = content;
            _contentType = contentType;
        }
    }
}
