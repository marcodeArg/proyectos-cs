using DotNetEnv;
using System.Data;
using System.Data.SqlClient;

namespace Personas
{
  class Personas
  {
    public static void Main()
    {
      Env.Load();
      // SqlConnection conexion = new(Environment.GetEnvironmentVariable("CONNECTION_STRING"));

      // SqlCommand comando = conexion.CreateCommand();
      // PoblarBD();
      string msg = """
      
      1. Insertar una persona a la base de datos
      2. Consultar por documento
      3. Consultar por apellido
      4. Modificar datos de una persona
      5. Cantidad de personas por apellido
      6. Borrar persona de la base de datos
      7. Salir
      Seleccione una opcion >> 
      """;


      while (true)
      {
        Console.Write(msg);
        int op = Convert.ToInt32(Console.ReadLine());

        switch (op)
        {
          case 1:
            InsertarPersona();
            break;
          case 2:
            ConsultarDNI();
            break;
          case 3:
            ConsultarApellido();
            break;
          case 4:
            ModificarDatos();
            break;
          case 5:
            CantidadPersonasApellido();
            break;
          case 6:
            EliminarPersona();
            break;
          default:
            Console.WriteLine("Opción no válida.");
            break;
        }
      }
    }


    private static void PoblarBD()
    {
      using (StreamReader sr = new("./personas.csv"))
      {
        while (!sr.EndOfStream)
        {
          string[] linea = sr.ReadLine().Split(",");
          int dni = Convert.ToInt32(linea[0]);
          string nombre = linea[1];
          string apellido = linea[2];
          int edad = Convert.ToInt32(linea[3]);

          InsertarPersona(dni, nombre, apellido, edad);

        }
      };

    }

    // 1.
    private static void InsertarPersona(int dni, string nombre, string apellido, int edad)
    {
      using (SqlConnection conexion = new(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
      {
        SqlCommand comando = conexion.CreateCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText = $"INSERT INTO personas VALUES ({dni}, '{nombre}', '{apellido}', {edad})";

        try
        {
          conexion.Open();
          comando.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    private static void InsertarPersona()
    {
      Console.Write("\nIngrese el documento: ");
      int dni = Convert.ToInt32(Console.ReadLine());
      Console.Write("Ingrese el nombre: ");
      string nombre = Console.ReadLine();
      Console.Write("Ingrese el apellido: ");
      string apellido = Console.ReadLine();
      Console.Write("Ingrese la edad: ");
      int edad = Convert.ToInt32(Console.ReadLine());

      using (SqlConnection conexion = new(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
      {
        SqlCommand comando = conexion.CreateCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText = $"INSERT INTO personas VALUES ({dni}, '{nombre}', '{apellido}', {edad})";

        try
        {
          conexion.Open();
          comando.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    // 2.
    private static void ConsultarDNI()
    {
      Console.Write("\nIngrese el documento: ");
      int dni = Convert.ToInt32(Console.ReadLine());

      using (SqlConnection conexion = new(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
      {
        SqlCommand comando = conexion.CreateCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText = $"SELECT * FROM personas WHERE documento = {dni}";

        try
        {
          conexion.Open();
          SqlDataReader dr = comando.ExecuteReader();

          if (dr.Read())
          {
            int doc = dr.GetInt32(0);
            string nom = dr.GetString(1);
            string ape = dr.GetString(2);
            int edad = dr.GetInt32(3);
            Console.WriteLine($"Nombre {nom} {ape}, Edad {edad}, Documento {doc}");
          }
          else
          {
            Console.WriteLine($"No se encontro persona alguna con el documento ingresado");
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    // 3.
    private static void ConsultarApellido()
    {
      Console.Write("\nIngrese el Apellido: ");
      string apellido = Console.ReadLine();

      using (SqlConnection conexion = new(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
      {
        SqlCommand comando = conexion.CreateCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText = $"SELECT * FROM personas WHERE apellido = '{apellido}' ORDER BY nombre";

        try
        {
          conexion.Open();
          SqlDataReader dr = comando.ExecuteReader();

          if (dr.Read())
          {
            do
            {
              int doc = dr.GetInt32(0);
              string nom = dr.GetString(1);
              string ape = dr.GetString(2);
              int edad = dr.GetInt32(3);
              Console.WriteLine($"Nombre {nom} {ape}, Edad {edad}, Documento {doc}");

            } while (dr.Read());
          }
          else
          {
            Console.WriteLine($"No se encontro persona alguna con el apellido ingresado");
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    // 4.
    private static void ModificarDatos()
    {
      Console.Write("\nIngrese el documento de la persona: ");
      int dni = Convert.ToInt32(Console.ReadLine());

      using (SqlConnection conexion = new(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
      {
        SqlCommand comando = conexion.CreateCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText = $"SELECT * FROM personas WHERE documento = {dni}";

        try
        {
          conexion.Open();
          SqlDataReader dr = comando.ExecuteReader();

          if (dr.Read())
          {
            string nom = dr.GetString(1);
            string ape = dr.GetString(2);
            int eda = dr.GetInt32(3);
            Console.WriteLine("Persona encontrada!");
            Console.WriteLine($"Nombre = {nom}\nApellido = {ape}\nEdad = {eda}");

          }
          else
          {
            Console.WriteLine($"No se encontro persona alguna con el documento ingresado");
            return;
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }

      Console.WriteLine("\nIngrese los datos nuevos");
      Console.Write("Ingrese el nombre: ");
      string nombre = Console.ReadLine();
      Console.Write("Ingrese el apellido: ");
      string apellido = Console.ReadLine();
      Console.Write("Ingrese la edad: ");
      int edad = Convert.ToInt32(Console.ReadLine());

      using (SqlConnection conexion = new(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
      {
        SqlCommand comando = conexion.CreateCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText = $"UPDATE Personas SET nombre = '{nombre}', apellido = '{apellido}', edad = {edad} WHERE documento = {dni}";

        Console.WriteLine("\nDatos actualizados!");
        // ESTO CAPAZ QUE SE PUEDE HACER CON ALGUN OTRO METODO DEL COMMANDO

        try
        {
          conexion.Open();
          comando.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    // 5.
    private static void CantidadPersonasApellido()
    {
      Console.Write("\nIngrese el apellido: ");
      string apellido = Console.ReadLine();

      using (SqlConnection conexion = new(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
      {
        SqlCommand comando = conexion.CreateCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText = $"SELECT COUNT(*) FROM personas WHERE apellido = '{apellido}'";

        try
        {
          conexion.Open();
          int cant = Convert.ToInt32(comando.ExecuteScalar());

          Console.WriteLine($"Cantidad de personas con el mismo apellido: {cant}");
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    // 6.
    private static void EliminarPersona()
    {
      Console.Write("\nIngrese el documento: ");
      int dni = Convert.ToInt32(Console.ReadLine());

      using (SqlConnection conexion = new(Environment.GetEnvironmentVariable("CONNECTION_STRING")))
      {
        SqlCommand comando = conexion.CreateCommand();
        comando.CommandType = CommandType.Text;
        comando.CommandText = $"DELETE FROM personas WHERE documento = {dni}";

        try
        {
          conexion.Open();
          comando.ExecuteNonQuery();
          Console.WriteLine("\nPersona eliminada!");
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }
  }
}