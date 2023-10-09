using Microsoft.VisualBasic;

namespace Municipalidad
{
  public class Program
  {

    public static void Main()
    {
      Sistema s = new();

      string msg = """
      Seleccione una opcion
      1. Cargar planes de pago manualmente
      2. Cargar planes de pago con los datos de prueba
      >> 
      """;

      int op = Auxiliares.ValidarOpcionNumero(msg, 1, 2);

      if (op == 1)
      {
        s.CargarPorTeclado();
      }
      else
      {
        s.CargarDatosPrueba();
      }

      Console.WriteLine("\nDatos cargados correctamente!");

      Console.WriteLine($"\n1. Cantidad de planes pagados en su totalidad: {s.CantidadPlanesPagados}");
      Console.WriteLine($"2. Sumatoria de las deudas registradas: {s.TotalDeudas:C}");
      Console.Write($"3. Ingrese el nombre del contribuyente: ");
      string nombre = Console.ReadLine()?.ToLower() ?? " ";

      List<Cuota> cuotasContribullente = s.PagosContribuyente(nombre);

      if (cuotasContribullente.Count <= 0)
      {
        Console.WriteLine($"No existe ningun contribuyente con ese nombre o no se registro ninguna cuota");
      }
      else
      {
        foreach (Cuota c in cuotasContribullente)
        {
          Console.WriteLine(c);
        }
      }

      Console.WriteLine($"4. Promedio de los intereses SIN INCLUIR cuotas en las que no hubo interes: {s.PromedioIntereses:C}");
      Console.WriteLine($"4. Promedio de TODOS los intereses incluyendo cuotas en las que no hubo interes: {s.PromedioIntereses1:C}");
    }
  }
}