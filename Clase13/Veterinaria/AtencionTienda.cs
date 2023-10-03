namespace Veterinaria
{
  public class AtencionTienda : Atencion
  {
    public decimal Descuento { get; set; }

    public AtencionTienda(decimal desc, decimal importe, TipoCobro tipoCobro) : base(tipoCobro, importe)
    {
      Descuento = desc;
    }

    public override decimal ImporteACobrar()
    {
      Importe -= Descuento;

      if (TipoCobro == TipoCobro.TarjetaDeCredito)
      {
        Importe *= (decimal)1.30;
      }
      else
      {
        Importe *= (decimal)0.95;
      }

      return Importe;
    }
  }
}