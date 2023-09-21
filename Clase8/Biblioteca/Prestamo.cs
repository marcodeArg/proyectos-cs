namespace Biblioteca
{
  class Prestamo
  {
    public int CodigoLibro { get; set; }
    public string Nombre { get; set; }
    public int DiasPrestado { get; set; }
    public bool FueDevuelto { get; set; }


    public Prestamo(string nomb, int prestados, bool devuelto)
    {
      Nombre = nomb;
      DiasPrestado = prestados;
      FueDevuelto = devuelto;
    }


    public static List<Prestamo> ObtenerLibros()
    {
      List<Prestamo> prestamos = new List<Prestamo>();


      using (StreamReader srPrestamo = new StreamReader("./prestamos.txt"))
      {
        while (!srPrestamo.EndOfStream)
        {
          string[] lineaPrestamo = srPrestamo.ReadLine().Split(",");
          string nombre = lineaPrestamo[1];
          int diasPrestado = Convert.ToInt32(lineaPrestamo[2]);
          bool fueDevuelto = Convert.ToBoolean(lineaPrestamo[3]);
          prestamos.Add(new Prestamo(nombre, diasPrestado, fueDevuelto));
        }

      }

      return prestamos;
    }


  }
}

