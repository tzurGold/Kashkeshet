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

        public override string ToString()
        {
            string result = $"File name: {Name}{Environment.NewLine}" +
                $"Legth: {Length}{Environment.NewLine}" +
                $"Content: {Content}";
            return result;
        }
    }
}
