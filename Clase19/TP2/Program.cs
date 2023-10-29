namespace Biblioteca
{
  class Programa
  {
    private static Biblioteca b = new();

    private static void Main(string[] args)
    {
      while (true)
      {
        Console.Clear();
        Console.Write("""
        1. Administración de Libros
        2. Administración de Préstamos
        3. Consultas
        4. Salir
        Seleccione una opción: 
        """);
        int op = Convert.ToInt16(Console.ReadLine());

        switch (op)
        {
          case 1:
            AdministrarLibros();
            break;
          case 2:
            AdministrarPrestamos();
            break;
          case 3:
            break;
          case 4:
            break;
          default:
            Console.WriteLine("Ingrese una opcion correcta");
            break;
        }
      }
    }

    private static void AdministrarLibros()
    {
      Console.Clear();
      while (true)
      {
        Console.Write("""

        1. Agregar Libro
        2. Actualizar Libro
        3. Eliminar Libro
        4. Listar todos los Libros
        5. Regresar al menú principal
        Seleccione una opción: 
        """);
        int opLib = Convert.ToInt16(Console.ReadLine());

        switch (opLib)
        {
          case 1:
            AgregarLibro();
            break;
          case 2:
            ActualizarLibro();
            break;
          case 3:
            EliminarLibro();
            break;
          case 4:
            ListarLibros();
            break;
          case 5:
            return;
          default:
            Console.WriteLine("Ingrese una opcion correcta");
            break;
        }
      }

    }

    private static void AgregarLibro()
    {
      Console.Write("\nIngrese el título del libro: ");
      string titulo = Console.ReadLine();
      Console.Write("Ingrese el precio de reposicion: ");
      decimal autor = Convert.ToDecimal(Console.ReadLine());
      Console.Write("Ingrese el estado del libro (1. Disponible | 2. Prestado | 3. Extraviado): ");
      int estado = Convert.ToInt16(Console.ReadLine());


      if (b.AgregarLibro(new Libro { Titulo = titulo, PrecioReposicion = autor, EstadoId = estado }))
      {
        Console.WriteLine("\nLibro agregado correctamente");
      }
      else
      {
        Console.WriteLine("\nError al agregar el libro");
      }
    }

    private static void ActualizarLibro()
    {
      Console.Write("\nIngrese el ID del libro a actualizar: ");
      int idLibro = Convert.ToInt16(Console.ReadLine());

      Console.Write("Ingrese el título nuevo: ");
      string titulo = Console.ReadLine();
      Console.Write("Ingrese el precio de reposicion nuevo: ");
      decimal precio = Convert.ToDecimal(Console.ReadLine());
      Console.Write("Ingrese el estado del libro (1. Disponible | 2. Prestado | 3. Extraviado): ");
      int estado = Convert.ToInt16(Console.ReadLine());


      if (b.ActualizarLibro(idLibro, new Libro { Titulo = titulo, PrecioReposicion = precio, EstadoId = estado }))
      {
        Console.WriteLine("\nLibro actualizado correctamente");
      }
      else
      {
        Console.WriteLine("\nError al actualizar el libro");
      }
    }

    private static void EliminarLibro()
    {
      Console.Write("\nIngrese el ID del libro a eliminar: ");
      int idLibroEliminar = Convert.ToInt16(Console.ReadLine());
      if (b.EliminarLibro(idLibroEliminar))
      {
        Console.WriteLine("\nLibro eliminado correctamente");
      }
      else
      {
        Console.WriteLine("\nError al eliminar el libro");
      }
    }

    private static void ListarLibros()
    {
      foreach (var l in b.ListarLibros())
      {
        Console.WriteLine($"Id : {l.Id} - Titulo : {l.Titulo}");
      }
    }

    private static void AdministrarPrestamos()
    {
      Console.Clear();

      while (true)
      {
        Console.Write("""

        1. Agregar Prestamo
        2. Actualizar Prestamo
        3. Eliminar Prestamo
        4. Listar todos los prestamos de un libro
        5. Regresar al menú principal
        Seleccione una opción: 
        """);
        int opPrestamo = Convert.ToInt16(Console.ReadLine());

        switch (opPrestamo)
        {
          case 1:
            AgregarPrestamo();
            break;
          case 2:
            ActualizarPrestamo();
            break;
          case 3:
            EliminarPrestamo();
            break;
          case 4:
            ListarPrestamos();
            break;
          case 5:
            break;
          default:
            Console.WriteLine("Ingrese una opcion correcta");
            break;
        }
      }

    }



    private static void AgregarPrestamo()
    {
      Console.Write("\nIngrese el ID del libro a prestar: ");
      int idLibroPrestamo = Convert.ToInt16(Console.ReadLine());
      Console.Write("Ingrese el nombre del solicitante: ");
      string prestatario = Console.ReadLine();
      Console.Write("Ingrese la cantidad de dias del prestamo: ");
      int dias = Convert.ToInt16(Console.ReadLine());
      Console.Write("El libro fue devuelto? (1. Si | 2. No ): ");
      bool devuelto = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

      if (b.AgregarPrestamo(new Prestamo { LibroId = idLibroPrestamo, Nombre = prestatario, DiasPrestamo = dias, FueDevuelto = devuelto }))
      {
        Console.WriteLine("\nPrestamo agregado correctamente");
      }
      else
      {
        Console.WriteLine("\nError al agregar el Prestamo");
      }
    }

    private static void ActualizarPrestamo()
    {
      Console.Write("\nIngrese el ID del préstamo a actualizar: ");
      int idPrestamo = Convert.ToInt16(Console.ReadLine());

      Console.Write("Ingrese el nuevo ID del libro a prestar ");
      int idLibroPrestamo = Convert.ToInt16(Console.ReadLine());
      Console.Write("Ingrese el nuevo nombre del solicitante: ");
      string prestatario = Console.ReadLine();
      Console.Write("Ingrese la cantidad de dias del prestamo: ");
      int dias = Convert.ToInt16(Console.ReadLine());
      Console.Write("El libro fue devuelto? (1. Si | 2. No ): ");
      bool devuelto = Convert.ToInt32(Console.ReadLine()) == 1 ? true : false;

      if (b.ActualizarPrestamo(idPrestamo, new Prestamo { LibroId = idLibroPrestamo, Nombre = prestatario, DiasPrestamo = dias, FueDevuelto = devuelto }))
      {
        Console.WriteLine("\nPrestamo actualizado correctamente");
      }
      else
      {
        Console.WriteLine("\nError al actualizado el Prestamo");
      }
    }

    private static void EliminarPrestamo()
    {
      Console.Write("\nIngrese el ID del prestamo a eliminar: ");
      int idPrestamoEliminar = Convert.ToInt16(Console.ReadLine());
      if (b.EliminarLibro(idPrestamoEliminar))
      {
        Console.WriteLine("\nPrestamo eliminado correctamente");
      }
      else
      {
        Console.WriteLine("\nError al eliminar el Prestamo");
      }
    }

    private static void ListarPrestamos()
    {
      Console.Write("\nIngrese el ID del libro: ");
      int idLibroPrestamo = Convert.ToInt16(Console.ReadLine());

      foreach (var p in b.ListarPrestamos(idLibroPrestamo))
      {
        Console.WriteLine($"Nombre solicitante : {p.Nombre} - Prestamo de {p.DiasPrestamo} dias - {(p.FueDevuelto ? "Si" : "No")} fue devuelto");
      }
    }
  }
}