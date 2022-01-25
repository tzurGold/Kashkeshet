using Client.BLL.Core;
using Common.DTOs;

namespace Client.BLL.Implementation
{
    public class KashkeshetRequestFactory : IRequestFactory
    {
        public Request CreateRequest(RequestType requestType, Message message, string fromWho)
        {
            return new Request(requestType, message, fromWho);
        }
    }
}
