namespace Veterinaria
{
  public abstract class Atencion
  {
    public int Codigo { get; }
    public TipoCobro TipoCobro { get; set; }
    public decimal Importe { get; set; }

    public Veterinaria Veterinaria { get; }

    public Atencion(TipoCobro tipo, decimal importe, Veterinaria vet)
    {
      TipoCobro = tipo;
      Importe = importe;
      Veterinaria = vet;
    }
    public abstract decimal ImporteACobrar();

    public override string ToString()
    {
      return $"{Codigo}";
    }

  }
}


