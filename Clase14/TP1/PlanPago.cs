namespace Municipalidad
{
  public class PlanPago
  {
    public string NombreContribuyente { get; set; }
    public decimal TotalDeuda { get; set; }
    public int CantidadCuotas { get; set; }
    public List<Cuota> CuotasPagas { get; }

    public PlanPago(string nom, decimal totalDeuda, int cantCuotas)
    {
      NombreContribuyente = nom;
      TotalDeuda = totalDeuda;
      CantidadCuotas = cantCuotas;
      CuotasPagas = new();
    }

    public void AñadirPagoCuota(Cuota c)
    {
      CuotasPagas.Add(c);
    }

    public decimal PagoPorCuota => TotalDeuda / CantidadCuotas;

    public int CantidadCuotasPagas => CuotasPagas.Count;
  }
}