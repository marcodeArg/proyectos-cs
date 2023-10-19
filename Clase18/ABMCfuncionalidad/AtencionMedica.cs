namespace Veterinaria
{
  public class AtencionMedica
  {
    public int AtencionMedicaId { get; set; }
    public TipoCobro TipoCobro { get; set; }
    public decimal Importe { get; set; }
    public int IdMascota { get; set; }
    public Mascota Mascota { get; set; }
  }
}