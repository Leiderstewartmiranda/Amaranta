using System;
using System.Collections.Generic;

namespace AMARANTA.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Documento { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Clave { get; set; }

    public int? IdRol { get; set; }

    public virtual ICollection<Abono> Abonos { get; set; } = new List<Abono>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual Role? IdRolNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
