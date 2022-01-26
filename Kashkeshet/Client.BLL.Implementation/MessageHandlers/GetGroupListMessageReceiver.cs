using Client.BLL.Core.MessageHandlers;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageHandlers
{
    public class GetGroupListMessageReceiver : IMessageReceiver
    {
        public Message GetMessage()
        {
            return new Message("Server", "Please send groups list", MessageContentType.Text);
        }
    }
}
