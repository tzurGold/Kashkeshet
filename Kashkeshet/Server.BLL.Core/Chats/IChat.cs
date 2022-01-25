using Common.DTOs;
using System.Collections.Generic;

namespace Server.BLL.Core.Chats
{
    public interface IChat
    {
        void SaveMessage(Response response);

        IEnumerable<Response> GetChatHistory(); 
    }
}
