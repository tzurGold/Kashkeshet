using System;
using System.Collections.Generic;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Core.MessageHandlers
{
    public abstract class CommonMessageReceiverBase : MessageReceiverBase
    {
        protected CommonMessageReceiverBase(IInputReceiver inputReceiver,
            IDictionary<MessageContentType, IMessageContentProvider> messageContentProviders)
            : base(inputReceiver, messageContentProviders)
        {
            
        }

        public override Message GetMessage()
        {
            MessageContentType contentType = GetContentType();
            object content = MessageContentProviders[contentType].ProvideContent();
            return new Message(ChooseMessageRecipients(), content, contentType);
        }

        protected abstract string ChooseMessageRecipients();

        protected virtual MessageContentType GetContentType()
        {
            bool validInput = false;
            string messageToUser = $"1. Send text message{Environment.NewLine}" +
                $"2. Transfer file{Environment.NewLine}" +
                $"Please Enter your choice:";
            MessageContentType contentType = MessageContentType.Text;
            while (!validInput)
            {
                string selectedOption = InputReceiver.GetInput(messageToUser);
                validInput = Enum.TryParse(selectedOption, out contentType);
            }
            return contentType;
        }
    }
}
