using Client.UI.Core;

namespace Client.UI.Implementation
{
    public class KashkeshetMenuDisplayer : IMenuDisplayer
    {
        private readonly MenuDescriptionBase _menuDescription;
        private readonly IOutputDisplayer _outputDisplayer;

        public KashkeshetMenuDisplayer(MenuDescriptionBase menuDescription,
            IOutputDisplayer outputDisplayer)
        {
            _menuDescription = menuDescription;
            _outputDisplayer = outputDisplayer;
        }

        public void DisplayMenu()
        {
            var menu = _menuDescription.GetDescription();
            foreach (var option in menu)
            {
                _outputDisplayer.DisplayOutput($"{option.Key}. {option.Value}");
            }
        }
    }
}
