using System;
using System.Collections.Generic;

namespace Model.Entities.Sql.DataBase;

public partial class Prospecto
{
    public long Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Celular { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();
}
