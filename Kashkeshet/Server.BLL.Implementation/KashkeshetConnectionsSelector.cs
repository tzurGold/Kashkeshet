using System.Collections.Generic;
using System.Reflection;
using Common.Communicators.Abstractions;
using log4net;
using Server.BLL.Core;

namespace Server.BLL.Implementation
{
    public class KashkeshetConnectionsSelector : IConnectionsSelector
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IDictionary<string, ICommunicator> GetRecipientsCommunicators(IDictionary<string, ICommunicator> connections,
            IList<string> recipients)
        {
            _log.Debug("Get recipients communicators");
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
