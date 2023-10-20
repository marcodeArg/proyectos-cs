using Microsoft.EntityFrameworkCore;

namespace Veterinaria
{
  class Program
  {
    public static void Main()
    {
      Gestor g = new();

      string msg = """

      1. Añadir mascota
      2. Añadir atencion medica
      3. Actualizar mascota
      4. Actualizar atencion medica
      5. Eliminar mascota
      6. Eliminar atencion medica
      7. Listar mascotas 
      8. Listar atenciones medicas
      9. Salir
      >>> 
      """;


      while (true)
      {
        Console.Write(msg);
        int op = Convert.ToInt32(Console.ReadLine());

        switch (op)
        {
          case 1:
            g.añadirMascota();
            break;
          case 2:
            g.añadirAtencion();
            break;
          case 3:
            g.actualizarMascota();
            break;
          case 4:
            g.actualizarAtencion();
            break;
          case 5:
            g.eliminarMascota();
            break;
          case 6:
            g.eliminarAtencion();
            break;
          case 7:
            g.listarMascotas();
            break;
          case 8:
            g.listarAtenciones();
            break;
          case 9:
            return;
          default:
            Console.WriteLine("La opcion ingresada no existe");
            break;
        }
      }
    }
  }
}