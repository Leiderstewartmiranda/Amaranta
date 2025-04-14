using System;
using System.Collections.Generic;

namespace AMARANTA.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Documento { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public int? IdRol { get; set; }

    public virtual Role? IdRolNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
