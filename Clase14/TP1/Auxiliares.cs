using Microsoft.VisualBasic;

namespace Municipalidad
{
  public class Auxiliares
  {

    public static string ValidarOpcionTexto(string input)
    {
      Console.Write(input);
      string? op = Console.ReadLine();

      while (op != "n" && op != "s")
      {
        Console.Write($"Error! {input}");
        op = Console.ReadLine();
      }
      return op;
    }

    public static int ValidarOpcionNumero(string input, int limInferior, int limSuperior)
    {

      try
      {
        Console.Write(input);

        int op = Convert.ToInt32(Console.ReadLine());

        while (op < limInferior || op > limSuperior)
        {
          Console.Write("Error! ");
          Console.Write(input);
          op = Convert.ToInt32(Console.ReadLine());
        }

        return op;

      }
      catch (Exception)
      {
        Console.Write("Error! ");
        return ValidarOpcionNumero(input, limInferior, limSuperior);
      }

    }
  }
}