using System.IO.Compression;

namespace Biblioteca
{
  class Programa
  {
    private static void Main(string[] args)
    {
      List<Libro> libros = new List<Libro>();

      List<Prestamo> prestamos = new List<Prestamo>();

      using (StreamReader srLibro = new StreamReader("./libros.txt"))
      {
        while (!srLibro.EndOfStream)
        {
          string[] lineaLibros = srLibro.ReadLine().Split(",");


          int codigoLibro = Convert.ToInt32(lineaLibros[0]);
          string titulo = lineaLibros[1];
          decimal precioReposicion = Convert.ToDecimal(lineaLibros[2]);
          Estado estado = (Estado)Enum.Parse(typeof(Estado), lineaLibros[3]);

          List<Prestamo> prestamoss = new List<Prestamo>();


          using (StreamReader srPrestamo = new StreamReader("./prestamos.txt"))
          {
            while (!srPrestamo.EndOfStream)
            {
              string[] lineaPrestamo = srPrestamo.ReadLine().Split(",");
              int codigo = Convert.ToInt32(lineaPrestamo[0]);

              if (codigo == codigoLibro)
              {
                string nombre = lineaPrestamo[1];
                int diasPrestado = Convert.ToInt32(lineaPrestamo[2]);
                bool fueDevuelto = Convert.ToBoolean(lineaPrestamo[3]);
                prestamoss.Add(new Prestamo(nombre, diasPrestado, fueDevuelto));
              }

            }
          }

          libros.Add(new Libro(codigoLibro, titulo, precioReposicion, estado, prestamoss));

        }
      }


      Console.WriteLine("-------------");

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
      List<Prestamo> nombres = ObtenerNombres(libros, prestamos, nombreLibro);

      Console.WriteLine($"\nUsuarios que solicitaron el libro {nombreLibro}");
      foreach (Prestamo item in nombres)
      {
        Console.WriteLine($"{item.Nombre}");
      }

      //4. Promedio de veces que fueron prestados los libros de la biblioteca
      Console.WriteLine($"\nPromedio de prestamos {PromedioPrestamos(libros)}");

    }


    private static (int, int, int) CantidadPorEstado(List<Libro> libros)
    {
      int disponibles = libros.Count(x => x.Estado == Estado.Disponible);
      int extraviados = libros.Count(x => x.Estado == Estado.Extraviado);
      int prestados = libros.Count(x => x.Estado == Estado.Prestado);

      return (disponibles, extraviados, prestados);
    }

    private static decimal TotalExtraviados(List<Libro> libros)
    {
      return libros.Where(x => x.Estado == Estado.Extraviado).Sum(x => x.PrecioReposicion);
    }


    private static List<Prestamo> ObtenerNombres(List<Libro> libros, List<Prestamo> prestamo, string tituloLibro)
    {
      List<Prestamo> nombres = new List<Prestamo>();
      Libro? libro = libros.Find(x => x.Titulo == tituloLibro);

      if (libro is not null)
      {
        int codigo = libro.Codigo;
        nombres = prestamo.FindAll(x => x.CodigoLibro == codigo);
      }

      return nombres;
    }

    private static decimal PromedioPrestamos(List<Libro> libros)
    {
      int cantidadLibros = libros.Count();
      int cantidadLibrosPrestados = libros.Count(x => x.Estado == Estado.Prestado);

      return (decimal)cantidadLibros / cantidadLibrosPrestados;
    }
  }
}


