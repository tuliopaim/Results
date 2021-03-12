using System.Collections.Generic;
using System.Linq;

namespace TulioPaim.Results
{
    public class ListResult<T> : Result<IEnumerable<T>>
    {
        public ListResult (IEnumerable<T> data, string message = null) : base(data, message)
        {
            Data = data ?? new List<T>();
        }

        public ListResult (string error, string message = null) : base(error, message)
        {
            Data = new List<T>();
        }

        public ListResult (List<string> errors, string message = null) : base(errors, message)
        {
            Data = new List<T>();
        }

        public bool IsEmpty => !Data.Any();

        public new static ListResult<T> SuccessResult(IEnumerable<T> data, string message = null)
        {
            return new ListResult<T>(data, message);
        }

        public new static ListResult<T> ErrorResult(string error, string message = null)
        {
            return new ListResult<T>(error, message);
        }

        public new static ListResult<T> ErrorResult(List<string> errors, string message = null)
        {
            return new ListResult<T>(errors, message);
        }
    }
}
