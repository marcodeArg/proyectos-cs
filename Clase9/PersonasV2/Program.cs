namespace Personas
{
  class Program
  {
    private static void Main(string[] args)
    {
      HashSet<string> nombres = new();
      HashSet<string> apellidos = new();


      using (StreamReader sr = new("./personas.csv"))
      {
        while (!sr.EndOfStream)
        {
          string[] linea = sr.ReadLine().Split(",");

          nombres.Add(linea[1]);
          apellidos.Add(linea[2]);

        }
      };

      Console.WriteLine($"Lista de nombres ({nombres.Count} nombres)");
      foreach (string nombre in nombres) Console.Write($" {nombre}");

      Console.WriteLine($"\nLista de apellidos ({apellidos.Count} apellidos)");
      foreach (string apellido in apellidos) Console.Write($" {apellido}");
    }
  }
}

