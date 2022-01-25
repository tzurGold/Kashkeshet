using Client.UI.Core;
using Common.DTOs;
using System;

namespace Client.UI.Implementation
{
    public class MenuOptionReceiver : IOptionReceiver
    {
        private readonly IInputReceiver _inputReceiver;
        private const string _explanation = "Please enter your choice: ";

        public MenuOptionReceiver(IInputReceiver inputReceiver)
        {
            _inputReceiver = inputReceiver;
        }

        public RequestType ChooseOption()
        {
            bool validInput = false;
            RequestType requestType = RequestType.GlobalChat; 
            while (!validInput)
            {
                string input = _inputReceiver.GetInput(_explanation);
                validInput = Enum.TryParse(input, out requestType);
            }
            return requestType;
        }
    }
}
