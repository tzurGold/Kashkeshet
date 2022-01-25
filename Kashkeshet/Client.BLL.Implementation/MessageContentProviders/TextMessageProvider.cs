using Client.BLL.Core;
using Client.UI.Core;

namespace Client.BLL.Implementation.MessageContentProviders
{
    public class TextMessageProvider : MessageContentProviderBase
    {
        public TextMessageProvider(IInputReceiver inputReceiver, IOutputDisplayer outputDisplayer) :
            base(inputReceiver, outputDisplayer)
        {

        }

        public override object ProvideContent()
        {
            OutputDisplayer.DisplayOutput("Please enter your message: ");
            return InputReceiver.GetInput();
        }
    }
}
