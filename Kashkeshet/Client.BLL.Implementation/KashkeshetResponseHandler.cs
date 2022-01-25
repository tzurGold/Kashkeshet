using Client.BLL.Core;
using Common.Communicators.Abstractions;
using Client.UI.Core;
using Common.DTOs;
using System;

namespace Client.BLL.Implementation
{
    public class KashkeshetResonseHandler : IResponseHandler
    {
        private readonly ICommunicator _communicator;
        private readonly IOutputDisplayer _outputDisplayer;

        public KashkeshetResonseHandler(ICommunicator communicator, IOutputDisplayer outputDisplayer)
        {
            _communicator = communicator;
            _outputDisplayer = outputDisplayer;
        }

        public void HandleResponse()
        {
            while (true)
            {
                Response response = (Response)_communicator.Receive();
                string output = $"{response.From}:{Environment.NewLine}{response.Content}";
                _outputDisplayer.DisplayOutput(output);
            }
        }
    }
}
