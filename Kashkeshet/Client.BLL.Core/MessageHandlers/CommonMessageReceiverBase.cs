using System;
using System.Collections.Generic;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Core.MessageHandlers
{
    public abstract class CommonMessageReceiverBase : MessageReceiverBase
    {
        protected readonly IDictionary<MessageContentType, MessageContentProviderBase> MessageContentProviders;

        protected CommonMessageReceiverBase(IInputReceiver inputReceiver,
            IOutputDisplayer outputDisplayer,
            IDictionary<MessageContentType, MessageContentProviderBase> messageContentProviders)
            : base(inputReceiver, outputDisplayer)
        {
            MessageContentProviders = messageContentProviders;
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
            string messageToUser = $"1. Send text message {Environment.NewLine}" +
                $"2. Transfer file {Environment.NewLine}" +
                $"Please Enter your choice:";
            MessageContentType contentType = MessageContentType.Text;
            while (!validInput)
            {
                OutputDisplayer.DisplayOutput(messageToUser);
                string selectedOption = InputReceiver.GetInput();
                validInput = Enum.TryParse(selectedOption, out contentType);
            }
            return contentType;
        }
    }
}
