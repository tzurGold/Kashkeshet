using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Common.DTOs;
using Server.BLL.Core.Chats;

namespace Server.BLL.Implementation.Chats
{
    public class VolatileGroupChat : GroupChat
    {
        private readonly int _deletionTime;
        private const int SLEEP_TIME = 5000;
        public VolatileGroupChat(string name,
            Queue<ChatMessage> chatMessages,
            IList<string> members,
            int deletionTime)
            : base(name, chatMessages, members)
        {
            _deletionTime = deletionTime;
            Task.Run(() => DeleteMessages());
        }

        private void DeleteMessages()
        {
            while (true)
            {
                ChatMessage chatMessage = GetFirstMessage();
                if (chatMessage != null
                    && chatMessage.CreationTime.AddSeconds(_deletionTime) > DateTime.Now)
                {
                    DeleteMessage();
                }
                Thread.Sleep(SLEEP_TIME);
            }
        }
    }
}
