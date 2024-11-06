using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Base
{
    public class ProspectoBase
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El campo Nombre solo acepta caracteres alfanuméricos.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El campo Celular es requerido.")]
        [RegularExpression(@"^\+?[0-9]+$", ErrorMessage = "El campo Celular solo acepta números y el signo '+'.")]
        public string Celular { get; set; } = null!;

        [Required(ErrorMessage = "El campo Correo Electrónico es requerido.")]
        [EmailAddress(ErrorMessage = "El campo Correo Electrónico no es una dirección de correo válida.")]
        public string CorreoElectronico { get; set; } = null!;
    }
}
