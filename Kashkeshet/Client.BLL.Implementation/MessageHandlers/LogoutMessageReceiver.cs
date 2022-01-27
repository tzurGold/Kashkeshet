using Client.BLL.Core.MessageHandlers;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageHandlers
{
    public class LogoutMessageReceiver : IMessageReceiver
    {
        public Message GetMessage()
        {
            return new Message("Everyone", "logout", MessageContentType.Text);
        }
    }
}
