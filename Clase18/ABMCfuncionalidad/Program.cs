using Microsoft.EntityFrameworkCore;

namespace Veterinaria
{
  class Program
  {
    private static VeterinariaContext contexto = new VeterinariaContext();
    public static void Main()
    {
      string msg = """
      1. Añadir mascota
      2. Añadir atencion medica
      3. Actualizar mascota
      4. Actualizar atencion medica
      5. Eliminar mascota
      6. Eliminar atencion medica
      7. Listar mascotas 
      8. Listar atenciones medicas
      """;


      while (true)
      {
        Console.Write(msg);
        int op = Convert.ToInt32(Console.ReadLine());

        switch (op)
        {
          case 1:
            añadirMascota();
            break;
          case 2:
            añadirAtencion();
            break;
          case 3:
            actualizarMascota();
            break;
          case 4:
            actualizarAtencion();
            break;
          case 5:
            eliminarMascota();
            break;
          case 6:
            eliminarAtencion();
            break;
          case 7:
            listarMascotas();
            break;
          case 8:
            listarAtenciones();
            break;
          default:
            Console.WriteLine("La opcion ingresada no existe");
            break;
        }
      }
    }


    private static void añadirMascota()
    {
      Console.WriteLine("Ingrese el nombre de la mascota: ");
      string nombre = Console.ReadLine();

      Console.WriteLine("Ingrese el numero de la especie de la mascota (1 Perro / 2 Gato / 3 Otro): ");
      Especie especie = (Especie)Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("La mascota es habitual? (s/n): ");
      string habitual = Console.ReadLine();
      bool esHabitual = habitual == "s";

      contexto.Mascotas.Add(new Mascota { Nombre = nombre, Especie = especie, EsHabitual = esHabitual });
      contexto.SaveChanges();
    }

    public static void añadirAtencion()
    {
      Console.WriteLine("Ingrese el numero del tipo de cobro (1 Efectivo / 2 Tarjeta de credito): ");
      TipoCobro tc = (TipoCobro)Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Ingrese el importe de la atencion: ");
      decimal importe = Convert.ToDecimal(Console.ReadLine());

      Console.WriteLine("Ingrese el id de la mascota: ");
      int idMasc = Convert.ToInt32(Console.ReadLine());

      contexto.AtencionMedicas.Add(new AtencionMedica { TipoCobro = tc, Importe = importe, IdMascota = idMasc });
      contexto.SaveChanges();
    }

    private static void actualizarMascota()
    {
      Console.WriteLine("Ingrese el id de la mascota: ");
      int idMasc = Convert.ToInt32(Console.ReadLine());

      var mascota = contexto.Mascotas.FirstOrDefault(x => x.MascotaId == idMasc);

      if (mascota != null)
      {
        Console.WriteLine("Ingrese el nombre de la mascota: ");
        string nombre = Console.ReadLine();
        mascota.Nombre = nombre;

        Console.WriteLine("Ingrese el numero de la especie de la mascota (1 Perro / 2 Gato / 3 Otro): ");
        Especie especie = (Especie)Convert.ToInt32(Console.ReadLine());
        mascota.Especie = especie;

        Console.WriteLine("La mascota es habitual? (s/n): ");
        string habitual = Console.ReadLine();
        bool esHabitual = habitual == "s";
        mascota.EsHabitual = esHabitual;

        contexto.SaveChanges();
      }
    }

    public static void actualizarAtencion()
    {
      Console.WriteLine("Ingrese el id de la atencion: ");
      int idAtencion = Convert.ToInt32(Console.ReadLine());

      var atencion = contexto.AtencionMedicas.FirstOrDefault(x => x.AtencionMedicaId == idAtencion);

      if (atencion != null)
      {
        Console.WriteLine("Ingrese el numero del tipo de cobro (1 Efectivo / 2 Tarjeta de credito): ");
        TipoCobro tc = (TipoCobro)Convert.ToInt32(Console.ReadLine());
        atencion.TipoCobro = tc;

        Console.WriteLine("Ingrese el importe de la atencion: ");
        decimal importe = Convert.ToDecimal(Console.ReadLine());
        atencion.Importe = importe;

        Console.WriteLine("Ingrese el id de la mascota: ");
        int idMasc = Convert.ToInt32(Console.ReadLine());
        atencion.IdMascota = idMasc;

        contexto.SaveChanges();
      }
    }

    public static void eliminarMascota()
    {
      Console.WriteLine("Ingrese el id de la mascota: ");
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
      }
    }

    public static void eliminarAtencion()
    {
      Console.WriteLine("Ingrese el id de la atencion: ");
      int idAtencion = Convert.ToInt32(Console.ReadLine());

      var atencion = contexto.AtencionMedicas.FirstOrDefault(x => x.AtencionMedicaId == idAtencion);

      if (atencion != null)
      {
        contexto.AtencionMedicas.Remove(atencion);
        contexto.SaveChanges();
      }
    }

    public static void listarMascotas()
    {
      List<Mascota> mascotas = contexto.Mascotas.Include(x => x.Atenciones).ToList();

      foreach (var item in mascotas)
      {

      }


    }
  }
}