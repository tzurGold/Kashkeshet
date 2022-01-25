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
                "Logout"
            };
            IOutput<string> writer = new ConsoleWriter();
            IInput<string> reader = new ConsoleReader();
            int port = 8080;
            string ip = "127.0.0.1";
            TcpClient client = new TcpClient();
            MenuDescriptionBase menuDescriptionBase = new KashkeshetMenuDescription(options);
            IOutputDisplayer outputDisplayer = new KashkeshetOutputDisplayer(writer);
            IMenuDisplayer menuDisplayer = new KashkeshetMenuDisplayer(menuDescriptionBase, outputDisplayer);
            IInputReceiver inputReceiver = new KashkeshetInputReceiver(reader);
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
            IDictionary<RequestType, MessageReceiverBase> messageHandlers =
                new Dictionary<RequestType, MessageReceiverBase>
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
                        new LogoutMessageReceiver(inputReceiver, outputDisplayer)
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
