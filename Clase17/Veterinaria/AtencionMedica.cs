namespace Veterinaria
{
  public class AtencionMedica : Atencion
  {
    public Mascota Mascota { get; }

    public AtencionMedica(Mascota mascota, TipoCobro tipo, decimal importe, Veterinaria vet) : base(tipo, importe, vet)
    {
      Mascota = mascota;
    }

    public override decimal ImporteACobrar()
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

    public override string ToString()
    {
      return $"{Mascota} - Codigo Atencion: {base.ToString()}";
    }
  }
}