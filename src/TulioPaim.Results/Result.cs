using System;
using System.Collections.Generic;

namespace TulioPaim.Results
{
    public class Result: IResult
    {
        protected Result()
        {
            Errors = new List<string>();
        }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public bool Succeeded { get; set; }

        public static Result SuccessResult(string message = null)
        {
            return new Result
            {
                Message = message,
                Succeeded = true,
            };
        }

        public static Result ErrorResult(string error, string message = null)
        {
            return new Result
            {
                Succeeded = false,
                Errors = new List<string>() { error },
                Message = message,
            };
        }

        public static Result ErrorResult(List<string> errors, string message = null)
        {
            return new Result
            {
                Succeeded = false,
                Errors = errors ?? new List<string>(),
                Message = message,
            };
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        protected Result() : base()
        {}

        public T Data { get; set; }

        public static Result<T> SuccessResult(T data, string message = null)
        {
            return new Result<T>
            {
                Succeeded = true,
                Data = data,
                Message = message
            };
        }

        public new static Result<T> ErrorResult(string error, string message = null)
        {
            return new Result<T>
            {
                Succeeded = false,
                Errors = new List<string>() { error },
                Message = message,
            };
        }

        public new static Result<T> ErrorResult(List<string> errors, string message = null)
        {
            return new Result<T>
            {
                Succeeded = false,
                Errors = errors ?? new List<string>(),
                Message = message,
            };
        }
    }
}
