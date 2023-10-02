using System.Text.RegularExpressions;

namespace Quijote
{
  class Program
  {
    private static void Main(string[] args)
    {

      HashSet<string> palabrasNoRepetidas = new();
      HashSet<string> palabrasDiccionario = new();
      Dictionary<string, int> palabrasNoExistentes = new();



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
              if (palabrasNoRepetidas.Add(palabra))
              {
                palabrasNoExistentes[palabra] = 1;
              }
              else
              {
                palabrasNoExistentes[palabra]++;
              }
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


      foreach (var item in palabrasNoRepetidas)
      {

      }

      SortedSet<string> palabrasOrdenadas = new SortedSet<string>(palabrasNoRepetidas.Except(palabrasDiccionario));

      //Dictionary<string, int> palabrasNoExistentes = ContarPalabrasNoExistentesEnDiccionario(palabrasNoRepetidas, palabrasDiccionario);


      Console.WriteLine($"Cantidad de palabras no repetidas {palabrasNoRepetidas.Count}");
      Console.WriteLine($"Cantidad de palabras en el diccionario {palabrasDiccionario.Count}");
      Console.WriteLine($"Cantidad de palabras que no existen en el diccionario (SortedSet){palabrasOrdenadas.Count}");
      Console.WriteLine($"Cantidad de palabras que no existen en el diccionario (Dictionary){palabrasNoExistentes.Count}");


      foreach (var palabra in palabrasNoExistentes)
      {
        if (palabra.Value > 1)
        {
          Console.WriteLine($"Palabra: {palabra.Key}, Cantidad de veces: {palabra.Value}");
        }
      }
    }

    private static Dictionary<string, int> ContarPalabrasNoExistentesEnDiccionario(HashSet<string> palabrasNoRepetidas, HashSet<string> palabrasDiccionario)
    {
      Dictionary<string, int> palabrasNoExistentes = new Dictionary<string, int>();

      foreach (string palabra in palabrasNoRepetidas)
      {
        if (!palabrasDiccionario.Contains(palabra))
        {
          if (palabrasNoExistentes.ContainsKey(palabra))
          {
            palabrasNoExistentes[palabra]++;
          }
          else
          {
            palabrasNoExistentes[palabra] = 1;
          }
        }
      }

      return palabrasNoExistentes;
    }
  }
}

