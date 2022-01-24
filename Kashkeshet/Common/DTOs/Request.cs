using System;

namespace Common.DTOs
{
    [Serializable]
    public class Request
    {
        private readonly RequestType _requestType;
        private readonly Message _message;
        private readonly string _from;

        public Request(RequestType requestType, Message message, string fromWho)
        {
            _requestType = requestType;
            _message = message;
            _from = fromWho;
        }
    }
}
