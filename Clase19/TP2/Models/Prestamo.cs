using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Prestamo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int DiasPrestamo { get; set; }

        public bool FueDevuelto { get; set; }

        public int LibroId { get; set; }

        public virtual Libro Libro { get; set; }

        public Prestamo()
        {

        }

        public Prestamo(string nomb, int dias, bool devuelto, int idLibro)
        {
            Nombre = nomb;
            DiasPrestamo = dias;
            FueDevuelto = devuelto;
            LibroId = idLibro;
        }
    }

}

