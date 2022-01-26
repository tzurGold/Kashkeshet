using System.Collections.Generic;
using System.Reflection;
using Common.Communicators.Abstractions;
using Common.DTOs;
using log4net;
using Server.BLL.Core;

namespace Server.BLL.Implementation
{
    public class KashkeshetResponseSender : IResponseSender
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void SendResponse(Response response, IDictionary<string, ICommunicator> connections)
        {
            _log.Debug("Send response to clients");
            foreach (var client in connections.Keys)
            {
                try
                {
                    connections[client].Send(response);
                }
                catch
                {
                    _log.InfoFormat("client: {0} disconnected", client);
                    connections.Remove(client);
                    Response logout = new Response("GlobalChat","System", $"{client} logout", MessageContentType.Text);
                    SendResponse(logout, connections);
                }
            }
        }
    }
}
