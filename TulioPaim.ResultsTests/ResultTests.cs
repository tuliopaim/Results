using System.Collections.Generic;
using TulioPaim.Results;
using Xunit;

namespace TulioPaim.ResultsTests
{
    public class ResultTests
    {
        [Fact]
        public void ShouldNotBeSucceededWhenErrorResult()
        {
            var result = Result.ErrorResult("erro");
            Result<int> resultOfInt = Result<int>.ErrorResult("erro");

            Assert.False(result.Succeeded);
            Assert.False(resultOfInt.Succeeded);
        }

        [Fact]
        public void ShouldBeSucceededWhenCreateByConstructor()
        {
            var result = new Result();
            Result<int> resultOfInt = new Result<int>(1);

            Assert.True(result.Succeeded);
            Assert.True(resultOfInt.Succeeded);
        }

        [Fact]
        public void DataShouldBeOfTheSameType()
        {
            var data = new List<int> { 1, 2, 3 };

            var result = new Result<List<int>>(data);

            Assert.True(result.Data.GetType() == data.GetType());
        }

        [Fact]
        public void ErrorsShouldNeverBeNull()
        {
            var errors = new List<string> { "Erro 1", "Erro 2" };

            var successResult = new Result();
            var successResult2 = Result.SuccessResult();

            var errorResult = new Result("Error", null);
            var errorResult2 = new Result(errors);
            var errorResult3 = Result.ErrorResult("Erro");
            var errorResult4 = Result.ErrorResult(errors);

            Assert.NotNull(successResult.Errors);
            Assert.NotNull(successResult2.Errors);
            Assert.NotNull(errorResult.Errors);
            Assert.NotNull(errorResult2.Errors);
            Assert.NotNull(errorResult3.Errors);
            Assert.NotNull(errorResult4.Errors);

            var successResultOfInt = new Result<int>(1);
            var successResultOfInt2 = Result<int>.SuccessResult(1);

            var errorResultOfInt = new Result<int>("Error");
            var errorResultOfInt2 = new Result<int>(errors);
            var errorResultOfInt3 = Result<int>.ErrorResult("Erro");
            var errorResultOfInt4 = Result<int>.ErrorResult(errors);

            Assert.NotNull(successResultOfInt.Errors);
            Assert.NotNull(successResultOfInt2.Errors);
            Assert.NotNull(errorResultOfInt.Errors);
            Assert.NotNull(errorResultOfInt2.Errors);
            Assert.NotNull(errorResultOfInt3.Errors);
            Assert.NotNull(errorResultOfInt4.Errors);
        }
    }
}
