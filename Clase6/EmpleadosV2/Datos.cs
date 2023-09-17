namespace Empresa
{
  class Datos
  {
    public static List<Empleado> ProcesamientoDatos()
    {
      List<Empleado> empleados = new List<Empleado>();

      using (StreamReader sr = new StreamReader("./empleados.csv"))
      {
        while (!sr.EndOfStream)
        {
          string[] linea = sr.ReadLine().Split(";");
          string tipoEmpleado = linea[0];
          int legajo = Convert.ToInt16(linea[1]);
          string nombre = $"{linea[2]} {linea[3]}";
          decimal sueldobase = Convert.ToDecimal(linea[4]);

          empleados.Add(tipoEmpleado switch
          {
            "1" => new Obrero(legajo, nombre, sueldobase, Convert.ToInt16(linea[5])),
            "2" => new Administrativo(legajo, nombre, sueldobase, Convert.ToBoolean(linea[5])),
            "3" => new Vendedor(legajo, nombre, sueldobase, Convert.ToDecimal(linea[5])),
            _ => throw new Exception("Una fila fue cargada incorrectamente")
          });
        }
      }

      return empleados;
    }

    // Primer punto
    public static decimal TotalSueldos(List<Empleado> empleados)
    {
      decimal total = 0;

      foreach (Empleado e in empleados)
      {
        total += e.Sueldo();
      }

      return total;
    }

    // Segundo punto 
    public static (int, int, int) CantidadEmpleados(List<Empleado> empleados)
    {
      int cantObreros = 0;
      int cantAdministrativos = 0;
      int cantVendedores = 0;

      foreach (Empleado e in empleados)
      {
        if (e is Obrero)
        {
          cantObreros++;
        }
        else if (e is Administrativo)
        {
          cantAdministrativos++;
        }
        else
        {
          cantVendedores++;
        }
      }

      return (cantObreros, cantAdministrativos, cantVendedores);
    }

    // Tercer punto 
    public static Empleado SueldoEmpleado(List<Empleado> empleados, int legajo)
    {
      Empleado? em = empleados.Find(x => x.Legajo == legajo);

      return em;
    }

  }
}