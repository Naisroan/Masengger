using System;

namespace MasenggerModel
{
    [Serializable]
    public class Request
    {
        public string Key { get; set; }

        public object Value { get; set; }

        public bool IsValueJson { get; set; }

        public bool IsEncripted { get; set; }
    }
}