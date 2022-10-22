using System;
using System.Collections.Generic;

namespace Proyecto_Periodico.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Noticia = new HashSet<Noticia>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Clave { get; set; }

        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
