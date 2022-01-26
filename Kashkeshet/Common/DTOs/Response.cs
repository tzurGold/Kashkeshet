using System;

namespace Common.DTOs
{
    [Serializable]
    public class Response
    {
        public readonly string ChatName;
        public readonly string From;
        public readonly object Content;
        public readonly MessageContentType ContentType;

        public Response(string chatName, string from, object content, MessageContentType contentType)
        {
            ChatName = chatName;
            From = from;
            Content = content;
            ContentType = contentType;
        }
    }
}
