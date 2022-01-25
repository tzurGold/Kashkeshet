using Client.UI.Core;
using Common.DTOs;
using System.Collections.Generic;

namespace Client.BLL.Core.MessageHandlers
{
    public abstract class MessageReceiverBase
    {
        protected readonly IInputReceiver InputReceiver;
        protected readonly IOutputDisplayer OutputDisplayer;
        protected readonly IDictionary<MessageContentType, MessageContentProviderBase> MessageContentProviders;

        protected MessageReceiverBase(IInputReceiver inputReceiver,
            IOutputDisplayer outputDisplayer,
            IDictionary<MessageContentType, MessageContentProviderBase> messageContentProviders)
        {
            InputReceiver = inputReceiver;
            OutputDisplayer = outputDisplayer;
            MessageContentProviders = messageContentProviders;
        }

        public abstract Message GetMessage();
    }
}
