using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class LibrosService
    {
        private readonly BibliotecaContext contexto = new();

        public List<Libro> ObtenerLibros()
        {
            return contexto.Libros.Include(x => x.Estado).ToList();
        }

        public Libro? ObtenerLibro(int id)
        {
            return contexto.Libros.Include(x => x.Estado).FirstOrDefault(l => l.Id == id);
        }

        public List<Libro> ObtenerLibros(string nombre)
        {
            return contexto.Libros.Where(l => l.Titulo.Contains(nombre)).Include(x => x.Estado).ToList();
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