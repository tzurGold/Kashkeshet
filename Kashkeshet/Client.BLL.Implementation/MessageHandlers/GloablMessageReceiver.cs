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
            IDictionary<MessageContentType, IMessageContentProvider> messageContentProviders)
            : base(inputReceiver, messageContentProviders)
        {

        }

        protected override string ChooseMessageRecipients()
        {
            string recipients = "Everyone";
            return recipients;
        }
    }
}
