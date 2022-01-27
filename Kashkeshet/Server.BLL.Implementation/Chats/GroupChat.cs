using System.Collections.Generic;
using Server.BLL.Core.Chats;
using System.Linq;

namespace Server.BLL.Implementation.Chats
{
    public class GroupChat : ChatInMemoryBase
    {
        private readonly IList<string> _members;
        public GroupChat(string name,
            Queue<ChatMessage> chatMessages,
            IList<string> members)
            : base(name, chatMessages)
        {
            _members = members;
        }

        public IList<string> GetMembers()
        {
            return _members.ToList();
        }
    }
}
