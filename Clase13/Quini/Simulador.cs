
namespace Quini6
{
  public class Simulador
  {
    public List<Apuesta> Apuestas { get; }
    public Simulador()
    {
      Apuestas = new List<Apuesta>();
    }
    public void GenerarApuesta()
    {
      Apuesta apuesta = new Apuesta();
      Apuestas.Add(apuesta);
    }

    public void MostrarApuesta()
    {
      Console.WriteLine("Listado de apuestas:");
      foreach (Apuesta a in Apuestas)
      {
        Console.WriteLine(a);
      }
    }

    public void MostrarGanador()
    {
      Apuesta apuesta = new Apuesta();

      // Alguien gana si o si
      // Random random = new Random();
      // int indiceAleatorio = random.Next(Apuestas.Count);
      // Apuesta apuesta = Apuestas[indiceAleatorio];


      Apuesta? ganador = (from apu in Apuestas where apu == apuesta select apu).FirstOrDefault();

      if (ganador is not null)
      {
        Console.WriteLine($"Existe un ganador con la apuesta: {apuesta}");
      }
      else
      {
        Console.WriteLine($"No existen ganadores con la apuesta: {apuesta}");
      }
    }
  }
}