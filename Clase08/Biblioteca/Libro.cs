namespace Biblioteca
{
  class Libro
  {
    public int Codigo { get; set; }
    public string Titulo { get; set; }
    public decimal PrecioReposicion { get; set; }
    public Estado Estado { get; set; }

    public List<Prestamo> Prestamos { get; }

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
  }
}

