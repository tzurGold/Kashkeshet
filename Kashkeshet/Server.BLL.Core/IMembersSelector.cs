using Server.BLL.Core.Chats;
using System.Collections.Generic;

namespace Server.BLL.Core
{
    public interface IMembersSelector
    {
        IList<string> GetMembersNames(string to, ChatBase chat);
    }
}
