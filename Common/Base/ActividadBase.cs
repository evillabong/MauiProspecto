using Common.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base
{
    public class ActividadBase
    {
        public long Id { get; set; }

        public string Descripcion { get; set; } = null!;

        public ActividadType Tipo { get; set; }

        public DateTimeOffset Fecha { get; set; }

        public long ProspectoId { get; set; }
    }
}
