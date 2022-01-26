using System.Collections.Generic;
using Common.Communicators.Abstractions;
using Common.DTOs;
using Server.BLL.Core;

namespace Server.BLL.Implementation
{
    public class KashkeshetResponseSender : IResponseSender
    {
        public void SendResponse(Response response, IDictionary<string, ICommunicator> connections)
        {
            foreach (var client in connections.Keys)
            {
                try
                {
                    connections[client].Send(response);
                }
                catch
                {
                    connections.Remove(client);
                    Response logout = new Response("GlobalChat","System", $"{client} logout", MessageContentType.Text);
                    SendResponse(logout, connections);
                }
            }
        }
    }
}
