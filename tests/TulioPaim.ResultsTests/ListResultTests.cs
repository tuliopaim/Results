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
            ListResult<int> result = ListResult<int>.Error("erro");
            ListResult<int> result2 = new ListResult<int>("erro");

            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
        }

        [Fact]
        public void ShouldBeSucceededWhenSuccessResult()
        {
            ListResult<int> result = ListResult<int>.Success(new List<int>());
            ListResult<int> result2 = new ListResult<int>(new List<int>());

            Assert.True(result.Succeeded);
            Assert.True(result2.Succeeded);
        }

        [Fact]
        public void ShouldNotBeSucceededWhenAddError()
        {
            ListResult<int> result = ListResult<int>.Success(new List<int>());
            ListResult<int> result2 = new ListResult<int>(new List<int>());

            result.AddError("Error");
            result2.AddError("Error");

            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
        }

        [Fact]
        public void ShouldAddErrorsCorrectly()
        {
            ListResult<int> result = ListResult<int>.Success(new List<int>());
            ListResult<int> result2 = new ListResult<int>(new List<int>());

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

            ListResult<int> resultError = ListResult<int>.Error("Error");
            ListResult<int> resultError2 = new ListResult<int>("Error");

            resultError.AddError("Error");
            resultError2.AddError("Error");
            resultError2.AddError("Error");

            Assert.Equal(2, resultError.Errors.Count);
            Assert.Equal(3, resultError2.Errors.Count);
        }

        [Fact]
        public void ShouldBeEmptyWhenDataIsEmpty()
        {
            ListResult<int> result = ListResult<int>.Success(new List<int>());
            ListResult<int> resultNull = ListResult<int>.Success(null);

            Assert.True(result.IsEmpty);
            Assert.True(resultNull.IsEmpty);
        }

        [Fact]
        public void ShouldBeEmptyWhenAddError()
        {
            var list = new List<int> { 1, 2, 3 };

            ListResult<int> result = ListResult<int>.Success(list);
            ListResult<int> result2 = ListResult<int>.Success(list);

            result.AddError("Error");
            result2.AddError("Error");

            Assert.True(result.IsEmpty);
            Assert.True(result2.IsEmpty);
        }

        [Fact]
        public void ShouldNotBeEmptyWhenDataIsNotEmpty()
        {
            ListResult<int> result = ListResult<int>.Success(new List<int> { 1, 2 });

            Assert.False(result.IsEmpty);
        }

        [Fact]
        public void DataShouldNeverBeNull()
        {
            var result = ListResult<int>
                .Success(null);

            var result2 = ListResult<int>
                .Error("Error 1");

            var result3 = ListResult<int>
                .Error(new List<string> { "Erro 1, Erro 2" });

            Assert.NotNull(result.Data);
            Assert.NotNull(result2.Data);
            Assert.NotNull(result3.Data);
        }
    }
}
