using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Libro
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public decimal PrecioReposicion { get; set; }

        public int EstadoId { get; set; }

        public int BibliotecaId { get; set; }

        public virtual Biblioteca Biblioteca { get; set; }

        public virtual Estado Estado { get; set; }

        public virtual List<Prestamo> Prestamos { get; set; }

        public Libro()
        {

        }


        public Libro(string tit, decimal precio, int estado, int biblioteca)
        {
            Titulo = tit;
            PrecioReposicion = precio;
            EstadoId = estado;
            BibliotecaId = biblioteca;
            Prestamos = new();
        }
    }

}

