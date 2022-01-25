using Common.DTOs;

namespace Server.BLL.Core
{
    public interface IResponder
    {
        void Respond(Message message, string senderName);
    }
}
