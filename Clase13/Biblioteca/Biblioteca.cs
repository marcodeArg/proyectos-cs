using System.Linq;
using System.Security.Cryptography;

namespace Biblioteca
{
  class Biblioteca
  {
    private List<Libro> libros;


    public Biblioteca()
    {
      libros = new List<Libro>();
    }

    public void AgregarLibro(Libro libro)
    {
      libros.Add(libro);
    }

    // 1.
    public (int, int, int) CantidadPorEstado()
    {

      int[] vec = { 0, 0, 0, 0 };
      libros.ForEach(libro => vec[(int)libro.Estado]++);

      return (vec[1], vec[2], vec[3]);
    }

    // 2.
    public decimal TotalExtraviados()
    {
      return libros.Where(x => x.Estado == Estado.Extraviado).Sum(x => x.PrecioReposicion);
    }

    // 3.
    public List<string> ObtenerNombres(string tituloLibro)
    {
      return libros.FirstOrDefault(x => x.Titulo == tituloLibro)?.Solicitantes ?? new List<string>();
    }

    // 4.
    public double PromedioPrestamos => libros.Average(x => x.CantidadPrestamos);
  }
}