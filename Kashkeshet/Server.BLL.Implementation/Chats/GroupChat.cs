using System.Collections.Generic;
using Common.DTOs;
using Server.BLL.Core.Chats;
using System.Linq;

namespace Server.BLL.Implementation.Chats
{
    public class GroupChat : ChatInMemoryBase
    {
        private readonly IList<string> _members;
        public GroupChat(Queue<Response> responses, IList<string> members) : base(responses)
        {
            _members = members;
        }

        public IList<string> GetMembers()
        {
            return _members.ToList();
        }
    }
}
