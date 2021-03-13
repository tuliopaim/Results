using System;
using System.Collections.Generic;

namespace TulioPaim.Results
{
    public class Result : ResultBase
    {
        public Result(string message = null) : base(message)
        {
            Succeeded = true;
        }

        public Result(string error, string message = null) : base(error, message)
        {
        }

        public Result(List<string> errors, string message = null) : base(errors, message)
        {
        }

        public Result(Exception ex) : base(ex)
        {
        }

        public static Result Success(string message = null)
        {
            return new Result(message);
        }

        public static Result Error(string error, string message = null)
        {
            return new Result(error, message);
        }

        public static Result Error(List<string> errors, string message = null)
        {
            return new Result(errors, message);
        }
    }

    public class Result<T> : ResultBase
    {
        public Result(T data, string message = null) : base(message)
        {
            Data = data;
        }

        public Result(string error, string message = null) : base(error, message)
        {
        }

        public Result(List<string> errors, string message = null) : base(errors, message)
        {
        }

        public Result(Exception ex) : base(ex)
        {
        }

        public T Data { get; protected set; }

        public static Result<T> Success(T data, string message = null)
        {
            return new Result<T>(data, message);
        }

        public static Result<T> Error(string error, string message = null)
        {
            return new Result<T>(error, message);
        }

        public static Result<T> Error(List<string> errors, string message = null)
        {
            return new Result<T>(errors, message);
        }
    }
}
