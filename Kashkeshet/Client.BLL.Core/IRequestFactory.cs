using Common.DTOs;

namespace Client.BLL.Core
{
    public interface IRequestFactory
    {
        Request CreateRequest(Chat chat, Message message);
    }
}
