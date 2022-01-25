using Client.UI.Core;
using Common.IO.Abstraction;

namespace Client.UI.Implementation
{
    public class KashkeshetOutputDisplayer : IOutputDisplayer
    {
        private readonly IOutput<string> _writer;

        public KashkeshetOutputDisplayer(IOutput<string> writer)
        {
            _writer = writer;
        }

        public void DisplayOutput(string output)
        {
            _writer.Write(output);
        }
    }
}
