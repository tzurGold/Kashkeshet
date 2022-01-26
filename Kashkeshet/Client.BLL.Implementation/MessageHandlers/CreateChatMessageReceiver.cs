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
            return new Message(groupName, participants, MessageContentType.Text);
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
            _outputDisplayer.DisplayOutput("Please enter group name: ");
            return _inputReceiver.GetInput();
        }
    }
}
