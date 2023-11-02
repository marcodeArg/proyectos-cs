using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class LibrosService
    {
        private readonly BibliotecaContext contexto = new();

        public List<Libro> ObtenerLibros()
        {
            return contexto.Libros.ToList();
        }

        public Libro? ObtenerLibro(int id)
        {
            return contexto.Libros.FirstOrDefault(l => l.Id == id);
        }

        public List<Libro> ObtenerLibros(string nombre)
        {
            return contexto.Libros.Where(l => l.Titulo.Contains(nombre)).ToList();
        }

        public List<Prestamo> ObtenerPrestamos(int id)
        {
            var libro = contexto.Libros.Include(l => l.Prestamos).FirstOrDefault(l => l.Id == id);

            if (libro != null)
            {
                return libro.Prestamos;
            }
            return new();
        }

    }
}