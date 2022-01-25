using Common.IO.Abstractions;
using System;

namespace Common.IO.Implementations
{
    public class ConsoleWriter : IOutput<string>
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}
