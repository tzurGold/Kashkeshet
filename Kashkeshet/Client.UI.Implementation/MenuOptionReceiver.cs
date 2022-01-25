using Client.UI.Core;
using Common.DTOs;
using System;

namespace Client.UI.Implementation
{
    public class MenuOptionReceiver : IOptionReceiver
    {
        private readonly IInputReceiver _inputReceiver;
        private readonly IOutputDisplayer _outputDisplayer;
        private const string _explanation = "Please enter your choice: ";

        public MenuOptionReceiver(IInputReceiver inputReceiver, IOutputDisplayer outputDisplayer)
        {
            _inputReceiver = inputReceiver;
            _outputDisplayer = outputDisplayer;
        }

        public RequestType ChooseOption()
        {
            bool validInput = false;
            RequestType requestType = RequestType.GlobalChat; 
            while (!validInput)
            {
                _outputDisplayer.DisplayOutput(_explanation);
                string input = _inputReceiver.GetInput();
                validInput = Enum.TryParse(input, out requestType);
            }
            return requestType;
        }
    }
}
