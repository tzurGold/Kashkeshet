using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Core.MessageHandlers
{
    public interface IMessageReceiver
    {
        Message GetMessage();
    }
}
