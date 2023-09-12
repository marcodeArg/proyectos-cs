namespace Ascensor
{
  class Program
  {
    private static void Main(string[] args)
    {
      Ascensor ascensor = new Ascensor();

      Console.WriteLine("\nInicial");
      Console.WriteLine(ascensor);

      Console.WriteLine("\nBajo 4");
      ascensor.BajarPersonas(4);
      Console.WriteLine(ascensor);

      Console.WriteLine("\nSubo 8");

      ascensor.SubirPersonas(8);
      Console.WriteLine(ascensor);

      Console.WriteLine("\nCambio de piso");

      ascensor.CambiarPiso(7);
      Console.WriteLine(ascensor);

      Console.WriteLine("\nBajo 2");

      ascensor.BajarPersonas(2);
      Console.WriteLine(ascensor);

      Console.WriteLine("\nCambio de piso");

      ascensor.CambiarPiso(-7);
      Console.WriteLine(ascensor);

      Console.WriteLine("\nBajo 7");

      ascensor.BajarPersonas(7);
      Console.WriteLine(ascensor);

      Console.WriteLine("\nSubo 1");

      ascensor.SubirPersonas(1);
      Console.WriteLine(ascensor);


    }

  }
}

