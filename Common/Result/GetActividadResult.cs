using Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result
{
    public class GetActividadResult : BaseResult
    {
        public ActividadBase Actividad { get; set; } = null!;
    }
}
