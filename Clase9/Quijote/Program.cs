using System.Text.RegularExpressions;

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
          string linea = sr.ReadLine().ToLower();

          string[] palabras = Regex.Split(linea, @"[^a-zA-Z]");

          foreach (string palabra in palabras)
          {
            if (!string.IsNullOrEmpty(palabra))
            {
              palabrasNoRepetidas.Add(palabra);
            }
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
      Console.WriteLine($"Cantidad de palabras en el diccionario {palabrasDiccionario.Count}");
      Console.WriteLine($"Cantidad de palabras que no existen en el diccionario (SortedSet){palabrasOrdenadas.Count}");
    }
  }
}

