namespace Biblioteca
{
  public class GestorPrestamos
  {

    private BibliotecaContext contexto;

    public GestorPrestamos()
    {
      contexto = new();
    }

    public List<Prestamo> ObtenerPrestamos()
    {
      return contexto.Prestamos.ToList();
    }

    public Prestamo? ObtenerPrestamo(int id)
    {
      return contexto.Prestamos.Find(id);
    }

    public bool AgregarPrestamo(Prestamo p)
    {
      try
      {
        contexto.Prestamos.Add(p);
        contexto.SaveChanges();

        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }
    }


    public bool ActualizarPrestamo(int id, Prestamo p)
    {
      try
      {
        Prestamo? encontrado = ObtenerPrestamo(id);

        if (encontrado != null)
        {
          p.Id = encontrado.Id;
          contexto.Prestamos.Entry(encontrado).CurrentValues.SetValues(p);

          contexto.SaveChanges();
          return true;
        }

        return false;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }

    }

    public bool EliminarPrestamo(int id)
    {
      try
      {
        Prestamo? encontrado = ObtenerPrestamo(id);

        if (encontrado != null)
        {
          contexto.Prestamos.Remove(encontrado);
          contexto.SaveChanges();
          return true;
        }
        return false;
      }
      catch (Exception)
      {
        return false;
      }
    }

  }
}