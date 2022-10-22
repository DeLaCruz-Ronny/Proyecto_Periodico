using System;
using System.Collections.Generic;

namespace Proyecto_Periodico.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Noticia = new HashSet<Noticia>();
        }

        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Noticia> Noticia { get; set; }
    }
}
