using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;
using Server.BLL.Implementation;
using Server.BLL.Implementation.Chats;
using Server.BLL.Implementation.RequestHandlers;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using log4net;
using System.Reflection;

namespace Server.Application
{
    public class Bootstrapper
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public ServerBase Initialize()
        {
            _log.Debug("Initialization starts");
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);
            IPAddress iPAddress = IPAddress.Parse(ConfigurationManager.AppSettings["ip"]);
            IRequestReceiver requestReceiver = new KashkeshetRequestReceiver();
            IResponseFactory responseFactory = new KashkeshetResponseFactory();
            IResponseSender responseSender = new KashkeshetResponseSender();
            IConnectionsSelector connectionsSelector = new KashkeshetConnectionsSelector();
            IMembersSelector membersSelector = new KashkeshetMemberSelector();
            IChatSelector chatSelector = new KashkeshetChatSelector();
            RequestHandlerBase sendMessageRequestHandler = 
                new SendMessageRequestHandler(responseFactory,
                responseSender,
                connectionsSelector,
                chatSelector,
                membersSelector);
            IDictionary<RequestType, RequestHandlerBase> requestHandlers =
                new Dictionary<RequestType, RequestHandlerBase>()
                {
                    {
                        RequestType.Login,
                        new LoginRequestHandler(responseFactory, responseSender, connectionsSelector)
                    },
                    {
                        RequestType.Logout,
                        new LogoutRequestHandler(responseFactory, responseSender)
                    },
                    {
                        RequestType.GlobalChat,
                        sendMessageRequestHandler
                    },
                    {
                        RequestType.PrivateChat,
                        sendMessageRequestHandler
                    },
                    {
                        RequestType.GroupChat,
                        sendMessageRequestHandler
                    },
                    {
                        RequestType.NewChat,
                        new NewChatRequestHandler(responseFactory, responseSender, connectionsSelector)
                    },
                    {
                        RequestType.GetGroupsList,
                        new GetGroupsListRequestHandler(responseFactory, responseSender, connectionsSelector)
                    }
                };
            IList<ChatBase> chats = new List<ChatBase>();
            var globalChat = new GlobalChat("Everyone", new Queue<Response>());
            chats.Add(globalChat);
            ClientHandlerBase clientHandler = new KashkeshetClientHandler(requestReceiver, requestHandlers, chats);
            IFormatter formatter = new BinaryFormatter();
            ServerBase serverBase = new KashkeshetServer(port, iPAddress, clientHandler, formatter);
            return serverBase;
        }
    }
}
