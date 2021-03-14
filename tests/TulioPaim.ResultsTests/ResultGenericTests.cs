using System;
using System.Collections.Generic;
using TulioPaim.Results;
using Xunit;

namespace TulioPaim.ResultsTests
{
    public class ResultGenericTests
    {
        [Fact]
        public void ShouldNotBeSucceededWhenErrorResult()
        {
            Result<int> resultOfInt = Result<int>.Error("erro");

            Assert.False(resultOfInt.Succeeded);
        }

        [Fact]
        public void ShouldBeSucceededWhenCreateByConstructor()
        {
            Result<int> resultOfInt = new Result<int>(1);

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

            var successResultOfInt = new Result<int>(1);
            var successResultOfInt2 = Result<int>.Success(1);

            var errorResultOfInt = new Result<int>("Error");
            var errorResultOfInt2 = new Result<int>(errors);
            var errorResultOfInt3 = Result<int>.Error("Erro");
            var errorResultOfInt4 = Result<int>.Error(errors);

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

            var resultOfInt = new Result<int>(1);
            var resultOfInt2 = Result<int>.Success(1);

            resultOfInt.AddError(error);
            resultOfInt2.AddError(error);

            Assert.False(resultOfInt.Succeeded);
            Assert.False(resultOfInt2.Succeeded);
        }

        [Fact]
        public void ShouldAddErrorsCorrectly()
        {
            var error = "Erro 1";

            var resultOfInt = new Result<int>(1);
            var resultOfInt2 = Result<int>.Success(1);

            resultOfInt.AddError(error);
            resultOfInt.AddError(error);
            resultOfInt.AddError(error);
            resultOfInt.AddError(error);

            resultOfInt2.AddError(error);
            resultOfInt2.AddError(error);
            resultOfInt2.AddError(error);
            resultOfInt2.AddError(error);
            resultOfInt2.AddError(error);

            Assert.Equal(4, resultOfInt.Errors.Count);
            Assert.Equal(5, resultOfInt2.Errors.Count);

            var errorResultOfInt = new Result<int>("Error");
            var errorResultOfInt2 = Result<int>.Error("Error");

            errorResultOfInt.AddError(error);
            errorResultOfInt2.AddError(error);

            Assert.Equal(2, errorResultOfInt.Errors.Count);
            Assert.Equal(2, errorResultOfInt2.Errors.Count);
        }

        [Fact]
        public void ShouldNotBeSucceededOnException()
        {
            var exception = new Exception("Exception message");

            var resultOfInt = new Result<int>(exception);

            Assert.False(resultOfInt.Succeeded);
        }

        [Fact]
        public void ShouldAddExceptionInErrors()
        {
            var exception = new Exception("Exception");

            var resultOfInt = new Result<int>(exception);

            Assert.Single(resultOfInt.Errors);
        }
    }
}
