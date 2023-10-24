using System;
using System.Collections.Generic;

namespace Biblioteca
{

    public class Estado
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public virtual List<Libro> Libros { get; set; } = new();
    }

}
