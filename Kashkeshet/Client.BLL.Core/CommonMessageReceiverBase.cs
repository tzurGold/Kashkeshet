using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Core
{
    public abstract class CommonMessageReceiverBase : MessageReceiverBase
    {
        protected CommonMessageReceiverBase(IInputReceiver inputReceiver) : base(inputReceiver)
        {
        }

        public override Message GetMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}
