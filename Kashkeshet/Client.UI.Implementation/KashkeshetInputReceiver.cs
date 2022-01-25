using Client.UI.Core;
using Common.IO.Abstractions;

namespace Client.UI.Implementation
{
    public class KashkeshetInputReceiver : IInputReceiver
    {
        private readonly IInput<string> _reader;

        public KashkeshetInputReceiver(IInput<string> reader)
        {
            _reader = reader;
        }

        public string GetInput()
        {
            return _reader.Read();
        }
    }
}
