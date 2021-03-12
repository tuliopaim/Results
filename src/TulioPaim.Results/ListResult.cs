using System.Collections.Generic;
using System.Linq;

namespace TulioPaim.Results
{
    public class ListResult<T> : Result<IEnumerable<T>>
    {
        public ListResult() : base()
        {
            Data = new List<T>();
        }

        public bool IsEmpty => !Data.Any();

        public new static ListResult<T> SuccessResult(IEnumerable<T> data, string message = null)
        {
            return new ListResult<T>
            {
                Succeeded = true,
                Data = data ?? new List<T>(),
                Message = message
            };
        }

        public new static ListResult<T> ErrorResult(string error, string message = null)
        {
            return new ListResult<T>
            {
                Succeeded = false,
                Errors = new List<string>() { error },
                Message = message,
            };
        }

        public new static ListResult<T> ErrorResult(List<string> errors, string message = null)
        {
            return new ListResult<T>
            {
                Succeeded = false,
                Errors = errors ?? new List<string>(),
                Message = message,
            };
        }
    }
}
