using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TulioPaim.Results
{
    public class ListResult<T> : Result<IEnumerable<T>>
    {
        public ListResult(IEnumerable<T> data)
        {
            Data = data;
        }
    }
}
