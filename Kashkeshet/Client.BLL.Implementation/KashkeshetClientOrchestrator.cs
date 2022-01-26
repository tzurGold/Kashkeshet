using Client.BLL.Core;
using Client.UI.Core;
using System.Collections.Generic;
using Common.DTOs;
using Client.BLL.Core.MessageHandlers;
using System.Threading.Tasks;
using Common.Communicators.Abstractions;

namespace Client.BLL.Implementation
{
    public class KashkeshetClientOrchestrator : IClientOrchestrator
    {
        private readonly IMenuDisplayer _menuDisplayer;
        private readonly IOptionReceiver _optionReceiver;
        private readonly ClientConnectionBase _clientConnection;
        private readonly IRequestFactory _requestFactory;
        private readonly IResponseHandler _responseHandler;
        private readonly ICommunicator _communicator;
        private readonly string _clientName;
        private readonly IDictionary<RequestType, IMessageReceiver> _messageHandlers;

        public KashkeshetClientOrchestrator(IMenuDisplayer menuDisplayer,
            IOptionReceiver optionReceiver,
            ClientConnectionBase clientConnection,
            IRequestFactory requestFactory,
            IResponseHandler responseHandler,
            ICommunicator communicator,
            string clientName,
            IDictionary<RequestType, IMessageReceiver> messageHandlers)
        {
            _menuDisplayer = menuDisplayer;
            _optionReceiver = optionReceiver;
            _clientConnection = clientConnection;
            _requestFactory = requestFactory;
            _responseHandler = responseHandler;
            _communicator = communicator;
            _clientName = clientName;
            _messageHandlers = messageHandlers;
        }

        public void Run()
        {
            Task.Run(() => _responseHandler.HandleResponse());
            RequestType requestType = RequestType.GlobalChat;
            while(requestType != RequestType.Logout)
            {
                _menuDisplayer.DisplayMenu();
                requestType = _optionReceiver.ChooseOption();
                Message message = _messageHandlers[requestType].GetMessage();
                Request request = _requestFactory.CreateRequest(requestType, message, _clientName);
                _communicator.Send(request);
            }
            _clientConnection.CloseConnection();
        }
    }
}
