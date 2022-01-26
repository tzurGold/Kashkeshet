using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Core.MessageHandlers
{
    public abstract class MessageReceiverBase
    {
        protected readonly IInputReceiver InputReceiver;
        protected readonly IOutputDisplayer OutputDisplayer;

        protected MessageReceiverBase(IInputReceiver inputReceiver,
            IOutputDisplayer outputDisplayer)
        {
            InputReceiver = inputReceiver;
            OutputDisplayer = outputDisplayer;
        }

        public abstract Message GetMessage();
    }
}
