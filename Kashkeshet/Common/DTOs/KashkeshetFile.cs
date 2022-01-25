using System;

namespace Common.DTOs
{
    [Serializable]
    public class KashkeshetFile
    {
        private readonly string _name;
        private readonly long _length;
        private readonly string _content;

        public KashkeshetFile(string name, long length, string content)
        {
            _name = name;
            _length = length;
            _content = content;
        }
    }
}
