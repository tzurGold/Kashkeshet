﻿using Common.DTOs;
using Server.BLL.Core;
using Server.BLL.Core.Chats;
using Server.BLL.Implementation;
using Server.BLL.Implementation.RequestHandlers;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server.Application
{
    public class Bootstrapper
    {
        public ServerBase Initialize()
        {
            int port = 8080;
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            IRequestReceiver requestReceiver = new KashkeshetRequestReceiver();
            IResponseFactory responseFactory = new KashkeshetResponseFactory();
            IResponseSender responseSender = new KashkeshetResponseSender();
            IConnectionsSelector connectionsSelector = new KashkeshetConnectionsSelector();
            IMembersSelector membersSelector = new KashkeshetMemberSelector();
            IChatSelector chatSelector = null;
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
                    }
                };
            IList<IChat> chats = new List<IChat>();
            ClientHandlerBase clientHandler = new KashkeshetClientHandler(requestReceiver, requestHandlers, chats);
            IFormatter formatter = new BinaryFormatter();
            ServerBase serverBase = new KashkeshetServer(port, iPAddress, clientHandler, formatter);
            return serverBase;
        }
    }
}
