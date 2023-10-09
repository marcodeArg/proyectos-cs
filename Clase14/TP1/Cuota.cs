namespace Municipalidad
{
  public record Cuota(int diaPago, decimal ImporteCuota)
  {
    // Dia de vencimiento de todas las cuotas
    private int diaVencimientoCuota = 5;

    private int Demora => diaPago <= diaVencimientoCuota ? 0 : diaPago - diaVencimientoCuota;

    public decimal ImporteDeIntereses => ImporteCuota * 0.005m * Demora;


    public override string ToString()
    {
      return $"Demora de la cuota: {Demora} dias - Intereses en pesos: {ImporteDeIntereses:C} - Importe de cuota: {ImporteCuota:C}";
    }
  }

}