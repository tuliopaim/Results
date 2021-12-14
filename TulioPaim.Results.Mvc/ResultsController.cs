using Microsoft.AspNetCore.Mvc;

namespace TulioPaim.Results.Mvc
{
    public class ResultsController : Controller
    {
        protected ActionResult<Result> ReturnResult(Result result)
        {
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        protected ActionResult<Result<T>> ReturnResult<T>(Result<T> result)
        {
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        protected ActionResult<ListResult<T>> ReturnListResult<T>(ListResult<T> result)
        {
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        protected ActionResult<PaginatedResult<T>> ReturnPaginatedResult<T>(PaginatedResult<T> result)
        {
            if (result.Succeeded)
            {
                return Ok(result);
            }



            return BadRequest(result);
        }
    }
}
