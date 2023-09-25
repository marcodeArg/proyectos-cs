namespace Biblioteca
{
  class Libro
  {
    public int Codigo { get; set; }
    public string Titulo { get; set; }
    public decimal PrecioReposicion { get; set; }
    public Estado Estado { get; set; }

    private List<Prestamo> Prestamos { get; }

    public Libro(int codigo, string titulo, decimal precioReposicion, Estado estado)
    {
      Codigo = codigo;
      Titulo = titulo;
      PrecioReposicion = precioReposicion;
      Estado = estado;

      Prestamos = new List<Prestamo>();
    }

    public void AñadirPrestamo(Prestamo prestamo)
    {
      Prestamos.Add(prestamo);
    }

    public int CantidadPrestamos()
    {
      return Prestamos.Count;
    }





























    public static List<Libro> ObtenerLibros()
    {
      List<Libro> libros = new List<Libro>();

      using (StreamReader sr = new StreamReader("./libros.txt"))
      {
        while (!sr.EndOfStream)
        {
          string[] lineaLibros = sr.ReadLine().Split(",");

          int codigoLibro = Convert.ToInt32(lineaLibros[0]);
          string titulo = lineaLibros[1];
          decimal precioReposicion = Convert.ToDecimal(lineaLibros[2]);
          Estado estado = (Estado)Enum.Parse(typeof(Estado), lineaLibros[3]);

          libros.Add(new Libro(codigoLibro, titulo, precioReposicion, estado));


          // using (StreamReader srPrestamo = new StreamReader("./prestamos.txt"))
          // {
          //   while (!srPrestamo.EndOfStream)
          //   {
          //     string[] lineaPrestamo = srPrestamo.ReadLine().Split(",");

          //     int codigoLibro = Convert.ToInt32(lineaPrestamo[0]);
          //     string nombre = lineaPrestamo[1];
          //     int diasPrestado = Convert.ToInt32(lineaPrestamo[2]);
          //     bool fueDevuelto = Convert.ToBoolean(lineaPrestamo[3]);
          //     prestamos.Add(new Prestamo(codigoLibro, nombre, diasPrestado, fueDevuelto));
          //   }

          // }





        }
      }

      return libros;
    }
  }
}

