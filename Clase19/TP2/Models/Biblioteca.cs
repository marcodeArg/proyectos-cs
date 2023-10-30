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

        public Libro? ObtenerLibro(int id) => gesLibros.ObtenerLibro(id);
        public bool AgregarLibro(Libro l) => gesLibros.AgregarLibro(l);
        public bool ActualizarLibro(int id, Libro l) => gesLibros.ActualizarLibro(id, l);
        public bool EliminarLibro(int id) => gesLibros.EliminarLibro(id);
        public List<Libro> ListarLibros() => gesLibros.ObtenerLibros();

        public Prestamo? ObtenerPrestamo(int id) => gesPrestamos.ObtenerPrestamo(id);
        public bool AgregarPrestamo(Prestamo p) => gesPrestamos.AgregarPrestamo(p);
        public bool ActualizarPrestamo(int id, Prestamo p) => gesPrestamos.ActualizarPrestamo(id, p);
        public List<Prestamo> ListarPrestamos(int idLib) => gesLibros.ObtenerPrestamos(idLib);


        // Consultas
        // 1.
        public (int, int, int) CantidadPorEstado() => gesLibros.CantidadPorEstado();
        // 2.
        public decimal TotalExtraviados() => gesLibros.TotalExtraviados();

        // 3. MODIFICAR
        public List<Prestamo> NombreSolicitantes(string nombreLibro)
        {
            List<Libro> libros = gesLibros.ObtenerLibros(nombreLibro);

            if (libros.Count > 1)
            {
                Console.WriteLine();
                foreach (var item in libros)
                {
                    Console.WriteLine(item);
                }

                Console.Write("\nIngrese el id del libro del que desea conocer los prestamos: ");
                int idLib = Convert.ToInt32(Console.ReadLine());

                return gesLibros.ObtenerPrestamos(idLib);
            }

            Console.WriteLine(libros[0]);
            return gesLibros.ObtenerPrestamos(libros[0].Id);
        }

        // 4.
        public double PromedioPrestamos() => (double)gesPrestamos.CantidadPrestamos() / gesLibros.CantidadLibros();

        public List<(string Solicitante, string TituloLibro, int CantidadPrestamos)> LibrosSolicitadosMasDeUnaVez()
        {
            var libros = gesLibros.ObtenerLibros();

            var resultado = new List<(string Solicitante, string TituloLibro, int CantidadPrestamos)>();

            foreach (var libro in libros)
            {
                var prestamos = gesLibros.ObtenerPrestamos(libro.Id);

                var grupos = prestamos
                    .GroupBy(p => p.Nombre)
                    .Where(g => g.Count() > 1)
                    .Select(g => (g.Key, libro.Titulo, g.Count()))
                    .ToList();

                resultado.AddRange(grupos);
            }

            return resultado;
        }





    }

}

