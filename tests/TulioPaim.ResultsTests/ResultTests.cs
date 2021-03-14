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
            var result = Result.Error("erro");

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void ShouldBeSucceededWhenCreateByConstructor()
        {
            var result = new Result();

            Assert.True(result.Succeeded);
        }

        [Fact]
        public void ErrorsShouldNeverBeNull()
        {
            var errors = new List<string> { "Erro 1", "Erro 2" };

            var successResult = new Result();
            var successResult2 = Result.Success();

            var errorResult = new Result("Error", null);
            var errorResult2 = new Result(errors);
            var errorResult3 = Result.Error("Erro");
            var errorResult4 = Result.Error(errors);

            Assert.NotNull(successResult.Errors);
            Assert.NotNull(successResult2.Errors);
            Assert.NotNull(errorResult.Errors);
            Assert.NotNull(errorResult2.Errors);
            Assert.NotNull(errorResult3.Errors);
            Assert.NotNull(errorResult4.Errors);
        }


        [Fact]
        public void ShouldNotBeSucceededWhenAddError()
        {
            var error = "Erro 1";

            var result = new Result();
            var result2 = Result.Success();

            result.AddError(error);
            result2.AddError(error);

            Assert.False(result.Succeeded);
            Assert.False(result2.Succeeded);
        }

        [Fact]
        public void ShouldAddErrorsCorrectly()
        {
            var error = "Erro 1";

            var result = new Result();
            var result2 = Result.Success();

            result.AddError(error);
            result.AddError(error);
            result.AddError(error);
            result.AddError(error);
            result.AddError(error);

            result2.AddError(error);
            result2.AddError(error);
            result2.AddError(error);

            Assert.Equal(5, result.Errors.Count);
            Assert.Equal(3, result2.Errors.Count);

            var errorResult = new Result("Error", null);
            var errorResult2 = Result.Error("Error");

            errorResult.AddError(error);
            errorResult.AddError(error);

            errorResult2.AddError(error);


            Assert.Equal(3, errorResult.Errors.Count);
            Assert.Equal(2, errorResult2.Errors.Count);
        }

        [Fact]
        public void ShouldNotBeSucceededOnException()
        {
            var exception = new Exception("Exception message");

            var result = new Result(exception);

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void ShouldAddExceptionInErrors()
        {
            var exception = new Exception("Exception");

            var result = new Result(exception);

            Assert.Single(result.Errors);
        }
    }
}
