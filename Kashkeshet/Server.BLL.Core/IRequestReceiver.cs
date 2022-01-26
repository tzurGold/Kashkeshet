using Common.DTOs;
using Common.Communicators.Abstractions;

namespace Server.BLL.Core
{
    public interface IRequestReceiver
    {
        Request Receive(ICommunicator communicator);
    }
}
