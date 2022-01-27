using System;
using System.Collections.Generic;

namespace Common.DTOs
{
    [Serializable]
    public class GroupChatInfo
    {
        public readonly int DeletionTime;
        public readonly IList<string> Participants;

        public GroupChatInfo(int deletionTime, IList<string> participants)
        {
            DeletionTime = deletionTime;
            Participants = participants;
        }

        public override string ToString()
        {
            string result = $"DeletionTime: {DeletionTime}, Participants: {string.Join(", ", Participants)}";
            return result;
        }
    }
}
