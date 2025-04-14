using System;
using System.Collections.Generic;

namespace AMARANTA.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string? Nit { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? Representante { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }
}
