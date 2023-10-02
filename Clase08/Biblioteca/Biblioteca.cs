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

      int disponibles = 0;
      int extraviados = 0;
      int prestados = 0;

      foreach (Libro libro in libros)
      {
        if (libro.Estado == Estado.Disponible)
        {
          disponibles++;
        }
        else if (libro.Estado == Estado.Extraviado)
        {
          extraviados++;
        }
        else
        {
          prestados++;
        }
      }

      return (disponibles, extraviados, prestados);
    }

    // 2.
    public decimal TotalExtraviados()
    {
      List<Libro> librosExtraviados = libros.FindAll(x => x.Estado == Estado.Extraviado);
      decimal sumatoria = 0;

      foreach (Libro libro in librosExtraviados)
      {
        sumatoria += libro.PrecioReposicion;
      }

      return sumatoria;
    }

    // 3.
    public List<string> ObtenerNombres(string tituloLibro)
    {
      List<string> nombres = new List<string>();
      Libro? libro = libros.Find(x => x.Titulo == tituloLibro);

      if (libro is not null)
      {
        foreach (Prestamo item in libro.Prestamos)
        {
          nombres.Add(item.Nombre);
        }
      }

      return nombres;
    }

    // 4.
    public decimal PromedioPrestamos()
    {
      int cantidadLibros = libros.Count;
      int cantidadPrestamos = 0;

      foreach (Libro libro in libros)
      {
        cantidadPrestamos += libro.CantidadPrestamos();
      }

      decimal promedioPrestamos = (decimal)cantidadPrestamos / cantidadLibros;

      return promedioPrestamos;
    }

  }
}