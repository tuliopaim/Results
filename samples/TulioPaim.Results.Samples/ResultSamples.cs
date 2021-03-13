using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TulioPaim.Results.Samples
{
    public static class ResultSamples
    {
        public static Result<int> PositiveOnlyCalc(int a, int b)
        {
            if (a < 0 || b < 0)
            {
                return Result<int>
                    .Error("You can only calc positive numbers :D");
            }

            var total = a + b;

            return Result<int>.Success(total);
        }

        public static Result<int> NegativeOnlyCalc(int a, int b)
        {
            if (a > 0 || b > 0)
            {
                return new Result<int>("You can only calc negative numbers :D");
            }

            var total = a + b;

            return new Result<int>(total);
        }

        public static Result<string> SelectFirstName()
        {
            var firstName = FakeService.SelectFirstName();

            return Result<string>.Success(firstName);
        }

        public static ListResult<string> SelectAllNames()
        {
            var list = FakeService.SelectAllNames();

            return ListResult<string>.Success(list);
        }

        public static PaginatedResult<string> SelectPaginated()
        {
            var page = 1;
            var pageSize = 2;
            
            var totalInDb = FakeService.CountNames();

            var result = FakeService.SelectPaginated(page, pageSize);

            return PaginatedResult<string>.SuccessResult(
                result,
                totalInDb,
                page,
                pageSize);
        }

        public static void CheckIfIsOdd()
        {
            for (int i = 0; i < 5; i++)
            {
                var result = FakeService.CheckIfIsOdd();

                if (result.Succeeded)
                {
                    Console.WriteLine(result.Message);
                }
                else
                {
                    Console.WriteLine(string.Join(", ", result.Errors));
                }
            }
        }

        public static Result<string> SelectNameByIndex(int index)
        {
            try
            {
                var name = FakeService.SelectNameByIndex(index);

                return Result<string>.Success(name);
            }
            catch(Exception ex)
            {
                return new Result<string>(ex);
            }
        }
    }
}
