using System;

namespace Common.DTOs
{
    [Serializable]
    public class Request
    {
        public readonly RequestType RequestType;
        public readonly Message ClientMessage;
        public readonly string From;

        public Request(RequestType requestType, Message message, string fromWho)
        {
            RequestType = requestType;
            ClientMessage = message;
            From = fromWho;
        }
    }
}
