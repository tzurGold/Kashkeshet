using Client.BLL.Core;
using Client.BLL.Implementation;
using Client.UI.Core;
using Client.UI.Implementation;
using System.Collections.Generic;
using Common.IO.Abstractions;
using Common.IO.Implementations;
using System.Net.Sockets;
using Common.Communicators.Abstractions;
using Common.Communicators.Implementations;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Common.DTOs;
using Client.BLL.Core.MessageHandlers;
using Client.BLL.Implementation.MessageHandlers;
using Client.BLL.Implementation.MessageContentProviders;
using System.Configuration;

namespace KashkeshetConsoleApp
{
    public class Bootstrapper
    {
        public IClientOrchestrator Initialize()
        {
            IList<string> options = new List<string>
            {
                "Send message in global chat",
                "Send message in private chat",
                "Send message in group chat",
                "Create new group chat",
                "Get your groups list",
                "Logout"
            };
            IOutput<string> writer = new ConsoleWriter();
            IInput<string> reader = new ConsoleReader();
            ICleaner cleaner = new ConsoleCleaner();
            int port = int.Parse(ConfigurationManager.AppSettings["serverPort"]);
            string ip = ConfigurationManager.AppSettings["serverIp"];
            TcpClient client = new TcpClient();
            MenuDescriptionBase menuDescriptionBase = new KashkeshetMenuDescription(options);
            IOutputDisplayer outputDisplayer = new KashkeshetOutputDisplayer(writer);
            IMenuDisplayer menuDisplayer = new KashkeshetMenuDisplayer(menuDescriptionBase, outputDisplayer);
            IInputReceiver inputReceiver = new KashkeshetInputReceiver(reader, cleaner);
            IOptionReceiver optionReceiver = new MenuOptionReceiver(inputReceiver, outputDisplayer);
            ClientConnectionBase clientConnection = new KashkeshetClientConnection(port, ip, client);
            IRequestFactory requestFactory = new KashkeshetRequestFactory();
            IFormatter formatter = new BinaryFormatter();
            outputDisplayer.DisplayOutput("Please enter your name: ");
            string name = inputReceiver.GetInput();
            IDictionary<MessageContentType, MessageContentProviderBase> messageContentProviders =
                new Dictionary<MessageContentType, MessageContentProviderBase>
                {
                    { MessageContentType.Text, new TextMessageProvider(inputReceiver, outputDisplayer) },
                    { MessageContentType.File, new FileMessageProvider(inputReceiver, outputDisplayer) }
                };
            IDictionary<RequestType, IMessageReceiver> messageHandlers =
                new Dictionary<RequestType, IMessageReceiver>
                {
                    {
                        RequestType.GlobalChat,
                        new GloablMessageReceiver(inputReceiver, outputDisplayer, messageContentProviders)
                    },
                    {
                        RequestType.PrivateChat,
                        new DirectMessageReceiver(inputReceiver, outputDisplayer, messageContentProviders)
                    },
                    {
                        RequestType.GroupChat,
                        new DirectMessageReceiver(inputReceiver, outputDisplayer, messageContentProviders)
                    },
                    {
                        RequestType.NewChat,
                        new CreateChatMessageReceiver(inputReceiver, outputDisplayer)
                    },
                    {
                        RequestType.Logout,
                        new LogoutMessageReceiver()
                    },
                    {
                        RequestType.GetGroupsList,
                        new GetGroupsListMessageReceiver()
                    },
                    {
                        RequestType.Login,
                        new LoginMessageReceiver()
                    }
                };
            try
            {
                clientConnection.Connect();
            }
            catch
            {
                clientConnection.CloseConnection();
                return null;
            }
            ICommunicator communicator = new TcpCommunicator(client, formatter);
            IResponseHandler responseHandler = new KashkeshetResonseHandler(communicator, outputDisplayer);
            IClientOrchestrator clientOrchestrator = new KashkeshetClientOrchestrator(menuDisplayer,
                optionReceiver,
                clientConnection,
                requestFactory,
                responseHandler,
                communicator,
                name,
                messageHandlers);
            return clientOrchestrator;
        }
    }
}
