using Biblioteca.DTOs;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class LibrosService
    {
        private readonly BibliotecaContext contexto = new();

        public int CantidadLibros()
        {
            return contexto.Libros.Count();
        }

        public List<Libro> ObtenerLibros()
        {
            return contexto.Libros.Include(x => x.Estado).ToList();
        }

        public List<Libro> ObtenerLibros(string nombre)
        {
            return contexto.Libros.Where(l => l.Titulo.Contains(nombre)).Include(x => x.Estado).ToList();
        }

        public Libro? ObtenerLibro(int id)
        {
            return contexto.Libros.Include(x => x.Estado).FirstOrDefault(l => l.Id == id);
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

        public bool AgregarLibro(Libro l)
        {
            try
            {
                contexto.Libros.Add(l);
                contexto.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarLibro(int id, Libro l)
        {
            try
            {
                Libro? encontrado = ObtenerLibro(id);

                if (encontrado != null)
                {

                    l.Id = encontrado.Id;
                    contexto.Libros.Entry(encontrado).CurrentValues.SetValues(l);

                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool EliminarLibro(int id)
        {
            try
            {
                Libro? encontrado = ObtenerLibro(id);

                if (encontrado != null)
                {
                    foreach (var p in encontrado.Prestamos)
                    {
                        contexto.Prestamos.Remove(p);
                    }
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public (int, int, int) CantidadPorEstado()
        {
            var query = from l in contexto.Libros
                        group l by l.EstadoId into g
                        select new { Estado = g.Key, Cantidad = g.Count() };

            var listaGrupos = query.ToList();

            int cantDisponible = listaGrupos.FirstOrDefault(g => g.Estado == 1)?.Cantidad ?? 0;
            int cantPrestados = listaGrupos.FirstOrDefault(g => g.Estado == 2)?.Cantidad ?? 0;
            int cantExtraviados = listaGrupos.FirstOrDefault(g => g.Estado == 3)?.Cantidad ?? 0;

            return (cantDisponible, cantPrestados, cantExtraviados);
        }

        // Sumatoria del precio de reposición de todos los libros extraviados
        public decimal TotalExtraviados()
        {
            return contexto.Libros.Where(l => l.EstadoId == 3).Sum(l => l.PrecioReposicion);
        }

        // Personas que solicitaron el mismo libro mas de una vez
        public List<SolicitudesLibrosDTO> LibrosSolicitadosMasDeUnaVez()
        {
            var libros = ObtenerLibros();

            var resultado = new List<SolicitudesLibrosDTO>();

            foreach (var libro in libros)
            {
                var prestamos = ObtenerPrestamos(libro.Id);

                var grupos = prestamos
                    .GroupBy(p => p.Nombre)
                    .Where(g => g.Count() > 1)
                    .Select(g => new SolicitudesLibrosDTO(g.Key, libro.Titulo, g.Count()))
                    .ToList();

                resultado.AddRange(grupos);
            }

            return resultado;
        }

    }
}