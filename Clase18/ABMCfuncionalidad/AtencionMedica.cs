namespace Veterinaria
{
  public class AtencionMedica
  {
    public int AtencionMedicaId { get; set; }
    public TipoCobro TipoCobro { get; set; }
    public decimal Importe { get; set; }
    public int MascotaId { get; set; }
    public Mascota Mascota { get; set; }

    public decimal ImporteACobrar()
    {
      if (Mascota.EsHabitual)
      {
        Importe *= (decimal)0.75;
      }

      if (TipoCobro == TipoCobro.TarjetaDeCredito)
      {
        Importe *= (decimal)1.20;
      }
      else
      {
        Importe *= (decimal)0.9;
      }

      return Importe;
    }
  }
}