using System.Text;


namespace Biblioteca
{
  class Programa
  {
    private static void Main(string[] args)
    {
      Biblioteca biblio = new Biblioteca();


      // Carga de libros
      using (StreamReader sr = new StreamReader("./libros.txt", Encoding.UTF8))
      {
        while (!sr.EndOfStream)
        {
          string[] lineaLibros = sr.ReadLine().Split(";");

          int codigoLibro = Convert.ToInt32(lineaLibros[0]);
          string titulo = lineaLibros[1];
          decimal precioReposicion = Convert.ToDecimal(lineaLibros[2]);
          Estado estado = (Estado)Convert.ToInt32(lineaLibros[3]);

          Libro libro = new Libro(codigoLibro, titulo, precioReposicion, estado);

          using (StreamReader srPrestamo = new StreamReader("./prestamos.txt", Encoding.UTF8))
          {
            while (!srPrestamo.EndOfStream)
            {
              string[] lineaPrestamo = srPrestamo.ReadLine().Split(";");

              int idLibro = Convert.ToInt32(lineaPrestamo[0]);

              if (idLibro == codigoLibro)
              {
                string nombre = lineaPrestamo[1];
                int diasPrestado = Convert.ToInt32(lineaPrestamo[2]);
                bool fueDevuelto = Convert.ToBoolean(lineaPrestamo[3]);

                libro.AñadirPrestamo(new Prestamo(nombre, diasPrestado, fueDevuelto));
              }
            }
          }
          biblio.AgregarLibro(libro);
        }


        Console.Clear();

        //1. Cantidad libros por estado
        (int disponibles, int extraviados, int prestados) estados = biblio.CantidadPorEstado();
        Console.WriteLine($"\nCantidad de libros disponibles: {estados.disponibles}");
        Console.WriteLine($"Cantidad de libros extraviados: {estados.extraviados}");
        Console.WriteLine($"Cantidad de libros prestados: {estados.prestados}");

        //2. Sumatoria del precio de reposición de todos los libros extraviados
        Console.WriteLine($"\nSumatoria del precio de reposición de todos los libros extraviados: {biblio.TotalExtraviados()}");

        //3. Nombre de todos los solicitantes de un libro en particular identificado por su título
        Console.Write("\nIngrese el nombre del libro para saber las personas que lo solicitaron alguna vez: ");
        string nombreLibro = Console.ReadLine();

        List<string> nombres = biblio.ObtenerNombres(nombreLibro);

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
        Console.WriteLine($"\nPromedio de prestamos {biblio.PromedioPrestamos}");

      }
    }
  }
}


