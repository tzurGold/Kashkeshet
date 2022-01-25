using Client.BLL.Core;
using Client.UI.Core;

namespace Client.BLL.Implementation.MessageContentProviders
{
    public class TextMessageProvider : MessageContentProviderBase
    {
        public TextMessageProvider(IInputReceiver inputReceiver) :
            base(inputReceiver)
        {

        }

        public override object ProvideContent()
        {
            return InputReceiver.GetInput("Please enter your message: ");
        }
    }
}
