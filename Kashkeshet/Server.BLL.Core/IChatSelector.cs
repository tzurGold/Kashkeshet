using Server.BLL.Core.Chats;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public interface IChatSelector
    {
        ChatBase SelectChat(string chatName, IList<ChatBase> chats);
    }
}
