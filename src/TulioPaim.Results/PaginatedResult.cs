using System;
using System.Collections.Generic;
using System.Linq;

namespace TulioPaim.Results
{
    public class PaginatedResult<T> : Result
    {
        public PaginatedResult(
            IEnumerable<T> data,
            long total,
            int currentPage,
            int pageSize,
            string message = null)
            : base(true, message)
        {
            Data = data ?? new List<T>();
            Total = total;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public PaginatedResult(string error, string message = null) : base(error, message)
        {
            Data = new List<T>();
        }

        public PaginatedResult(List<string> errors, string message = null) : base(errors, message)
        {
            Data = new List<T>();
        }

        public PaginatedResult(Exception ex) : base(ex)
        {
            Data = new List<T>();
        }

        public IEnumerable<T> Data { get; private set; }

        public long Total { get; private set; }

        public int CurrentPage { get; private set; }

        public int PageSize { get; private set; }

        public int TotalPages => PageSize == 0
            ? 0
            : (int)Math.Ceiling(Total / (double)PageSize);
        
        public int FirstPage => 0;

        public int LastPage => TotalPages == 0 ? 0 : TotalPages - 1;

        public bool HasPrevPage => CurrentPage >= 1;

        public bool HasNextPage => CurrentPage < LastPage;

        public int PrevPage => !HasPrevPage ? FirstPage : CurrentPage - 1;

        public int NextPage => !HasNextPage ? LastPage : CurrentPage + 1;
        
        public override void AddError(string error)
        {
            base.AddError(error);

            ClearData();
        }

        private void ClearData()
        {
            if (Data.Any())
            {
                Data = new List<T>();
            }

            PageSize = default;
            CurrentPage = default;
            Total = default;
        }

        public static PaginatedResult<T> Success(
            IEnumerable<T> data,
            long total,
            int page,
            int pageSize,
            string message = null)
        {
            return new PaginatedResult<T>(data, total, page, pageSize, message);
        }

        public new static PaginatedResult<T> Error(string error, string message = null)
        {
            return new PaginatedResult<T>(error, message);
        }

        public new static PaginatedResult<T> Error(List<string> errors, string message = null)
        {
            return new PaginatedResult<T>(errors, message);
        }

        public new static PaginatedResult<T> Error(Exception exception)
        {
            return new PaginatedResult<T>(exception);
        }
    }
}
