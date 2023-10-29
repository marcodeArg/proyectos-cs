using System;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Biblioteca
    {
        public List<Libro> Libros { get; } = new();

        private GestorBiblioteca gesBiblio;
        private GestorLibros gesLibros;
        private GestorPrestamos gesPrestamos;


        public Biblioteca()
        {
            gesBiblio = new();
            gesLibros = new();
            gesPrestamos = new();
        }

        public bool AgregarLibro(Libro l) => gesLibros.AgregarLibro(l);
        public bool ActualizarLibro(int id, Libro l) => gesLibros.ActualizarLibro(id, l);
        public bool EliminarLibro(int id) => gesLibros.EliminarLibro(id);
        public List<Libro> ListarLibros() => gesLibros.ObtenerLibros();


        public bool AgregarPrestamo(Prestamo p) => gesPrestamos.AgregarPrestamo(p);
        public bool ActualizarPrestamo(int id, Prestamo p) => gesPrestamos.ActualizarPrestamo(id, p);
        public bool EliminarPrestamo(int id) => gesPrestamos.EliminarPrestamo(id);
        public List<Prestamo> ListarPrestamos(int idLib) => gesLibros.ObtenerPrestamos(idLib);




    }

}

