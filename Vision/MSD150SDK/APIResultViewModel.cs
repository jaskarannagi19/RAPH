using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSD150SDK
{
    public class APIResultViewModel
    {
        public eExecutionResult Result { get; set; }

        public object ResultValue { get; set; } 

        public string Error { get; set; }
    }

    public enum eExecutionResult
    {
        NotExecutedYet = 0,
        Succeed = 1,
        Error = 2,
    }
}
