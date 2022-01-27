using Client.BLL.Core.MessageHandlers;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageHandlers
{
    public class LoginMessageReceiver : IMessageReceiver
    {
        public Message GetMessage()
        {
            return new Message("Everyone", "login", MessageContentType.Text);
        }
    }
}
