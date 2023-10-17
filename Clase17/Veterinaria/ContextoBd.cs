using DotNetEnv;
using System.Data;
using System.Data.SqlClient;

namespace Veterinaria
{
  public class ContextoBd
  {

    //private string cadenaConexion = Env.GetString("CONNECTION_STRING");

    // MASCOTAS
    public List<Mascota> ListarMascotas()
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      List<Mascota> mascotas = new List<Mascota>();

      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        string query = "SELECT * FROM mascotas";

        using (SqlCommand comando = new SqlCommand(query, conn))
        {

          conn.Open();
          using (SqlDataReader reader = comando.ExecuteReader())
          {
            while (reader.Read())
            {
              string nombre = (string)reader["nombre"];
              Especie especie = (Especie)reader["codEspecie"];
              bool esHabitual = (bool)reader["esHabitual"];

              mascotas.Add(new Mascota(nombre, especie, esHabitual));
            }
          }
        }
      }
      return mascotas;
    }

    public void AñadirMascota(Mascota masc)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        string query = "INSERT INTO mascotas (nombre, codEspecie, esHabitual) VALUES (@nombre, @codEspecie, @esHabitual)";


        using (SqlCommand comando = new SqlCommand(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar) { Value = masc.Nombre });
          comando.Parameters.Add(new SqlParameter("@codEspecie", SqlDbType.Int) { Value = (int)masc.Especie });
          comando.Parameters.Add(new SqlParameter("@esHabitual", SqlDbType.Bit) { Value = masc.EsHabitual });

          try
          {
            conn.Open();
            comando.ExecuteNonQuery();
            System.Console.WriteLine("Mascota insertada");
          }
          catch (SqlException ex)
          {
            System.Console.WriteLine(ex.Message);
            throw;
          }
        }
      }
    }

    public void ModificarMascota(int codigoMascota, Mascota masc)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        string query = "UPDATE mascotas SET nombre = @nombre, codEspecie = @codEspecie, esHabitual = @esHabitual WHERE codigoMascota = @codigoMascota";

        using (SqlCommand comando = new SqlCommand(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@codigoMascota", SqlDbType.Int) { Value = codigoMascota });
          comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar) { Value = masc.Nombre });
          comando.Parameters.Add(new SqlParameter("@codEspecie", SqlDbType.Int) { Value = (int)masc.Especie });
          comando.Parameters.Add(new SqlParameter("@esHabitual", SqlDbType.Bit) { Value = masc.EsHabitual });

          try
          {
            conn.Open();
            int rowsAffected = comando.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
              System.Console.WriteLine("Mascota actualizada");
            }
            else
            {
              System.Console.WriteLine("Mascota no encontrada");
            }
          }
          catch (SqlException ex)
          {
            System.Console.WriteLine(ex.Message);
            throw;
          }
        }
      }
    }

    public void EliminarMascota(int codigoMascota)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        string query = "DELETE FROM mascotas WHERE codigoMascota = @codigoMascota";

        using (SqlCommand comando = new SqlCommand(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@codigoMascota", SqlDbType.Int) { Value = codigoMascota });

          try
          {
            conn.Open();
            int rowsAffected = comando.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
              System.Console.WriteLine("Mascota eliminada");
            }
            else
            {
              System.Console.WriteLine("Mascota no encontrada");
            }
          }
          catch (SqlException ex)
          {
            System.Console.WriteLine(ex.Message);
            throw;
          }
        }
      }
    }

    // VETERINARIAS

    public List<Veterinaria> ListarVeterinarias()
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      List<Veterinaria> veterinarias = new List<Veterinaria>();

      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        string query = "SELECT * FROM veterinarias";

        using (SqlCommand comando = new SqlCommand(query, conn))
        {
          conn.Open();
          using (SqlDataReader reader = comando.ExecuteReader())
          {
            while (reader.Read())
            {
              veterinarias.Add(new Veterinaria((string)reader["razon"]));
            }
          }
        }
      }

      return veterinarias;
    }

    public void AñadirVeterinari(Veterinaria vet)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "INSERT INTO veterinarias VALUES(@razon)";

        using (SqlCommand command = new(query, conn))
        {
          command.Parameters.Add(new SqlParameter("@razon", SqlDbType.NVarChar) { Value = vet.RazonSocial });

          try
          {
            conn.Open();
            command.ExecuteNonQuery();
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }

    public void ModificarVeterinaria(int codigoVeterinaria, Veterinaria vet)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        string query = "UPDATE veterinarias SET razon = @razon WHERE codigoVeterinaria = @codigoVeterinaria";

        using (SqlCommand comando = new SqlCommand(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@codigoVeterinaria", SqlDbType.Int) { Value = codigoVeterinaria });
          comando.Parameters.Add(new SqlParameter("@razon", SqlDbType.NVarChar) { Value = vet.RazonSocial });

          try
          {
            conn.Open();
            comando.ExecuteNonQuery();
            System.Console.WriteLine("Veterinaria modificada");
          }
          catch (SqlException ex)
          {
            System.Console.WriteLine(ex.Message);
            throw;
          }
        }
      }
    }

    public void EliminarVeterinaria(int codigoVeterinaria)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        string query = "DELETE FROM veterinarias WHERE codigoVeterinaria = @codigoVeterinaria";

        using (SqlCommand comando = new SqlCommand(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@codigoVeterinaria", SqlDbType.Int) { Value = codigoVeterinaria });

          try
          {
            conn.Open();
            int rowsAffected = comando.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
              System.Console.WriteLine("Veterinaria eliminada");
            }
            else
            {
              System.Console.WriteLine("Veterinaria no encontrada");
            }
          }
          catch (SqlException ex)
          {
            System.Console.WriteLine(ex.Message);
            throw;
          }
        }
      }
    }



  }
}