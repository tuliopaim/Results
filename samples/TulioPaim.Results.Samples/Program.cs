using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

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
