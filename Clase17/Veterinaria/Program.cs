using DotNetEnv;

namespace Veterinaria
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      HashSet<string> temporales = new();

      ContextoBd contexto = new();

      using (StreamReader sr = new StreamReader("./Datos/AtencionesMedica.csv"))
      {
        while (!sr.EndOfStream)
        {
          string? linea = sr.ReadLine();

          if (temporales.Add(linea))
          {
            Random rnd = new Random();

            string[] datos = linea.Split(",");
            string nombreMasc = datos[0];
            Especie tipo = (Especie)Convert.ToInt32(datos[1]);
            bool esHabitual = Convert.ToBoolean(Convert.ToInt32(datos[2]));
            int codigoMasc = Convert.ToInt32(datos[3]);
            decimal importe = Convert.ToDecimal(datos[4]);

            Mascota masc = new(codigoMasc, nombreMasc, tipo, esHabitual);
            AtencionMedica am = new(masc, (TipoCobro)rnd.Next(1, 2), importe, new Veterinaria(1, "Veterinaria 1"));

            contexto.AñadirMascota(masc);
            contexto.AñadirAtencionMedica(am);

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
            decimal importe = decimal.Parse(datos[0].Replace(".", ","));
            decimal descuento = Convert.ToDecimal(datos[1]);

            Random rnd = new Random();

            contexto.AñadirAtencionTienda(new AtencionTienda(descuento, importe, (TipoCobro)rnd.Next(1, 2), new Veterinaria(1, "Veterinaria 1")));
          }
        }
      }

      Console.WriteLine("Datos cargados correctamente");

      //Console.Clear();
      //Console.WriteLine("------------------");
      //Console.WriteLine($"Importe de todos los gatos: {vet.ImporteTotalGatos():C2}");
      //Console.WriteLine("------------------");
      //Console.WriteLine($"Cantidad de atenciones dentro de rango: {vet.CantidadAtencionesHasta(5000)}");
      //Console.WriteLine("------------------");

      //Atencion? primeraGato = vet.primerAtencionMedicaGato();

      //if (primeraGato != null)
      //{
      //  Console.WriteLine($"Primer gato atendido: {primeraGato}");
      //}

      //contexto.AñadirMascota(new Mascota("Sofia", Especie.Perro, false));




    }
  }
}

