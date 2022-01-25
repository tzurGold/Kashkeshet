using System;

namespace Common.DTOs
{
    [Serializable]
    public enum RequestType
    {
        GlobalChat = 1,
        PrivateChat = 2,
        GroupChat = 3,
        NewChat = 4,
        Logout = 5
    }
}
