using Client.UI.Core;

namespace Client.BLL.Core
{
    public abstract class MessageContentProviderBase
    {
        protected readonly IInputReceiver InputReceiver;

        protected MessageContentProviderBase(IInputReceiver inputReceiver)
        {
            InputReceiver = inputReceiver;
        }

        public abstract object ProvideContent();
    }
}
