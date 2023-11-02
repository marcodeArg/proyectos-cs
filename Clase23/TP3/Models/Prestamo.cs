using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Prestamos")]
    public class Prestamo
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int DiasPrestamo { get; set; }

        public bool FueDevuelto { get; set; }

        public int LibroId { get; set; }

        public Libro Libro { get; set; }

    }

}

