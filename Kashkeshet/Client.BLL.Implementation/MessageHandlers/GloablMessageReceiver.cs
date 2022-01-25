using System.Collections.Generic;
using Client.BLL.Core;
using Client.BLL.Core.MessageHandlers;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageHandlers
{
    public class GloablMessageReceiver : CommonMessageReceiverBase
    {
        public GloablMessageReceiver(IInputReceiver inputReceiver,
            IOutputDisplayer outputDisplayer,
            IDictionary<MessageContentType, MessageContentProviderBase> messageContentProviders)
            : base(inputReceiver, outputDisplayer, messageContentProviders)
        {

        }

        protected override string ChooseMessageRecipients()
        {
            string recipients = "Everyone";
            return recipients;
        }
    }
}
