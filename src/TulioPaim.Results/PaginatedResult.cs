using System;
using System.Collections.Generic;

namespace TulioPaim.Results
{
    public class PaginatedResult<T> : ResultBase<IEnumerable<T>>
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
            : base(data, message)
        {
            Data = data ?? new List<T>();
            Total = total;
            Page = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(Total / (double)PageSize);

            Message = message;
        }

        public PaginatedResult(string error, string message = null) : base(error, message)
        {
            Data = new List<T>();
        }

        public PaginatedResult(List<string> errors, string message = null) : base(errors, message)
        {
            Data = new List<T>();
        }

        public int PageSize { get; private set; }

        public int Page { get; private set; }

        public long Total { get; private set; }

        public int TotalPages { get; private set; }

        public bool HasPrevPage => Page > 1;

        public bool HasNextPage => Page < TotalPages;

        public static PaginatedResult<T> SuccessResult(
            IEnumerable<T> data,
            long total,
            int page,
            int pageSize,
            string message = null)
        {
            return new PaginatedResult<T>(data, total, page, pageSize, message);
        }

        public static PaginatedResult<T> ErrorResult(string error, string message = null)
        {
            return new PaginatedResult<T>(error, message);
        }

        public static PaginatedResult<T> ErrorResult(List<string> errors, string message = null)
        {
            return new PaginatedResult<T>(errors, message);
        }
    }
}
