internal class Program
{
  private static void Main(string[] args)
  {
    List<int> numeros = new();
    Random r = new Random();

    for (int i = 0; i < 100; i++)
    {
      numeros.Add(r.Next(-1000, 1000));
    }


    var esPositivo = (int x) => x > 0;
    var esNegativo = (int x) => x < 0;

    int numPositivos = numeros.Count(esPositivo);
    int numNegativos = numeros.Count(x => x > 0);
    //int numPositivos = numeros.Count(x => x > 0);

    // Mostrar numeros positivos 
    foreach (var item in numeros.Where(esPositivo))
    {
      Console.WriteLine(item);
    }

  }
}