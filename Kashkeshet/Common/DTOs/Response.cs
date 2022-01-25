using System;

namespace Common.DTOs
{
    [Serializable]
    public class Response
    {
        public readonly string From;
        public readonly object Content;
        public readonly MessageContentType ContentType;

        public Response(string from, object content, MessageContentType contentType)
        {
            From = from;
            Content = content;
            ContentType = contentType;
        }
    }
}
