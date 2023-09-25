namespace Biblioteca
{
  class Biblioteca
  {
    private List<Libro> libros;


    public Biblioteca()
    {
      libros = new List<Libro>();

      // cargo todo en este momento
      CargarLibros();
    }

    private void CargarLibros()
    {
      using (StreamReader sr = new StreamReader("./libros.txt"))
      {
        while (!sr.EndOfStream)
        {
          string[] lineaLibros = sr.ReadLine().Split(";");

          int codigoLibro = Convert.ToInt32(lineaLibros[0]);
          string titulo = lineaLibros[1];
          decimal precioReposicion = Convert.ToDecimal(lineaLibros[2]);
          Estado estado = (Estado)Convert.ToInt32(lineaLibros[3]);

          libros.Add(new Libro(codigoLibro, titulo, precioReposicion, estado));
        }
      }
    }


  }
}
