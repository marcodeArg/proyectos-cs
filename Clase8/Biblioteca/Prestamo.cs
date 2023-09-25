namespace Biblioteca
{
  class Prestamo
  {
    // public int CodigoLibro { get; set; }
    public string Nombre { get; set; }
    public int DiasPrestado { get; set; }
    public bool FueDevuelto { get; set; }


    public Prestamo(int codigoLibro, string nomb, int prestados, bool devuelto)
    {
      // CodigoLibro = codigoLibro;
      Nombre = nomb;
      DiasPrestado = prestados;
      FueDevuelto = devuelto;
    }














    public static List<Prestamo> ObtenerPrestamos()
    {
      List<Prestamo> prestamos = new List<Prestamo>();


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

      return prestamos;
    }
  }
}

