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

        [Fact]
        public void ShouldNotBeEmptyWhenDataIsNotEmpty()
        {
            ListResult<int> result = ListResult<int>.SuccessResult(new List<int> { 1, 2 });

            Assert.False(result.IsEmpty);
        }

        [Fact]
        public void DataShouldNeverBeNull()
        {
            var result = ListResult<int>
                .SuccessResult(null);

            var result2 = ListResult<int>
                .ErrorResult("Error 1");

            var result3 = ListResult<int>
                .ErrorResult(new List<string> { "Erro 1, Erro 2" });

            Assert.NotNull(result.Data);
            Assert.NotNull(result2.Data);
            Assert.NotNull(result3.Data);
        }
    }
}
