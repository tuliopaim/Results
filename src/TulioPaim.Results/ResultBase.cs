using System.Collections.Generic;

namespace TulioPaim.Results
{
    public abstract class ResultBase
    {
        protected ResultBase()
        {
            Errors = new List<string>();
        }

        protected ResultBase(string error, string message = null) : base()
        {
            Succeeded = false;
            Errors = new List<string>() { error };
            Message = message;
        }

        protected ResultBase(List<string> errors, string message = null) : base()
        {
            Succeeded = false;
            Errors = errors ?? new List<string>();
            Message = message;
        }

        public string Message { get; set; }

        public bool Succeeded { get; set; }

        public List<string> Errors { get; set; }

    }

    public abstract class ResultBase<T> : ResultBase
    {
        protected ResultBase() : base()
        {
        }

        protected ResultBase(string error, string message = null) : base(error, message)
        {
        }

        protected ResultBase(List<string> errors, string message = null) : base(errors, message)
        {
        }

        protected ResultBase(T data, string message = null) : base()
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }

        public T Data { get; set; }

    }
}
