using Client.UI.Core;

namespace Client.BLL.Core
{
    public abstract class MessageContentProviderBase
    {
        protected readonly IInputReceiver InputReceiver;
        protected readonly IOutputDisplayer OutputDisplayer;

        protected MessageContentProviderBase(IInputReceiver inputReceiver, IOutputDisplayer outputDisplayer)
        {
            InputReceiver = inputReceiver;
            OutputDisplayer = outputDisplayer;
        }

        public abstract object ProvideContent();
    }
}
