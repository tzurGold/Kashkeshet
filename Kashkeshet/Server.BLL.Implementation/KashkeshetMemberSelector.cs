using System.Collections.Generic;
using Server.BLL.Core;
using Server.BLL.Core.Chats;
using Server.BLL.Implementation.Chats;

namespace Server.BLL.Implementation
{
    public class KashkeshetMemberSelector : IMembersSelector
    {
        public IList<string> GetMembersNames(string to, IChat chat)
        {
            if (to == "Everyone")
            {
                return null;
            }
            IList<string> members = new List<string>();
            if (chat == null)
            {
                members.Add(to);
            }
            else
            {
                members = ((GroupChat)chat).GetMembers();
            }
            return members;
        }
    }
}
