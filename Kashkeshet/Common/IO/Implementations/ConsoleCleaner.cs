using Common.IO.Abstractions;
using System;

namespace Common.IO.Implementations
{
    public class ConsoleCleaner : ICleaner
    {
        public void Clear()
        {
            Console.Clear();
        }
    }
}
