using System.Collections.Generic;

namespace Client.UI.Core
{
    public abstract class MenuDescriptionBase
    {
        protected IList<string> Options;

        protected MenuDescriptionBase(IList<string> options)
        {
            Options = options;
        }

        public abstract IDictionary<int, string> GetDescription();
    }
}
