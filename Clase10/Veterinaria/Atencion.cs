namespace Veterinaria
{
  public abstract class Atencion
  {
    public int Codigo { get; init; }
    public TipoCobro TipoCobro { get; set; }
    public decimal Importe { get; set; }

    private static int id = 0;
    public Atencion(TipoCobro tipo, decimal importe)
    {
      Codigo = id++;
      TipoCobro = tipo;
      Importe = importe;
    }
    public abstract decimal ImporteACobrar();

  }
}


