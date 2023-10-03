namespace Veterinaria
{
  public class Mascota
  {
    public int Codigo { get; set; }
    public string Nombre { get; set; }
    public Especie Especie { get; }
    public bool EsHabitual { get; set; }

    public Mascota(int codigo, string nombre, Especie especie, bool esHabitual)
    {
      Codigo = codigo;
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