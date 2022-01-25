using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Core
{
    public abstract class MessageReceiverBase
    {
        protected readonly IInputReceiver InputReceiver;

        protected MessageReceiverBase(IInputReceiver inputReceiver)
        {
            InputReceiver = inputReceiver;
        }

        public abstract Message GetMessage();
        protected abstract string ChooseMessageRecipients();
    }
}
