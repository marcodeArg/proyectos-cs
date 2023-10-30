namespace Biblioteca
{
    public class Biblioteca
    {
        private GestorLibros gesLibros;
        private GestorPrestamos gesPrestamos;

        public Biblioteca()
        {
            gesLibros = new();
            gesPrestamos = new();
        }

        // Libros
        public Libro? ObtenerLibro(int id) => gesLibros.ObtenerLibro(id);
        public List<Libro> ObtenerLibros(string nombre) => gesLibros.ObtenerLibros(nombre);
        public bool AgregarLibro(Libro l) => gesLibros.AgregarLibro(l);
        public bool ActualizarLibro(int id, Libro l) => gesLibros.ActualizarLibro(id, l);
        public bool EliminarLibro(int id) => gesLibros.EliminarLibro(id);
        public List<Libro> ListarLibros() => gesLibros.ObtenerLibros();


        // Prestamos
        public Prestamo? ObtenerPrestamo(int id) => gesPrestamos.ObtenerPrestamo(id);
        public bool AgregarPrestamo(Prestamo p) => gesPrestamos.AgregarPrestamo(p);
        public bool ActualizarPrestamo(int id, Prestamo p) => gesPrestamos.ActualizarPrestamo(id, p);
        public List<Prestamo> ListarPrestamos(int idLib) => gesLibros.ObtenerPrestamos(idLib);


        // Consultas
        // 1.
        public (int, int, int) CantidadPorEstado() => gesLibros.CantidadPorEstado();
        // 2.
        public decimal TotalExtraviados() => gesLibros.TotalExtraviados();

        // 4.
        public double PromedioPrestamos() => (double)gesPrestamos.CantidadPrestamos() / gesLibros.CantidadLibros();

        // 5.
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

