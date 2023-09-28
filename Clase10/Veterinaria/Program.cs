namespace Veterinaria
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      HashSet<string> temporales = new();

      Veterinaria vet = new(1);

      using (StreamReader sr = new StreamReader("./Datos/AtencionesMedicas.csv"))
      {
        while (!sr.EndOfStream)
        {
          string? linea = sr.ReadLine();

          if (temporales.Add(linea))
          {
            string[] datos = linea.Split(",");
            string nombreMasc = datos[0];
            Especie tipo = (Especie)Convert.ToInt32(datos[1]);
            bool esHabitual = Convert.ToBoolean(datos[2]);
            int codigoMasc = Convert.ToInt32(datos[3]);
            decimal importe = Convert.ToDecimal(datos[4]);

            Random rnd = new Random();

            vet.AñadirAtencion(new AtencionMedica(new Mascota(codigoMasc, nombreMasc, tipo, esHabitual), (TipoCobro)rnd.Next(1, 2), importe));
          }
        }
      }



      using (StreamReader sr = new StreamReader("./Datos/AtencionesTienda.csv"))
      {
        while (!sr.EndOfStream)
        {
          string? linea = sr.ReadLine();

          if (temporales.Add(linea))
          {
            string[] datos = linea.Split(",");
            decimal importe = Convert.ToDecimal(datos[0].Replace(".", ","));
            decimal descuento = Convert.ToDecimal(datos[1]);

            Random rnd = new Random();

            vet.AñadirAtencion(new AtencionTienda(descuento, importe, (TipoCobro)rnd.Next(1, 2)));
          }
        }
      }

      Console.WriteLine("------------------");
      Console.WriteLine($"{vet.ImporteTotalGatos()}");
      Console.WriteLine("------------------");
      Console.WriteLine($"{vet.CantidadAtencionesHasta(5000)}");
      Console.WriteLine("------------------");

      Atencion primeraGato = vet.primerAtencionMedicaGato();

      if (primeraGato != null)
      {
        Console.WriteLine($"{primeraGato}");
      }





    }
  }
}

