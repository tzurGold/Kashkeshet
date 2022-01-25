using Client.BLL.Core;
using Common.Communicators.Abstractions;
using Client.UI.Core;
using Common.DTOs;

namespace Client.BLL.Implementation
{
    public class KashkeshetResponseHandler : IResponseHandler
    {
        private readonly ICommunicator _communicator;
        private readonly IInputReceiver _inputReceiver;

        public KashkeshetResponseHandler(ICommunicator communicator, IInputReceiver inputReceiver)
        {
            _communicator = communicator;
            _inputReceiver = inputReceiver;
        }

        public void HandleResponse()
        {
            Response response = (Response)_communicator.Receive();
            //_inputReceiver.
        }
    }
}
