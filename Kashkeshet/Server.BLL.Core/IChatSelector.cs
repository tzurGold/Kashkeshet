using Server.BLL.Core.Chats;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public interface IChatSelector
    {
        ChatBase SelectChat(IList<ChatBase> chats);
    }
}
