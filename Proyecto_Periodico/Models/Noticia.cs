using System;
using System.Collections.Generic;

namespace Proyecto_Periodico.Models
{
    public partial class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public string Extracto { get; set; } = null!;
        public string Contenido { get; set; } = null!;
        public int? IdUsuario { get; set; }
        public int? IdCategoria { get; set; }
        public DateTime? FechaP { get; set; }
        public byte[]? Foto { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
