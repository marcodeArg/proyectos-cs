using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca
{
    [Table("Libros")]
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public decimal PrecioReposicion { get; set; }

        public int EstadoId { get; set; }

        public Estado Estado { get; set; }

        public List<Prestamo> Prestamos { get; set; } = new();

        public override string ToString()
        {
            return $"Codigo: {Id} - Titulo: {Titulo}";
        }
    }

}

