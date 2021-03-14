using System;
using System.Collections.Generic;
using System.Text.Json;

namespace TulioPaim.Results.Samples
{
    public class Program
    {
        static void Main(string[] args)
        {
            PrintFunctionName(nameof(ResultSamples.CheckIfIsOdd));
            ResultSamples.CheckIfIsOdd();

            PrintFunctionName(nameof(ResultSamples.SelectPaginated));
            Serialize(ResultSamples.SelectPaginated());

            PrintFunctionName(nameof(ResultSamples.SelectFirstName));
            Serialize(ResultSamples.SelectFirstName());

            PrintFunctionName(nameof(ResultSamples.SelectAllNames));
            Serialize(ResultSamples.SelectAllNames());

            PrintFunctionName(nameof(ResultSamples.PositiveOnlyCalc));
            Serialize(ResultSamples.PositiveOnlyCalc(2, 3));

            PrintFunctionName(nameof(ResultSamples.PositiveOnlyCalc));
            Serialize(ResultSamples.PositiveOnlyCalc(4, -3));

            PrintFunctionName(nameof(ResultSamples.NegativeOnlyCalc));
            Serialize(ResultSamples.NegativeOnlyCalc(2, 3));

            PrintFunctionName(nameof(ResultSamples.NegativeOnlyCalc));
            Serialize(ResultSamples.NegativeOnlyCalc(-4, -3));

            PrintFunctionName(nameof(ResultSamples.SelectNameByIndex));
            Serialize(ResultSamples.SelectNameByIndex(15));

            Serialize(new Result(true));

            try
            {
                var zero = 0;
                var x = 1 / zero;
            }
            catch(Exception ex)
            {
                var result = new Result(ex);

                Serialize(result);
            }

            Serialize(new Result());
            Serialize(new Result<object>(new { Id = "1", Name = "Tulio" }));
            Serialize(new Result<int>("Error message"));
            Serialize(new ListResult<int>(new List<int> { 1, 2 ,3}));
            Serialize(new ListResult<int>("Error message"));

            var paginated = new PaginatedResult<int>(
                data: new List<int> { 1, 2, 3 },
                total: 100,
                currentPage: 1,
                pageSize: 3,
                message: "A 100 itens list in pages of 3 itens");

            Serialize(paginated);

            Serialize(new PaginatedResult<int>("Error"));

            Console.ReadLine();
        }

        static void Serialize(object obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);

            Console.WriteLine(jsonString);
            Console.WriteLine();
        }

        static void PrintFunctionName(string functionName)
        {
            Console.WriteLine();
            Console.WriteLine("*******************");
            Console.WriteLine(functionName);
            Console.WriteLine("*******************");
            Console.WriteLine();
        }

    }
}
