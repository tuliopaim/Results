using System;
using System.Collections.Generic;

namespace TulioPaim.Results
{
    public class Result<T> : Result
    {
        public Result(T data, string message = null) : base(true, message)
        {
            Data = data;
        }

        public Result(string error, string message = null) : base(error, message)
        {
        }

        public Result(List<string> errors, string message = null) : base(errors, message)
        {
        }

        public Result(Exception exception) : base(exception)
        {
        }


        public T Data { get; protected set; }

        public static Result<T> Success(T data, string message = null)
        {
            return new Result<T>(data, message);
        }

        public new static Result<T> Error(string error, string message = null)
        {
            return new Result<T>(error, message);
        }

        public new static Result<T> Error(List<string> errors, string message = null)
        {
            return new Result<T>(errors, message);
        }

        public new static Result<T> Error(Exception exception)
        {
            return new Result<T>(exception);
        }
    }
}
