using System.Collections.Generic;
using TulioPaim.Results;
using Xunit;

namespace TulioPaim.ResultsTests
{
    public class PaginatedResultTests
    {
        [Fact]
        public void ShouldNotBeSucceededWhenErrorResult()
        {
            PaginatedResult<int> result = PaginatedResult<int>.ErrorResult("erro");

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void ShouldBeSucceededWhenSuccessResult()
        {
            var result = PaginatedResult<int>
                .SuccessResult(
                new List<int>() { 1 },
                1,
                1,
                1);

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void DataShouldNeverBeNull()
        {
            var result = PaginatedResult<int>
                .SuccessResult(
                null,
                1,
                1,
                1);

            var result2 = PaginatedResult<int>
                .ErrorResult("Error 1");

            var result3 = PaginatedResult<int>
                .ErrorResult(new List<string> { "Erro 1, Erro 2" });

            Assert.NotNull(result.Data);
            Assert.NotNull(result2.Data);
            Assert.NotNull(result3.Data);
        }

        [Fact]
        public void ShouldNotBeSucceededWhenAddError()
        {
            var result = PaginatedResult<int>
               .SuccessResult(
               null,
               1,
               1,
               1);

            var result2 = new PaginatedResult<int>(
               null,
               1,
               1,
               1);

            result.AddError("Error");
            result2.AddError("Error");

            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
        }

        [Fact]
        public void ShouldAddErrorsCorrectly()
        {
            var result = PaginatedResult<int>
                  .SuccessResult(
                  null,
                  1,
                  1,
                  1);

            var result2 = new PaginatedResult<int>(
               null,
               1,
               1,
               1);

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

            var resultError = PaginatedResult<int>.ErrorResult("Error");
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
            var result = PaginatedResult<int>
                  .SuccessResult(
                  list,
                  3,
                  1,
                  3);

            var result2 = new PaginatedResult<int>(
               list,
               3,
               1,
               3);

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
            var result = PaginatedResult<int>
                .SuccessResult(
                new List<int>() { 1 },
                total,
                1,
                pageSize);

            Assert.Equal(result.TotalPages, totalPages);
        }
    }
}
