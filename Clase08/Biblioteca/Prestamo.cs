namespace Biblioteca
{
  class Prestamo
  {
    public string Nombre { get; set; }
    public int DiasPrestado { get; set; }
    public bool FueDevuelto { get; set; }


    public Prestamo(string nomb, int prestados, bool devuelto)
    {
      Nombre = nomb;
      DiasPrestado = prestados;
      FueDevuelto = devuelto;
    }
  }
}

