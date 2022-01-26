using Client.BLL.Core.MessageHandlers;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageHandlers
{
    public class LogoutMessageReceiver : MessageReceiverBase
    {
        public LogoutMessageReceiver(IInputReceiver inputReceiver,
            IOutputDisplayer outputDisplayer)
            : base(inputReceiver, outputDisplayer)
        {
        }

        public override Message GetMessage()
        {
            return new Message("Everyone", "logout", MessageContentType.Text);
        }
    }
}
