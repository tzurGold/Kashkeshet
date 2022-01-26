using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Server.BLL.Core;
using System.Linq;

namespace Server.BLL.Implementation
{
    public class KashkeshetConnectionsSelector : IConnectionsSelector
    {
        public IDictionary<string, ICommunicator> GetRecipientsCommunicators(IDictionary<string, ICommunicator> connections,
            IList<string> recipients)
        {
            if (recipients == null)
            {
                return connections;
            }
            var recipientsConnections = new Dictionary<string, ICommunicator>();
            foreach (var recipient in connections.Keys)
            {
                if (recipients.Contains(recipient))
                {
                    recipientsConnections[recipient] = connections[recipient];
                }
            }
            return recipientsConnections;
        }
    }
}
