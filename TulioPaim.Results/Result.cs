using System;
using System.Collections.Generic;

namespace TulioPaim.Results
{
    public class Result: IResult
    {
        public Result() { }

        public Result(Exception exception)
        {
            Succeeded = false;
            Message = $"Ocorreu um erro: {exception.Message}";
        }

        public string Message { get; set; }

        public List<string> Errors { get; set; }

        public bool Succeeded { get; set; }

        public Result AddError(string error)
        {
            Errors.Add(error);

            return this;
        }

        public static Result SuccessResult(string message = null)
        {
            return new Result
            {
                Message = message,
                Succeeded = true,
            };
        }

        public static Result ErrorResult(string message = null, List<string> errors = null)
        {
            return new Result
            {
                Message = message,
                Errors = errors,
                Succeeded = true,
            };
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public Result()
        {
        }

        public T Data { get; set; }

        public new Result<T> AddError(string error)
        {
            Errors.Add(error);

            return this;
        }

        public static Result<T> SuccessResult(T data, string message = null)
        {
            return new Result<T>
            {
                Data = data,
                Message = message,
                Succeeded = true,
            };
        }

        public static new Result<T> ErrorResult(string message = null, List<string> errors = null)
        {
            return new Result<T>
            {
                Message = message,
                Errors = errors,
                Succeeded = true,
            };
        }
    }
}
