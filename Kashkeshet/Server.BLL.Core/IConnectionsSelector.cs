using Common.Communicators.Abstractions;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public interface IConnectionsSelector
    {
        IDictionary<string, ICommunicator> GetRecipientsCommunicators(IDictionary<string, ICommunicator> connections,
            IList<string> recipients);
    }
}
