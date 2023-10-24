using System.Text;


namespace Biblioteca
{
  class Programa
  {
    private static void Main(string[] args)
    {
      Biblioteca biblio = new Biblioteca("Biblioteca1");


      // Carga de libros
      using (StreamReader sr = new StreamReader("./libros.txt", Encoding.UTF8))
      {
        while (!sr.EndOfStream)
        {
          string[] lineaLibros = sr.ReadLine().Split(";");

          int codigoLibro = Convert.ToInt32(lineaLibros[0]);
          string titulo = lineaLibros[1];
          decimal precioReposicion = Convert.ToDecimal(lineaLibros[2]);
          int estadoId = Convert.ToInt32(lineaLibros[3]);

          Libro libro = new Libro(titulo, precioReposicion, estadoId, 1);

          biblio.AgregarLibro(libro);
        }
      }

      using (StreamReader srPrestamo = new StreamReader("./prestamos.txt", Encoding.UTF8))
      {
        while (!srPrestamo.EndOfStream)
        {
          string[] lineaPrestamo = srPrestamo.ReadLine().Split(";");

          int idLibro = Convert.ToInt32(lineaPrestamo[0]);

          string nombre = lineaPrestamo[1];
          int diasPrestado = Convert.ToInt32(lineaPrestamo[2]);
          bool fueDevuelto = Convert.ToBoolean(lineaPrestamo[3]);

          biblio.AgregarPrestamo(new Prestamo(nombre, diasPrestado, fueDevuelto, idLibro));
        }
      }

      System.Console.WriteLine("SE CARGO TODO");
    }
  }
}



