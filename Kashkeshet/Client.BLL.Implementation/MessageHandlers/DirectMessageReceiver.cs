using System.Collections.Generic;
using Client.BLL.Core;
using Client.BLL.Core.MessageHandlers;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageHandlers
{
    public class DirectMessageReceiver : CommonMessageReceiverBase
    {
        public DirectMessageReceiver(IInputReceiver inputReceiver,
            IDictionary<MessageContentType, MessageContentProviderBase> messageContentProviders)
            : base(inputReceiver, messageContentProviders)
        {

        }

        protected override string ChooseMessageRecipients()
        {
            return InputReceiver.GetInput("Please enter recipient: ");
        }
    }
}
