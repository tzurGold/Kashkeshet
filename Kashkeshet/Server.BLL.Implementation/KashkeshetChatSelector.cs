using System.Collections.Generic;
using Server.BLL.Core;
using Server.BLL.Core.Chats;
using System.Linq;

namespace Server.BLL.Implementation
{
    public class KashkeshetChatSelector : IChatSelector
    {
        public ChatBase SelectChat(string chatName, IList<ChatBase> chats)
        {
            return chats.Where(chat => chat.Name == chatName).First();
        }
    }
}
