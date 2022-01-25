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
            IOutputDisplayer outputDisplayer,
            IDictionary<MessageContentType, MessageContentProviderBase> messageContentProviders)
            : base(inputReceiver, outputDisplayer, messageContentProviders)
        {

        }

        protected override string ChooseMessageRecipients()
        {
            OutputDisplayer.DisplayOutput("Please enter recipient: ");
            return InputReceiver.GetInput();
        }
    }
}
