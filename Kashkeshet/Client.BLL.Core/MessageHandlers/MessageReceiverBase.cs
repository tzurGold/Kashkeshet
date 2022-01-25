using Client.UI.Core;
using Common.DTOs;
using System.Collections.Generic;

namespace Client.BLL.Core.MessageHandlers
{
    public abstract class MessageReceiverBase
    {
        protected readonly IInputReceiver InputReceiver;
        protected readonly IDictionary<MessageContentType, MessageContentProviderBase> MessageContentProviders;

        protected MessageReceiverBase(IInputReceiver inputReceiver,
            IDictionary<MessageContentType, MessageContentProviderBase> messageContentProviders)
        {
            InputReceiver = inputReceiver;
            MessageContentProviders = messageContentProviders;
        }

        public abstract Message GetMessage();
    }
}
