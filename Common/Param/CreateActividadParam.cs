using Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Param
{
    public class CreateActividadParam : BaseParam
    {
        public ActividadBase Actividad { get; set; } = null!;
    }
}
