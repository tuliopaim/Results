using System;
using System.Collections.Generic;

namespace TulioPaim.Results
{
    public abstract class ResultBase
    {
        protected ResultBase()
        {
            Errors = new List<string>();
        }

        protected ResultBase(string error, string message = null)
        {
            Succeeded = false;
            Errors = new List<string>() { error };
            Message = message;
        }

        protected ResultBase(List<string> errors, string message = null)
        {
            Succeeded = false;
            Errors = errors ?? new List<string>();
            Message = message;
        }

        protected ResultBase(Exception exception)
        {
            AddError(exception.ToString());

            var innerException = exception.InnerException;
            var maxDepth = 3;

            while (innerException is not null || maxDepth-- > 0)
            {
                AddError(innerException.ToString());
                innerException = innerException.InnerException;
            }
        }

        public string Message { get; set; }

        public bool Succeeded { get; protected set; }

        public List<string> Errors { get; protected set; }

        public virtual void AddError(string error)
        {
            Succeeded = false;
            Errors.Add(error);
        }
    }

    public abstract class ResultBase<T> : ResultBase
    {
        protected ResultBase(string error, string message = null) : base(error, message)
        {
        }

        protected ResultBase(List<string> errors, string message = null) : base(errors, message)
        {
        }

        protected ResultBase(Exception exception) : base(exception)
        {
        }

        protected ResultBase(T data, string message = null) : base()
        {
            Succeeded = true;
            Data = data;
            Message = message;
        }


        public T Data { get; set; }

        public override void AddError(string error)
        {
            Succeeded = false;
            Data = default;
            Errors.Add(error);
        }
    }
}
