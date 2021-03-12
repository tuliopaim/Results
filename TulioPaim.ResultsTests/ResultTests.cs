using System;
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

            Assert.True(result.Succeeded);
            Assert.True(resultOfInt.Succeeded);
        }

        [Fact]
        public void ShouldBeSucceededWhenSuccessResult()
        {
            var result = Result.SuccessResult();
            Result<int> resultOfInt = Result<int>.SuccessResult();

            Assert.True(result.Succeeded);
            Assert.True(resultOfInt.Succeeded);
        }

        [Fact]
        public void DataShouldBeOfTheSameType()
        {
            var data = new List<int> { 1, 2, 3 };

            var result = Result<List<int>>.SuccessResult(data);

            Assert.True(result.Data.GetType() == data.GetType());
        }

        [Fact]
        public void ErrorsShouldNotBeNull()
        {
            var successResult = Result.SuccessResult();
            var errorResult = Result.ErrorResult("Erro");

            Assert.NotNull(successResult.Errors);
            Assert.NotNull(errorResult.Errors);

            var successResultOfInt = Result<int>.SuccessResult();
            var errorResultOfInt = Result<int>.ErrorResult("Erro");

            Assert.NotNull(successResultOfInt.Errors);
            Assert.NotNull(errorResultOfInt.Errors);
        }
    }
}
