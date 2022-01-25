using System;

namespace Common.DTOs
{
    [Serializable]
    public class KashkeshetFile
    {
        public readonly string Name;
        public readonly long Length;
        public readonly string Content;

        public KashkeshetFile(string name, long length, string content)
        {
            Name = name;
            Length = length;
            Content = content;
        }
    }
}
