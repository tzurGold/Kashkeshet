using Common.Communicators.Abstractions;
using Common.DTOs;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public interface IResponder
    {
        void Respond(IDictionary<string, ICommunicator> receivers, Response response);
    }
}
