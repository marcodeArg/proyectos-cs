namespace Municipalidad
{
  public class Sistema
  {
    private List<PlanPago> planes;

    public Sistema()
    {
      planes = new();
    }

    public void AñadirPlan(PlanPago p)
    {
      planes.Add(p);
    }

    public void CargarDatosPrueba()
    {
      using (StreamReader srPlanes = new("./DatosPrueba/Planes.txt"))
      {
        while (!srPlanes.EndOfStream)
        {
          string[] lineaPlan = srPlanes.ReadLine().Split(",");

          int idPlan = Convert.ToInt32(lineaPlan[0]);
          string nombre = lineaPlan[1].ToLower();
          decimal totalDeuda = Convert.ToDecimal(lineaPlan[2]);
          int cantidadCuotas = Convert.ToInt32(lineaPlan[3]);

          PlanPago plan = new(nombre, totalDeuda, cantidadCuotas);

          AñadirPlan(plan);

          using (StreamReader srCuotas = new("./DatosPrueba/Cuotas.txt"))
          {
            while (!srCuotas.EndOfStream)
            {
              string[] lineaCuota = srCuotas.ReadLine().Split(",");

              int idCuota = Convert.ToInt32(lineaCuota[0]);

              if (idPlan == idCuota)
              {
                int diaPago = Convert.ToInt32(lineaCuota[1]);
                plan.AñadirPagoCuota(new Cuota(diaPago, plan.PagoPorCuota));
              }
            }
          }
        }

      }
    }

    public void CargarPorTeclado()
    {
      Console.WriteLine("Bienvenido");

      string? op = "s";

      while (op != "n")
      {
        Console.Write("\nIngrese el nombre del beneficiario del plan: ");
        string nombre = Console.ReadLine().ToLower();

        Console.Write("Ingrese el total de la deuda: ");
        decimal totalDeuda = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Ingrese la cantidad de cuotas: ");
        int cantidadCuotas = Convert.ToInt32(Console.ReadLine());

        PlanPago plan = new(nombre, totalDeuda, cantidadCuotas);

        Console.WriteLine(" ");
        string cargarCuota = Auxiliares.ValidarOpcionTexto("Desea cargar pagos de cuotas (s/n): ");

        AñadirPlan(plan);

        while (cargarCuota != "n")
        {
          Console.WriteLine(" ");
          Console.Write("Dia del mes que se pago la cuota: ");
          int diaPago = Convert.ToInt32(Console.ReadLine());

          plan.AñadirPagoCuota(new Cuota(diaPago, plan.PagoPorCuota));

          if (cantidadCuotas == plan.CantidadCuotasPagas)
          {
            Console.WriteLine("\nYa se pagaron todas las cuotas!");
            break;
          }
          Console.WriteLine(" ");
          cargarCuota = Auxiliares.ValidarOpcionTexto("Cargar otra cuota?(s/n): ");
        }
        Console.WriteLine(" ");
        op = Auxiliares.ValidarOpcionTexto("Desea cargar otro beneficiario?(s/n): ");
      }
    }
    // 1.
    public int CantidadPlanesPagados => planes.Count(x => x.CantidadCuotas == x.CantidadCuotasPagas);
    // 2.
    public decimal TotalDeudas => planes.Sum(x => x.TotalDeuda);

    // 3.
    public List<Cuota> PagosContribuyente(string nombreContribuyente)
    {
      List<Cuota> cuotas = new();

      var query = from p in planes where p.NombreContribuyente == nombreContribuyente select p.CuotasPagas;

      return query.SelectMany(x => x).ToList();
    }


    // 4.
    // Promedio de los intereses SIN CONTAR las cuotas en las que NO hubo demora y por lo tanto tampoco interes
    public decimal PromedioIntereses
    {
      get
      {
        decimal totalIntereses = planes
            .SelectMany(plan => plan.CuotasPagas)
            .Where(cuota => cuota.ImporteDeIntereses != 0)
            .Select(cuota => cuota.ImporteDeIntereses)
            .Sum();

        int totalCuotasPagadas = planes
            .SelectMany(plan => plan.CuotasPagas)
            .Count(cuota => cuota.ImporteDeIntereses != 0);

        if (totalCuotasPagadas == 0)
        {
          return 0;
        }

        return totalIntereses / totalCuotasPagadas;
      }
    }

    // Promedio de TODOS los intereses incluyendo en las que no hubo demora y por lo tanto tampoco interes
    public decimal PromedioIntereses1
    {
      get
      {

        decimal totalIntereses = planes
            .SelectMany(plan => plan.CuotasPagas)
            .Select(cuota => cuota.ImporteDeIntereses)
            .Sum();

        int totalCuotasPagadas = planes
            .Select(plan => plan.CantidadCuotasPagas)
            .Sum();

        if (totalCuotasPagadas == 0)
        {
          return 0;
        }

        return totalIntereses / totalCuotasPagadas;
      }
    }


  }
}