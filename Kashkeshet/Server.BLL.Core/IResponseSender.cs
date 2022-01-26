using Common.Communicators.Abstractions;
using Common.DTOs;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public interface IResponseSender
    {
        void SendResponse(Response response, IDictionary<string, ICommunicator> connections);
    }
}
