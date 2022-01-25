using System;
using System.Collections.Generic;
using Client.BLL.Core;
using Client.BLL.Core.MessageHandlers;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageHandlers
{
    public class CreateChatMessageReceiver : MessageReceiverBase
    {
        public CreateChatMessageReceiver(IInputReceiver inputReceiver,
            IOutputDisplayer outputDisplayer)
            : base(inputReceiver, outputDisplayer)
        {
        }

        public override Message GetMessage()
        {
            string groupName = GetGroupName();
            IList<string> participants = GetParticipants();
            return new Message(groupName, participants, MessageContentType.Text);
        }

        private IList<string> GetParticipants()
        {
            string input = string.Empty;
            IList<string> participants = new List<string>();
            while (input != "0")
            {
                OutputDisplayer.DisplayOutput("Please enter participant name: (insert 0 to stop)");
                participants.Add(InputReceiver.GetInput());
            }
            return participants;
        }

        private string GetGroupName()
        {
            OutputDisplayer.DisplayOutput("Please enter group name: ");
            return InputReceiver.GetInput();
        }
    }
}
