using Client.UI.Core;
using Common.IO;

namespace Client.UI.Implementation
{
    public class KashkeshetInputReceiver : IInputReceiver
    {
        private readonly IInput<string> _reader;
        private readonly IOutput<string> _writer;

        public KashkeshetInputReceiver(IInput<string> reader, IOutput<string> writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public string GetInput(string messageToUser)
        {
            _writer.Write(messageToUser);
            string input = _reader.Read();
            return input;
        }
    }
}
