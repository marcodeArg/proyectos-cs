namespace Empresa
{
  class Program
  {
    private static void Main(string[] args)
    {
      List<Empleado> empleados = Datos.ProcesamientoDatos();

      // Primer punto
      Console.WriteLine($"{Datos.TotalSueldos(empleados):C}");

      // Segundo punto
      (int obreros, int administradores, int vendedores) cantidadEmpleados = Datos.CantidadEmpleados(empleados);
      Console.WriteLine($"\nCantidad obreros {cantidadEmpleados.obreros,15}");
      Console.WriteLine($"Cantidad administradores {cantidadEmpleados.administradores,7}");
      Console.WriteLine($"Cantidad vendedores {cantidadEmpleados.vendedores,13}\n");

      // Tercer punto
      Empleado empleado = Datos.SueldoEmpleado(empleados, 1523);
      if (empleado != null)
      {
        Console.WriteLine(empleado);
      }
      else
      {
        Console.WriteLine("No se encontro el legajo solicitado");
      }
    }
  }
}
