using System.Text.RegularExpressions;

namespace Quijote
{
  class Program
  {
    private static void Main(string[] args)
    {

      HashSet<string> palabrasNoRepetidas = new();
      HashSet<string> palabrasDiccionario = new();
      Dictionary<string, int> palabrasNoRepetidasTotales = new();


      // cargar palabras del Libro no repetidas
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
                palabrasNoRepetidasTotales[palabra] = 1;
              }
              else
              {
                palabrasNoRepetidasTotales[palabra]++;
              }
            }
          }
        }
      };

      // palabras del Diccionario 
      using (StreamReader sr = new("./words_alpha.txt"))
      {
        while (!sr.EndOfStream)
        {
          string linea = sr.ReadLine();

          palabrasDiccionario.Add(linea);
        }
      };

      // diccionario con las palabras que no existen en el Diccionario
      Dictionary<string, int> diff = new();

      foreach (var item in palabrasNoRepetidas.Except(palabrasDiccionario))
      {
        diff[item] = palabrasNoRepetidasTotales[item];
      }


      // palabras ordenadas del Libro sin repetir
      SortedSet<string> palabrasOrdenadas = new SortedSet<string>(palabrasNoRepetidas.Except(palabrasDiccionario));


      Console.WriteLine($"Cantidad de palabras no repetidas {palabrasNoRepetidas.Count}");
      Console.WriteLine($"Cantidad de palabras en el diccionario {palabrasDiccionario.Count}");
      Console.WriteLine($"Cantidad de palabras que no existen en el diccionario (SortedSet){palabrasOrdenadas.Count}");
      Console.WriteLine($"Cantidad de palabras que no existen en el diccionario Con numeros (diccionario){diff.Count}");


      // Mostrar palabras en el diccionario de las palabras del Libro que no existen en el Diccionario
      // foreach (var palabra in diff)
      // {
      //   if (palabra.Value > 40)
      //   {
      //     Console.WriteLine($"Palabra: {palabra.Key}, Cantidad de veces: {palabra.Value}");
      //   }
      // }


    }
  }
}

