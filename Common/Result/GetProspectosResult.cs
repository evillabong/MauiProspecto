using Common.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Result
{
    public class GetProspectosResult : BaseResult
    {
        public List<ProspectoBase> Prospectos { get; set; } = [];
    }
}
