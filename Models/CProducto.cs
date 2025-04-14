using System;
using System.Collections.Generic;

namespace AMARANTA.Models;

public partial class CProducto
{
    public int IdCategoria { get; set; }

    public string? NombreCategoria { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
