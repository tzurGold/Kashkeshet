using Common.DTOs;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public abstract class ClientHandlerBase
    {
        private IRequestReceiver _requestReceiver;
        private IDictionary<RequestType, IResponder> _responders;

        protected ClientHandlerBase(IRequestReceiver requestReceiver, IDictionary<RequestType, IResponder> responders)
        {
            _requestReceiver = requestReceiver;
            _responders = responders;
        }
    }
}
