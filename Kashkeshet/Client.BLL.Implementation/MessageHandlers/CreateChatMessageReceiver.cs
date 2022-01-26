using System.Collections.Generic;
using Client.BLL.Core.MessageHandlers;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Implementation.MessageHandlers
{
    public class CreateChatMessageReceiver : IMessageReceiver
    {
        private readonly IInputReceiver _inputReceiver;
        private readonly IOutputDisplayer _outputDisplayer;

        public CreateChatMessageReceiver(IInputReceiver inputReceiver,
            IOutputDisplayer outputDisplayer)
        {
            _inputReceiver = inputReceiver;
            _outputDisplayer = outputDisplayer;
        }

        public Message GetMessage()
        {
            string groupName = GetGroupName();
            IList<string> participants = GetParticipants();
            int deletionTime = 0;
            if (IsChatVolatile())
            {
                deletionTime = GetDeletionTime();
            }
            GroupChatInfo groupChatInfo = new GroupChatInfo(deletionTime, participants);
            return new Message(groupName, groupChatInfo, MessageContentType.Text);
        }

        private IList<string> GetParticipants()
        {
            string participant = string.Empty;
            IList<string> participants = new List<string>();
            while (participant != "0")
            {
                _outputDisplayer.DisplayOutput("Please enter participant name: (insert 0 to stop)");
                participant = _inputReceiver.GetInput();
                participants.Add(participant);
            }
            return participants;
        }

        private string GetGroupName()
        {
            _outputDisplayer.DisplayOutput("Please enter group name:");
            return _inputReceiver.GetInput();
        }

        private bool IsChatVolatile()
        {
            _outputDisplayer.DisplayOutput("Is chat volatile? 0 for No, any other key for Yes");
            return _inputReceiver.GetInput() != "0";
        }

        private int GetDeletionTime()
        {
            _outputDisplayer.DisplayOutput("Please enter deletion time in milliseconds:");
            bool validInput = false;
            int deletionTime = 0;
            while (!validInput)
            {
                string input = _inputReceiver.GetInput();
                validInput = int.TryParse(input, out deletionTime);
                if (!validInput)
                {
                    _outputDisplayer.DisplayOutput("Wrong input, Try again");
                }
            }
            return deletionTime;
        }
    }
}
