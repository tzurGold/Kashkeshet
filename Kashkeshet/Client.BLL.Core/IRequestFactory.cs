using Common.DTOs;

namespace Client.BLL.Core
{
    public interface IRequestFactory
    {
        Request CreateRequest(RequestType requestType, Message message, string fromWho);
    }
}
