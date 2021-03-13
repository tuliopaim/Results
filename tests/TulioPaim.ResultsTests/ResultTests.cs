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


        [Fact]
        public void ShouldNotBeSucceededWhenAddError()
        {
            var error = "Erro 1";

            var result = new Result();
            var result2 = Result.SuccessResult();

            var resultOfInt = new Result<int>(1);
            var resultOfInt2 = Result<int>.SuccessResult(1);

            result.AddError(error);
            result2.AddError(error);
            resultOfInt.AddError(error);
            resultOfInt2.AddError(error);

            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
            Assert.False(resultOfInt.Succeeded);
            Assert.False(resultOfInt2.Succeeded);
        }

        [Fact]
        public void ShouldAddErrorsCorrectly()
        {
            var error = "Erro 1";

            var result = new Result();
            var result2 = Result.SuccessResult();

            var resultOfInt = new Result<int>(1);
            var resultOfInt2 = Result<int>.SuccessResult(1);

            result.AddError(error);
            result.AddError(error);
            result.AddError(error);
            result.AddError(error);
            result.AddError(error);

            result2.AddError(error);
            result2.AddError(error);
            result2.AddError(error);

            resultOfInt.AddError(error);
            resultOfInt.AddError(error);
            resultOfInt.AddError(error);
            resultOfInt.AddError(error);

            resultOfInt2.AddError(error);
            resultOfInt2.AddError(error);
            resultOfInt2.AddError(error);
            resultOfInt2.AddError(error);
            resultOfInt2.AddError(error);

            Assert.Equal(5, result.Errors.Count);
            Assert.Equal(3, result2.Errors.Count);
            Assert.Equal(4, resultOfInt.Errors.Count);
            Assert.Equal(5, resultOfInt2.Errors.Count);

            var errorResult = new Result("Error", null);
            var errorResult2 = Result.ErrorResult("Error");

            var errorResultOfInt = new Result<int>("Error");
            var errorResultOfInt2 = Result<int>.ErrorResult("Error");

            errorResult.AddError(error);
            errorResult.AddError(error);

            errorResult2.AddError(error);

            errorResultOfInt.AddError(error);
            errorResultOfInt2.AddError(error);

            Assert.Equal(3, errorResult.Errors.Count);
            Assert.Equal(2, errorResult2.Errors.Count);
            Assert.Equal(2, errorResultOfInt.Errors.Count);
            Assert.Equal(2, errorResultOfInt2.Errors.Count);
        }
    }
}
