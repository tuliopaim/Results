using System;
using System.Collections.Generic;
using System.Linq;
using TulioPaim.Results;
using Xunit;

namespace TulioPaim.ResultsTests
{
    public class PaginatedResultTests
    {
        [Fact]
        public void ShouldNotBeSucceededWhenErrorResult()
        {
            var result = PaginatedResult<int>.Error("erro");

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void ShouldBeSucceededWhenSuccessResult()
        {
            var result = PaginatedResult<int>
                .Success(new List<int>() { 1 }, 1, 1, 1);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void DataShouldNeverBeNull()
        {
            var result = PaginatedResult<int>.Success(null, 1, 1, 1);

            var result2 = PaginatedResult<int>
                .Error("Error 1");

            var result3 = PaginatedResult<int>.Error(new List<string> { "Erro 1, Erro 2" });

            Assert.NotNull(result.Data);
            Assert.NotNull(result2.Data);
            Assert.NotNull(result3.Data);
        }

        [Fact]
        public void ShouldNotBeSucceededWhenAddError()
        {
            var result = PaginatedResult<int>.Success(null, 1, 1, 1);

            var result2 = new PaginatedResult<int>(null, 1, 1, 1);

            result.AddError("Error");
            result2.AddError("Error");

            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
        }

        [Fact]
        public void ShouldAddErrorsCorrectly()
        {
            var result = PaginatedResult<int>.Success(null, 1, 1, 1);

            var result2 = new PaginatedResult<int>(null, 1, 1, 1);

            result.AddError("Error");
            result.AddError("Error");
            result.AddError("Error");

            result2.AddError("Error");
            result2.AddError("Error");
            result2.AddError("Error");
            result2.AddError("Error");
            result2.AddError("Error");

            Assert.Equal(3, result.Errors.Count);
            Assert.Equal(5, result2.Errors.Count);

            var resultError = PaginatedResult<int>.Error("Error");
            var resultError2 = new PaginatedResult<int>("Error");

            resultError.AddError("Error");
            resultError2.AddError("Error");
            resultError2.AddError("Error");

            Assert.Equal(2, resultError.Errors.Count);
            Assert.Equal(3, resultError2.Errors.Count);
        }

        [Fact]
        public void ShouldBeEmptyWhenAddError()
        {
            var list = new List<int> { 1, 2, 3 };

            var result = PaginatedResult<int>.Success(list, 3, 1, 3);

            var result2 = new PaginatedResult<int>(list, 3, 1, 3);

            result.AddError("Error");
            result2.AddError("Error");

            Assert.Empty(result.Data);
            Assert.Empty(result2.Data);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(100, 10, 10)]
        [InlineData(540, 20, 27)]
        public void ShouldCalculateTotalPagesCorrectly(long total, int pageSize, int totalPages)
        {
            var result = PaginatedResult<int>.Success(new List<int> { 1 }, total, 1, pageSize);

            Assert.Equal(result.TotalPages, totalPages);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(1, 1, 0)]
        [InlineData(2, 1, 1)]
        [InlineData(100, 10, 9)]
        [InlineData(540, 20, 26)]
        public void ShouldCalculateLastPageCorrectly(long total, int pageSize, int lastPage)
        {
            var result = PaginatedResult<int>.Success(new List<int> { 1 }, total, 1, pageSize);

            Assert.Equal(result.LastPage, lastPage);
        }

        [Theory]
        [InlineData(10, 3, 0, true)]
        [InlineData(10, 3, 1, true)]
        [InlineData(10, 3, 2, true)]
        [InlineData(10, 3, 3, false)]
        public void ShouldCalculateHasNextPageCorrectly(int total, int pageSize, int currentPage, bool hasNextPage)
        {
            var totalList = new List<int>();
            
            for (var i = 0; i < total; i++) totalList.Add(i);

            var paginatedList = totalList.Skip(currentPage * pageSize).Take(pageSize);

            var paginatedResult = new PaginatedResult<int>(paginatedList, total, currentPage, pageSize);

            Assert.Equal(hasNextPage, paginatedResult.HasNextPage);
        }

        [Theory]
        [InlineData(10, 3, 0, false)]
        [InlineData(10, 3, 1, true)]
        [InlineData(10, 3, 2, true)]
        [InlineData(10, 3, 3, true)]
        public void ShouldCalculateHasPreviousPageCorrectly(int total, int pageSize, int currentPage, bool hasPreviousPage)
        {
            var totalList = new List<int>();
            
            for (var i = 0; i < total; i++) totalList.Add(i);

            var paginatedList = totalList.Skip(currentPage * pageSize).Take(pageSize);

            var paginatedResult = new PaginatedResult<int>(paginatedList, total, currentPage, pageSize);

            Assert.Equal(hasPreviousPage, paginatedResult.HasPrevPage);
        }
    }
}
