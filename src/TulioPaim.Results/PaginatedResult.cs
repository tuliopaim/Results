using System;
using System.Collections.Generic;

namespace TulioPaim.Results
{
    public class PaginatedResult<T> : ListResult<T>
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
            int pageSize) : base(data)
        {
            Total = total;
            Page = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(Total / (double)PageSize);
        }

        public int PageSize { get; }

        public int Page { get; }

        public int TotalPages { get; }

        public long Total { get; }

        public bool HasPrevPage => Page > 1;

        public bool HasNextPage => Page < TotalPages;
    }
}
