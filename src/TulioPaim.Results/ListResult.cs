using System;
using System.Collections.Generic;
using System.Linq;

namespace TulioPaim.Results
{
    public class ListResult<T> : Result
    {
        public ListResult(IEnumerable<T> data, string message = null) : base(true, message)
        {
            Data = data ?? new List<T>();
        }

        public ListResult(List<string> errors, string message = null) : base(errors, message)
        {
            Data = new List<T>();
        }

        public ListResult(string error, string message = null) : base(error, message)
        {
            Data = new List<T>();
        }       

        public ListResult(Exception ex) : base(ex)
        {
            Data = new List<T>();
        }


        public IEnumerable<T> Data { get; protected set; }

        public bool IsEmpty => !Data.Any();


        public override void AddError(string error)
        {
            base.AddError(error);

            if (Data.Any())
            {
                Data = new List<T>();
            }
        }


        public static ListResult<T> Success(IEnumerable<T> data, string message = null)
        {
            return new ListResult<T>(data, message);
        }

        public new static ListResult<T> Error(string error, string message = null)
        {
            return new ListResult<T>(error, message);
        }

        public new static ListResult<T> Error(List<string> errors, string message = null)
        {
            return new ListResult<T>(errors, message);
        }

        public new static ListResult<T> Error(Exception exception)
        {
            return new ListResult<T>(exception);
        }
    }
}
