using Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result
{
    public class GetActividadesResult : BaseResult
    {
        public List<ActividadBase> Actividades { get; set; } = [];
    }
}
