using System;

namespace Common.DTOs
{
    [Serializable]
    public enum RequestType
    {
        GlobalChat = 0,
        PrivateChat = 1,
        GroupChat = 2,
        NewChat = 3,
        Logout = 4
    }
}
