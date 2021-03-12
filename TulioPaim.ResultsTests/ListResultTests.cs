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

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void ShouldBeSucceededWhenSuccessResult()
        {
            ListResult<int> result = ListResult<int>.SuccessResult(new List<int>());

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void ShouldBeEmptyWhenDataIsEmpty()
        {
            ListResult<int> result = ListResult<int>.SuccessResult(new List<int>());
            ListResult<int> resultNull = ListResult<int>.SuccessResult(null);

            Assert.True(result.IsEmpty);
            Assert.True(resultNull.IsEmpty);
        }
    }
}
