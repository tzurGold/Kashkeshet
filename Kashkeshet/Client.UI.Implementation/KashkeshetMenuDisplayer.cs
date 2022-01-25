using Client.UI.Core;
using Common.IO;

namespace Client.UI.Implementation
{
    public class KashkeshetMenuDisplayer : IMenuDisplayer
    {
        private readonly MenuDescriptionBase _menuDescription;
        private readonly IOutput<string> _output;

        public KashkeshetMenuDisplayer(MenuDescriptionBase menuDescription,
            IOutput<string> output)
        {
            _menuDescription = menuDescription;
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
