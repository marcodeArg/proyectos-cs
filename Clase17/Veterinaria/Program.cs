using DotNetEnv;

namespace Veterinaria
{
  internal class Program
  {
    private static ContextoBd contexto = new ContextoBd();
    private static Veterinaria vet = new Veterinaria(1, "Veterinaria 1");

    static void Main(string[] args)
    {


      //using (StreamReader reader = new StreamReader("./Datos/AtencionesMedica.csv"))
      //{
      //  string line;
      //  while ((line = reader.ReadLine()) != null)
      //  {
      //    string[] data = line.Split(',');

      //    int codTipoCobro = int.Parse(data[0]);
      //    decimal importe = decimal.Parse(data[1]);
      //    int codMascota = int.Parse(data[2]);
      //    string nombreMasc = data[3];
      //    int codEspecie = int.Parse(data[4]);
      //    bool esHabitual = Convert.ToBoolean(Convert.ToInt32(data[5]));
      //    int codVeterinaria = int.Parse(data[6]);

      //    Mascota masc = new(codMascota, nombreMasc, (Especie)codEspecie, esHabitual);
      //    Veterinaria vet = new(codVeterinaria, "Veterinaria 4");

      //    AtencionMedica am = new(masc, (TipoCobro)codTipoCobro, importe, vet);

      //    contexto.AñadirMascota(masc);
      //    contexto.AñadirVeterinari(vet);
      //    contexto.AñadirAtencionMedica(am);

      //    Console.WriteLine("Datos cargados correctamente");

      //  }
      //}

      //using (StreamReader reader = new StreamReader("./Datos/AtencionesTienda.csv"))
      //{
      //  string line;
      //  while ((line = reader.ReadLine()) != null)
      //  {
      //    string[] data = line.Split(',');

      //    int codTipoCobro = int.Parse(data[0]);
      //    decimal importe = decimal.Parse(data[1]);
      //    decimal descuento = decimal.Parse(data[2]);
      //    int codVeterinaria = int.Parse(data[3]);

      //    Veterinaria vet = new(codVeterinaria, "Veterinaria 4");

      //    AtencionTienda at = new(descuento, importe, (TipoCobro)codTipoCobro, vet);

      //    contexto.AñadirAtencionTienda(at);

      //    Console.WriteLine("Datos cargados correctamente");

      //  }
      //}


      foreach (var item in contexto.ListarMascotas())
      {
        System.Console.WriteLine($"{item.Nombre} - {item.Especie}");
      }


      int opcion;

      do
      {
        Console.WriteLine("******** Menú de Opciones ********");
        Console.WriteLine("1. Cargar Mascota");
        Console.WriteLine("2. Cargar Veterinaria");
        Console.WriteLine("3. Cargar Atención Médica");
        Console.WriteLine("4. Cargar Atención en Tienda");
        Console.WriteLine("5. Listar Importe total de gatos");
        Console.WriteLine("6. Listar Cantidad de atenciones hasta");
        Console.WriteLine("7. Listar Primera atencion gato");
        Console.WriteLine("8. Salir");
        Console.Write("Seleccione una opción: ");

        opcion = Convert.ToInt32(Console.ReadLine());

        switch (opcion)
        {
          case 1:
            CargarMascota();
            break;
          case 2:
            CargarVeterinaria();
            break;
          case 3:
            CargarAtencionMedica();
            break;
          case 4:
            CargarAtencionTienda();
            break;
          case 5:
            Console.WriteLine($"{vet.ImporteTotalGatos()}");
            break;
          case 6:
            CantidadAtencionesHasta();
            break;
          case 7:
            PrimeraAtencionGato();
            break;
          case 8:
            Console.WriteLine("Saliendo del programa.");
            break;
          default:
            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
            break;
        }
      } while (opcion != 8);
    }

    private static void CantidadAtencionesHasta()
    {
      Console.Clear();
      Console.Write("Ingrese el valor hasta el que desee comparar: ");
      int hasta = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine($"{vet.CantidadAtencionesHasta(hasta)}");
    }

    private static void PrimeraAtencionGato()
    {
      Console.Clear();
      Console.WriteLine($"{vet.primerAtencionMedicaGato()}");
    }

    static void CargarMascota()
    {
      Console.Clear();
      Console.Write("Nombre de la mascota: ");
      string nombre = Console.ReadLine();

      Console.Write("Especie (1: Perro, 2: Gato, 3: Otras): ");
      int especie = int.Parse(Console.ReadLine());

      Console.Write("¿Es habitual? (true/false): ");
      bool esHabitual = bool.Parse(Console.ReadLine());

      Mascota mascota = new Mascota(0, nombre, (Especie)especie, esHabitual);
      contexto.AñadirMascota(mascota);
    }

    static void CargarVeterinaria()
    {
      Console.Clear();
      Console.Write("Razón social de la veterinaria: ");
      string razonSocial = Console.ReadLine();

      Veterinaria veterinaria = new Veterinaria(0, razonSocial);
      contexto.AñadirVeterinari(veterinaria);
    }

    static void CargarAtencionMedica()
    {
      Console.Clear();
      // Completa este método para cargar una atención médica
    }

    static void CargarAtencionTienda()
    {
      Console.Clear();
      // Completa este método para cargar una atención en tienda
    }

  }
}

