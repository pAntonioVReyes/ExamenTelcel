using System;
using System.Collections.Generic;

namespace Telcel.R9.Estructura.AccesoDatos;

public partial class EmpleadosGetAllV
{
    public int EmpleadoId { get; set; }

    public string? Nombre { get; set; }

    public int? Idpuesto { get; set; }

    public string? Puesto { get; set; }

    public int? Iddepartamento { get; set; }

    public string? Departamento { get; set; }
}
