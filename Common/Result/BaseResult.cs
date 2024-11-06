using Common.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result
{
    public class BaseResult
    {
        public int CurrentPage { get; set; } = 1;
        public int Groups { get; set; } = 1;
        public int[] Size { get; set; } = [];
        public ResultType Result { get; set; } = ResultType.Success;
        public string Message { get; set; } = string.Empty;
    }
}
