namespace Quijote
{
  class Program
  {
    private static void Main(string[] args)
    {

      HashSet<string> palabrasNoRepetidas = new();
      HashSet<string> palabrasDiccionario = new();


      using (StreamReader sr = new("./Quijote.txt"))
      {
        while (!sr.EndOfStream)
        {
          string[] linea = sr.ReadLine().Split(" ");

          foreach (var palabra in linea)
          {
            palabrasNoRepetidas.Add(palabra);
          }
        }
      };

      using (StreamReader sr = new("./words_alpha.txt"))
      {
        while (!sr.EndOfStream)
        {
          string linea = sr.ReadLine();

          palabrasDiccionario.Add(linea);
        }
      };

      SortedSet<string> palabrasOrdenadas = new SortedSet<string>(palabrasNoRepetidas.Except(palabrasDiccionario));


      Console.WriteLine($"Cantidad de palabras no repetidas {palabrasNoRepetidas.Count}");
      Console.WriteLine($"Cantidad de palabras no repetidas {palabrasDiccionario.Count}");
      Console.WriteLine($" ");
      Console.WriteLine($" ");
      Console.WriteLine($"Cantidad de palabras que no existen en el diccionario {palabrasNoRepetidas.Except(palabrasDiccionario).Count()}");

      Console.WriteLine($"Cantidad de palabras que no existen en el diccionario (SortedSet){palabrasOrdenadas.Count}");
    }
  }
}

