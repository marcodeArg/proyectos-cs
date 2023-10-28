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

        public List<Prestamo> Prestamos { get; set; }

        public Libro(string tit, decimal precio, int estado)
        {
            Titulo = tit;
            PrecioReposicion = precio;
            EstadoId = estado;
            Prestamos = new();
        }
    }

}

