using Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Param
{
    public class CreateProspectoParam : BaseParam
    {
        public ProspectoBase Prospecto { get; set; } = null!;
    }
}
