namespace Quini6
{
  public class Apuesta
  {
    public HashSet<int> Numeros { get; }
    public Apuesta()
    {
      Numeros = new HashSet<int>();
      var random = new Random();
      while (Numeros.Count < 6)
      {
        int numero = random.Next(1, 47);
        Numeros.Add(numero);
      }
    }
    public override string ToString()
    {
      return string.Join(", ", Numeros);
    }
  }
}
