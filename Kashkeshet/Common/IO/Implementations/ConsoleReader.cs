using Common.IO.Abstractions;
using System;

namespace Common.IO.Implementations
{
    public class ConsoleReader : IInput<string>
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
