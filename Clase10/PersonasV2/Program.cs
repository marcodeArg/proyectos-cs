namespace Personas
{
  class Program
  {
    private static void Main(string[] args)
    {
      HashSet<string> nombres = new();
      HashSet<string> apellidos = new();
      HashSet<string> nombresCompletos = new();
      HashSet<string> personasConMismoNombre = new();


      using (StreamReader sr = new("./personas.csv"))
      {
        while (!sr.EndOfStream)
        {
          string[] linea = sr.ReadLine().Split(",");
          string nombreCompleto = $"{linea[1]} {linea[2]}";

          nombres.Add(linea[1]);
          apellidos.Add(linea[2]);

          if (!nombresCompletos.Add(nombreCompleto))
          {
            personasConMismoNombre.Add(nombreCompleto);
          }
        }
      };

      Console.WriteLine($"Lista de nombres que no se repiten ({nombres.Count} nombres)");
      //foreach (string nombre in nombres) Console.WriteLine($"-{nombre}");

      Console.WriteLine($"Lista de apellidos que no se repiten ({apellidos.Count} apellidos)");
      //foreach (string apellido in apellidos) Console.WriteLine($"-{apellido}");

      Console.WriteLine($"Lista de personas con mismo nombre y apellido ({personasConMismoNombre.Count})");
      //foreach (string nombresComp in personasConMismoNombre) Console.WriteLine($"-{nombresComp}");
    }
  }
}

