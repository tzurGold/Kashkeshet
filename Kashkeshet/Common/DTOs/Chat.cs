using System;

namespace Common.DTOs
{
    [Serializable]
    public enum Chat
    {
        GlobalChat = 0,
        PrivateChat = 1,
        GroupChat = 2
    }
}
