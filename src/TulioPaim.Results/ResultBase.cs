using System;
using System.Collections.Generic;

namespace TulioPaim.Results
{
    public abstract class ResultBase
    {
        protected ResultBase(string message = null)
        {
            Succeeded = true;
            Errors = new List<string>();
            Message = message;
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
            Errors = new List<string>();

            AddError(exception.ToString());
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
}
