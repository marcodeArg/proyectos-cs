namespace Veterinaria
{
  public class Mascota
  {
    public string Nombre { get; set; }
    public Especie Especie { get; }
    public bool EsHabitual { get; set; }

    public Mascota(string nombre, Especie especie, bool esHabitual)
    {
      Nombre = nombre;
      Especie = especie;
      EsHabitual = esHabitual;
    }

    public override string ToString()
    {
      return $"{Especie} {Nombre}";
    }
  }
}