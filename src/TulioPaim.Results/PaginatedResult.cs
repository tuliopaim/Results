using System;
using System.Collections.Generic;
using System.Linq;

namespace TulioPaim.Results
{
    public class PaginatedResult<T> : Result
    {
        /// <summary>
        /// Create a PaginatedResult
        /// </summary>
        /// <param name="data">IEnumerable<T> results</param>
        /// <param name="total">Total items</param>
        /// <param name="page">Page number (>=1)</param>
        /// <param name="pageSize">Page Size</param>
        public PaginatedResult(
            IEnumerable<T> data,
            long total,
            int page,
            int pageSize,
            string message = null)
            : base(true, message)
        {
            Data = data ?? new List<T>();
            Total = total;
            Page = page;
            PageSize = pageSize;
        }

        public IEnumerable<T> Data { get; set; }

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
        }

        public int PageSize { get; private set; }

        public int Page { get; private set; }

        public long Total { get; private set; }

        public int TotalPages =>
            PageSize == 0
            ? 0
            : (int)Math.Ceiling(Total / (double)PageSize);

        public bool HasPrevPage => Page > 1;

        public bool HasNextPage => Page < TotalPages;

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
            Page = default;
            Total = default;
        }

        public static PaginatedResult<T> SuccessResult(
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
    }
}
