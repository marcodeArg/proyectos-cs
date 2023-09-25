
namespace Biblioteca
{
  class Programa
  {
    private static void Main(string[] args)
    {
      List<Libro> libros = Libro.ObtenerLibros();
      List<Prestamo> prestamos = Prestamo.ObtenerPrestamos();

      foreach (Libro libro in libros)
      {
        int codigoLibro = libro.Codigo;

        foreach (Prestamo prestamo in prestamos)
        {
          // if (prestamo.CodigoLibro == codigoLibro)
          // {
          //   libro.AñadirPrestamo(prestamo);
          // }
        }

      }

      Console.Clear();

      //1. Cantidad libros por estado
      (int disponibles, int extraviados, int prestados) estados = CantidadPorEstado(libros);
      Console.WriteLine($"\nCantidad de libros disponibles: {estados.disponibles}");
      Console.WriteLine($"Cantidad de libros extraviados: {estados.extraviados}");
      Console.WriteLine($"Cantidad de libros prestados: {estados.prestados}");

      //2. Sumatoria del precio de reposición de todos los libros extraviados
      Console.WriteLine($"\nSumatoria del precio de reposición de todos los libros extraviados: {TotalExtraviados(libros)}");

      //3. Nombre de todos los solicitantes de un libro en particular identificado por su título
      Console.Write("\nIngrese el nombre del libro para saber las personas que lo solicitaron alguna vez: ");
      string nombreLibro = Console.ReadLine();

      List<string> nombres = ObtenerNombres(libros, nombreLibro);

      if (nombres.Count() > 0)
      {
        Console.WriteLine($"\nUsuarios que han solicitado el libro {nombreLibro}");

        foreach (string nombre in nombres)
        {
          Console.WriteLine($"{nombre}");
        }
      }
      else
      {
        Console.WriteLine($"\nNingun usuario ha solicitado el libro: {nombreLibro}");
      }


      //4. Promedio de veces que fueron prestados los libros de la biblioteca
      Console.WriteLine($"\nPromedio de prestamos {PromedioPrestamos(libros, prestamos)}");

    }


    private static (int, int, int) CantidadPorEstado(List<Libro> libros)
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

    private static decimal TotalExtraviados(List<Libro> libros)
    {
      List<Libro> librosExtraviados = libros.FindAll(x => x.Estado == Estado.Extraviado);
      decimal sumatoria = 0;

      foreach (Libro libro in librosExtraviados)
      {
        sumatoria += libro.PrecioReposicion;
      }

      return sumatoria;
    }


    private static List<string> ObtenerNombres(List<Libro> libros, string tituloLibro)
    {
      List<string> nombres = new List<string>();
      Libro? libro = libros.Find(x => x.Titulo == tituloLibro);

      if (libro is not null)
      {
        // foreach (Prestamo item in libro.Prestamos)
        // {
        //   nombres.Add(item.Nombre);
        // }
      }

      return nombres;
    }

    private static decimal PromedioPrestamos(List<Libro> libros, List<Prestamo> prestamos)
    {
      double promedioPrestamos = (double)prestamos.Count / libros.Count;

      return (decimal)promedioPrestamos;
    }
  }
}


