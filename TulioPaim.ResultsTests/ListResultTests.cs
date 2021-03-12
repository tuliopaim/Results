using System.Collections.Generic;
using TulioPaim.Results;
using Xunit;

namespace TulioPaim.ResultsTests
{
    public class ListResultTests
    {
        [Fact]
        public void ShouldNotBeSucceededWhenErrorResult()
        {
            ListResult<int> result = ListResult<int>.ErrorResult("erro");

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void ShouldBeSucceededWhenSuccessResult()
        {
            ListResult<int> result = ListResult<int>.SuccessResult(new List<int>());

            Assert.True(result.Succeeded);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(533)]
        public void ShouldReturnTheCorrectTotal(int size)
        {
            var list = new List<int>(size);

            var successResult = ListResult<int>.SuccessResult(list);
            var errorResult = ListResult<int>.ErrorResult("Erro");

            Assert.Equal(successResult.Total, size);
            Assert.Equal(errorResult.Total, size);
        }

    }
}
