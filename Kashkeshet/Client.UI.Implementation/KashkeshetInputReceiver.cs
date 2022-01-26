using Client.UI.Core;
using Common.IO.Abstractions;

namespace Client.UI.Implementation
{
    public class KashkeshetInputReceiver : IInputReceiver
    {
        private readonly IInput<string> _reader;
        private readonly ICleaner _cleaner;

        public KashkeshetInputReceiver(IInput<string> reader, ICleaner cleaner)
        {
            _reader = reader;
            _cleaner = cleaner;
        }

        public string GetInput()
        { 
            string input = _reader.Read();
            _cleaner.Clear();
            return input;
        }
    }
}
