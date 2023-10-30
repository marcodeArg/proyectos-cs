namespace Biblioteca
{
  public class GestorBiblioteca
  {
    private BibliotecaContext contexto;

    public GestorBiblioteca()
    {
      contexto = new();
    }

    // Primer punto


    // Segundo punto


    // Tercer punto resuelto el Libro

    // Cuarto punto
    public double PromedioPrestamos()
    {
      return (double)contexto.Prestamos.Count() / contexto.Libros.Count();
    }


  }
}