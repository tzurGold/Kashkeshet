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
            var recipientsConnections = connections;
            foreach (var recipient in recipientsConnections.Keys)
            {
                if (!recipients.Contains(recipient))
                {
                    recipientsConnections.Remove(recipient);
                }
            }
            return recipientsConnections;
        }
    }
}
