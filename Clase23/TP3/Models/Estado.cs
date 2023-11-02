using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    [Table("Estados")]
    public class Estado
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public List<Libro> Libros { get; set; } = new();

    }

}
