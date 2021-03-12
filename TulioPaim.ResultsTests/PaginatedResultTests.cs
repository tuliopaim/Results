using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
