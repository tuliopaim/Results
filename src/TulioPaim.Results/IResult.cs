using System.Collections.Generic;

namespace TulioPaim.Results
{
    public interface IResult
    {
        string Message { get; set; }

        bool Succeeded { get; set; }

        List<string> Errors { get; set; }
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
