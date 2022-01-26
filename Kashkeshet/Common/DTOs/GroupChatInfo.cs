using System;
using System.Collections.Generic;

namespace Common.DTOs
{
    [Serializable]
    public class GroupChatInfo
    {
        public readonly bool IsVolatile;
        public readonly IList<string> Participants;

        public GroupChatInfo(bool isVolatile, IList<string> participants)
        {
            IsVolatile = isVolatile;
            Participants = participants;
        }
    }
}
