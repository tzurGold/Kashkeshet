using Client.BLL.Core;
using Common.Communicators.Abstractions;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Implementation
{
    public class KashkeshetResonseHandler : IResponseHandler
    {
        private readonly ICommunicator _communicator;
        private readonly IInputReceiver inputReceiver;

        public KashkeshetResonseHandler(ICommunicator communicator, IInputReceiver inputReceiver)
        {
            _communicator = communicator;
            this.inputReceiver = inputReceiver;
        }

        public void HandleResponse()
        {
            Response response = _communicator.Receive();
        }
    }
}
