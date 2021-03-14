using System;
using System.Collections.Generic;

namespace TulioPaim.Results
{
    public class Result
    {
        public Result(bool succeeded = true, string message = null)
        {
            Succeeded = succeeded;
            Errors = new List<string>();
            Message = message;
        }

        public Result(List<string> errors, string message = null) : this(false, message)
        {
            if (errors is not null) Errors = errors;
        }

        public Result(string error, string message = null)
            : this(new List<string> { error }, message)
        {
        }

        public Result(Exception exception) : this(exception.ToString())
        {
        }

        public string Message { get; set; }

        public bool Succeeded { get; protected set; }

        public List<string> Errors { get; protected set; }

        public virtual void AddError(string error)
        {
            Succeeded = false;
            Errors.Add(error);
        }

        public static Result Success(string message = null)
        {
            return new Result(true, message);
        }

        public static Result Error(string error, string message = null)
        {
            return new Result(error, message);
        }

        public static Result Error(List<string> errors, string message = null)
        {
            return new Result(errors, message);
        }

        public static Result Error(Exception exception)
        {
            return new Result(exception);
        }
    }
}
