using Microsoft.EntityFrameworkCore;

namespace Veterinaria
{
  public class Gestor
  {

    private VeterinariaContext contexto;

    public Gestor()
    {
      contexto = new VeterinariaContext();
    }

    public void añadirMascota()
    {
      Console.Clear();
      Console.Write("Ingrese el nombre de la mascota: ");
      string nombre = Console.ReadLine();

      Console.Write("Ingrese el numero de la especie de la mascota (1 Perro / 2 Gato / 3 Otro): ");
      Especie especie = (Especie)Convert.ToInt32(Console.ReadLine());

      Console.Write("La mascota es habitual? (s/n): ");
      string habitual = Console.ReadLine();
      bool esHabitual = habitual == "s";

      contexto.Mascotas.Add(new Mascota { Nombre = nombre, Especie = especie, EsHabitual = esHabitual });
      contexto.SaveChanges();
      Console.WriteLine("Mascota añadida con exito");
    }

    public void añadirAtencion()
    {
      Console.Clear();
      Console.Write("Ingrese el número del tipo de cobro (1 Efectivo / 2 Tarjeta de crédito): ");
      TipoCobro tc = (TipoCobro)Convert.ToInt32(Console.ReadLine());

      Console.Write("Ingrese el importe de la atención: ");
      decimal importe = Convert.ToDecimal(Console.ReadLine());

      Console.Write("Ingrese el ID de la mascota: ");
      int idMasc = Convert.ToInt32(Console.ReadLine());


      var mascotaExistente = contexto.Mascotas.Find(idMasc);

      if (mascotaExistente != null)
      {
        var nuevaAtencion = new AtencionMedica { TipoCobro = tc, Importe = importe, MascotaId = idMasc };
        contexto.AtencionMedicas.Add(nuevaAtencion);
        contexto.SaveChanges();
        Console.WriteLine("Atención añadida correctamente.");
      }
      else
      {
        Console.WriteLine("La mascota con el ID especificado no existe. No se pudo agregar la atención.");
      }
    }

    public void actualizarMascota()
    {
      Console.Clear();
      Console.Write("Ingrese el id de la mascota: ");
      int idMasc = Convert.ToInt32(Console.ReadLine());

      var mascota = contexto.Mascotas.FirstOrDefault(x => x.MascotaId == idMasc);

      if (mascota != null)
      {
        Console.Write("Ingrese el nombre de la mascota: ");
        string nombre = Console.ReadLine();
        mascota.Nombre = nombre;

        Console.Write("Ingrese el numero de la especie de la mascota (1 Perro / 2 Gato / 3 Otro): ");
        Especie especie = (Especie)Convert.ToInt32(Console.ReadLine());
        mascota.Especie = especie;

        Console.Write("La mascota es habitual? (s/n): ");
        string habitual = Console.ReadLine();
        bool esHabitual = habitual == "s";
        mascota.EsHabitual = esHabitual;

        contexto.SaveChanges();
        Console.WriteLine("Mascota actualizada con exito");
      }
      else
      {
        Console.WriteLine("La mascota con el ID especificado no existe.");
      }

    }

    public void actualizarAtencion()
    {
      Console.Clear();
      Console.Write("Ingrese el id de la atencion: ");
      int idAtencion = Convert.ToInt32(Console.ReadLine());

      var atencion = contexto.AtencionMedicas.FirstOrDefault(x => x.AtencionMedicaId == idAtencion);

      if (atencion != null)
      {
        Console.Write("Ingrese el numero del tipo de cobro (1 Efectivo / 2 Tarjeta de credito): ");
        TipoCobro tc = (TipoCobro)Convert.ToInt32(Console.ReadLine());
        atencion.TipoCobro = tc;

        Console.Write("Ingrese el importe de la atencion: ");
        decimal importe = Convert.ToDecimal(Console.ReadLine());
        atencion.Importe = importe;

        Console.Write("Ingrese el id de la mascota: ");
        int idMasc = Convert.ToInt32(Console.ReadLine());
        atencion.MascotaId = idMasc;

        contexto.SaveChanges();
        Console.WriteLine("Atencion actualizada con exito");

      }
      else
      {
        Console.WriteLine("La atencion con el ID especificado no existe.");
      }
    }

    public void eliminarMascota()
    {
      Console.Clear();
      Console.Write("Ingrese el id de la mascota: ");
      int idMasc = Convert.ToInt32(Console.ReadLine());

      var mascota = contexto.Mascotas.Include(x => x.Atenciones).FirstOrDefault(x => x.MascotaId == idMasc);

      if (mascota != null)
      {
        foreach (var item in mascota.Atenciones)
        {
          contexto.AtencionMedicas.Remove(item);
        }

        contexto.Mascotas.Remove(mascota);
        contexto.SaveChanges();
        Console.WriteLine("Mascota eliminada con exito");
      }
      else
      {
        Console.WriteLine("La mascota con el ID especificado no existe.");

      }
    }

    public void eliminarAtencion()
    {
      Console.Clear();
      Console.Write("Ingrese el id de la atencion: ");
      int idAtencion = Convert.ToInt32(Console.ReadLine());

      var atencion = contexto.AtencionMedicas.FirstOrDefault(x => x.AtencionMedicaId == idAtencion);

      if (atencion != null)
      {
        contexto.AtencionMedicas.Remove(atencion);
        contexto.SaveChanges();
        Console.WriteLine("Atencion eliminada con exito");
      }
      Console.WriteLine("La atencion con el ID especificado no existe.");

    }

    public void listarMascotas()
    {
      Console.Clear();
      List<Mascota> mascotas = contexto.Mascotas.ToList();

      foreach (var item in mascotas)
      {
        Console.WriteLine($"Id mascota:{item.MascotaId} - Nombre: {item.Nombre} - Especie: {item.Especie}");
      }
    }

    public void listarAtenciones()
    {
      Console.Clear();
      List<AtencionMedica> atenciones = contexto.AtencionMedicas.Include(a => a.Mascota).ToList();

      foreach (var item in atenciones)
      {
        Console.WriteLine($"Id atencion: {item.AtencionMedicaId} - Nombre mascota: {item.Mascota.Nombre} - Importe de la atencion: {item.ImporteACobrar():C}");
      }

    }
  }
}