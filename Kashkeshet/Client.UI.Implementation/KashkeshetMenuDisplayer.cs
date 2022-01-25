using Client.UI.Core;
using Common.IO;

namespace Client.UI.Implementation
{
    public class KashkeshetMenuDisplayer : IMenuDisplayer
    {
        private MenuDescriptionBase _menuDescription;
        private IInput<string> _reader;
        private IOutput<string> _output;

        public KashkeshetMenuDisplayer(MenuDescriptionBase menuDescription,
            IInput<string> reader,
            IOutput<string> output)
        {
            _reader = reader;
            _output = output;
        }

        public void DisplayMenu()
        {
            var menu = _menuDescription.GetDescription();
            foreach (var option in menu)
            {
                _output.Write($"{option.Key}. {option.Value}");
            }
        }
    }
}
