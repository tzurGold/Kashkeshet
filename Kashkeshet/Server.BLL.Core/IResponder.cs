using Common.DTOs;

namespace Server.BLL.Core
{
    public interface IResponder
    {
        void respond(Message message, string senderName);
    }
}
