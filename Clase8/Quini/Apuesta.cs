namespace Quini6
{
  public class Apuesta
  {
    public List<int> Numeros { get; }
    public Apuesta()
    {
      Numeros = new List<int>();
      var random = new Random();
      while (Numeros.Count < 6)
      {
        int numero = random.Next(1, 47);
        if (!Numeros.Contains(numero))
        {
          Numeros.Add(numero);
        }
      }
    }
    public override string ToString()
    {
      return string.Join(", ", Numeros);
    }
  }
}
