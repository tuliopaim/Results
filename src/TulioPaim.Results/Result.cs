using System.Collections.Generic;

namespace TulioPaim.Results
{
    public class Result: ResultBase
    {
        protected Result()
        {
            Errors = new List<string>();
        }

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

    public class Result<T> : ResultBase<T>
    {
        protected Result()
        {
            Errors = new List<string>();
        }

        public static Result<T> SuccessResult(T data, string message = null)
        {
            return new Result<T>
            {
                Succeeded = true,
                Data = data,
                Message = message
            };
        }

        public static Result<T> ErrorResult(string error, string message = null)
        {
            return new Result<T>
            {
                Succeeded = false,
                Errors = new List<string>() { error },
                Message = message,
            };
        }

        public static Result<T> ErrorResult(List<string> errors, string message = null)
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
