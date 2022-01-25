using System.Collections.Generic;
using System.Linq;
using Client.UI.Core;

namespace Client.UI.Implementation
{
    public class KashkeshetMenuDescription : MenuDescriptionBase
    {
        public KashkeshetMenuDescription(IList<string> options) : base(options)
        {

        }

        public override IDictionary<int, string> GetDescription()
        {
            int i = 0;
            return Options.ToDictionary(option => ++i);
        }
    }
}
