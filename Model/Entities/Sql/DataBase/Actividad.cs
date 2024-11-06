using System;
using System.Collections.Generic;

namespace Model.Entities.Sql.DataBase;

public partial class Actividad
{
    public long Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int Tipo { get; set; }

    public DateTimeOffset Fecha { get; set; }

    public int Calificacion { get; set; }

    public long ProspectoId { get; set; }

    public virtual Prospecto Prospecto { get; set; } = null!;
}
