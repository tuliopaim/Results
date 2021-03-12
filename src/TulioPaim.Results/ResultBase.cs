using System.Collections.Generic;

namespace TulioPaim.Results
{
    public abstract class ResultBase
    {
        public string Message { get; set; }

        public bool Succeeded { get; set; }

        public List<string> Errors { get; set; }
    }

    public abstract class ResultBase<T> : ResultBase
    {
        public T Data { get; set; }
    }
}
