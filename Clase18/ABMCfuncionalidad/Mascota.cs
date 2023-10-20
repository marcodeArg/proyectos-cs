namespace Veterinaria
{
  public class Mascota
  {
    public int MascotaId { get; set; }
    public string Nombre { get; set; }
    public Especie Especie { get; set; }
    public bool EsHabitual { get; set; }
    public List<AtencionMedica> Atenciones { get; set; }




  }
}