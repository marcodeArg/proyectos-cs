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

      List<Mascota> mascotas = new();

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "SELECT * FROM mascotas";

        using (SqlCommand comando = new(query, conn))
        {

          conn.Open();
          using (SqlDataReader reader = comando.ExecuteReader())
          {
            while (reader.Read())
            {
              string nombre = (string)reader["nombre"];
              Especie especie = (Especie)reader["codEspecie"];
              bool esHabitual = (bool)reader["esHabitual"];

              mascotas.Add(new Mascota(0, nombre, especie, esHabitual));
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

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "INSERT INTO mascotas VALUES (@codigo, @nombre, @codEspecie, @esHabitual)";


        using (SqlCommand comando = new(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@codigo", SqlDbType.Int) { Value = masc.Codigo });
          comando.Parameters.Add(new SqlParameter("@nombre", SqlDbType.NVarChar) { Value = masc.Nombre });
          comando.Parameters.Add(new SqlParameter("@codEspecie", SqlDbType.Int) { Value = (int)masc.Especie });
          comando.Parameters.Add(new SqlParameter("@esHabitual", SqlDbType.Bit) { Value = masc.EsHabitual });

          try
          {
            conn.Open();
            comando.ExecuteNonQuery();
            Console.WriteLine("Mascota añadida");


          }
          catch (SqlException ex)
          {
            Console.WriteLine("No se puede añadir una mascota duplicada");
          }
        }
      }
    }

    public void ModificarMascota(int codigoMascota, Mascota masc)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "UPDATE mascotas SET nombre = @nombre, codEspecie = @codEspecie, esHabitual = @esHabitual WHERE codigoMascota = @codigoMascota";

        using (SqlCommand comando = new(query, conn))
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
          }
        }
      }
    }

    public void EliminarMascota(int codigoMascota)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "DELETE FROM mascotas WHERE codigoMascota = @codigoMascota";

        using (SqlCommand comando = new(query, conn))
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
          }
        }
      }
    }

    // VETERINARIAS

    public List<Veterinaria> ListarVeterinarias()
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      List<Veterinaria> veterinarias = new();

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "SELECT * FROM veterinarias";

        using (SqlCommand comando = new(query, conn))
        {
          conn.Open();
          using (SqlDataReader reader = comando.ExecuteReader())
          {
            while (reader.Read())
            {
              veterinarias.Add(new Veterinaria((int)reader["codigo"], (string)reader["razon"]));
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

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "UPDATE veterinarias SET razon = @razon WHERE codigoVeterinaria = @codigoVeterinaria";

        using (SqlCommand comando = new(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@codigoVeterinaria", SqlDbType.Int) { Value = codigoVeterinaria });
          comando.Parameters.Add(new SqlParameter("@razon", SqlDbType.NVarChar) { Value = vet.RazonSocial });

          try
          {
            conn.Open();
            comando.ExecuteNonQuery();
            Console.WriteLine("Veterinaria modificada");
          }
          catch (SqlException ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }

    public void EliminarVeterinaria(int codigoVeterinaria)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "DELETE FROM veterinarias WHERE codigoVeterinaria = @codigoVeterinaria";

        using (SqlCommand comando = new(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@codigoVeterinaria", SqlDbType.Int) { Value = codigoVeterinaria });

          try
          {
            conn.Open();
            int rowsAffected = comando.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
              Console.WriteLine("Veterinaria eliminada");
            }
            else
            {
              Console.WriteLine("Veterinaria no encontrada");
            }
          }
          catch (SqlException ex)
          {
            Console.WriteLine(ex.Message);
            throw;
          }
        }
      }
    }


    // ATENCIONES MEDICAS
    public List<AtencionMedica> ListarAtencionesMedicas()
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      List<AtencionMedica> listaAtenciones = new();

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "SELECT am.*, m.nombre, m.codEspecie, m.esHabitual, v.razon FROM atencionesmedicas AS am INNER JOIN mascotas AS m ON am.codMascota = m.codigo INNER JOIN veterinarias AS v ON am.codigoVeterinaria = v.codigo";

        using (SqlCommand comando = new(query, conn))
        {
          conn.Open();
          using (SqlDataReader reader = comando.ExecuteReader())
          {
            while (reader.Read())
            {
              TipoCobro tc = (TipoCobro)Convert.ToInt32(reader["codTipoCobro"]);
              decimal importe = (decimal)reader["importe"];

              int codMascota = (int)reader["codMascota"];
              string nombre = (string)reader["nombre"];
              Especie especie = (Especie)reader["codEspecie"];
              bool esHabitual = (bool)reader["esHabitual"];

              Mascota msc = new(codMascota, nombre, especie, esHabitual);

              int codVet = (int)reader["codVet"];
              string razonVet = (string)reader["razon"];

              Veterinaria vet = new(codVet, razonVet);

              listaAtenciones.Add(new(msc, tc, importe, vet));
            }
          }
        }
      }

      return listaAtenciones;
    }

    public void AñadirAtencionMedica(AtencionMedica aten)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "INSERT INTO atencionesmedicas VALUES(@codTipoCobro, @importe, @codMascota, @codVeterinaria)";

        using (SqlCommand comando = new(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@codTipoCobro", SqlDbType.Int) { Value = aten.TipoCobro });
          comando.Parameters.Add(new SqlParameter("@importe", SqlDbType.Decimal) { Value = aten.Importe });
          comando.Parameters.Add(new SqlParameter("@codMascota", SqlDbType.Int) { Value = aten.Mascota.Codigo });
          comando.Parameters.Add(new SqlParameter("@codVeterinaria", SqlDbType.Int) { Value = aten.Veterinaria.Codigo });

          try
          {
            conn.Open();
            comando.ExecuteNonQuery();
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }

    public void ActualizarAtencionMedica(int codigoAtencion, AtencionMedica aten)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "UPDATE atencionesmedicas SET codTipoCobro = @codTipoCobro, importe = @importe, codMascota = @codMascota, codVeterinaria = @codVeterinaria WHERE id = @id";

        using (SqlCommand comando = new(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = codigoAtencion });
          comando.Parameters.Add(new SqlParameter("@codTipoCobro", SqlDbType.Int) { Value = aten.TipoCobro });
          comando.Parameters.Add(new SqlParameter("@importe", SqlDbType.Decimal) { Value = aten.Importe });
          comando.Parameters.Add(new SqlParameter("@codMascota", SqlDbType.Int) { Value = aten.Mascota.Codigo });
          comando.Parameters.Add(new SqlParameter("@codVeterinaria", SqlDbType.Int) { Value = aten.Veterinaria.Codigo });

          try
          {
            conn.Open();
            int rowsAffected = comando.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
              Console.WriteLine("El ID especificado no se encontró. No se realizó ninguna actualización.");
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }

    public void EliminarAtencionMedica(int codigoAtencion)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "DELETE FROM atencionesmedicas WHERE id = @id";

        using (SqlCommand comando = new(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = codigoAtencion });

          try
          {
            conn.Open();
            int rowsAffected = comando.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
              Console.WriteLine("El ID especificado no se encontró. No se realizó ninguna eliminación.");
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }


    // ATENCIONES TIENDA

    public List<AtencionTienda> ListarAtencionesTienda()
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      List<AtencionTienda> listaAtenciones = new();

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "SELECT at.*, v.razon FROM atencionestienda AS at INNER JOIN veterinarias AS v ON at.codVeterinaria = v.codigo ";

        using (SqlCommand comando = new(query, conn))
        {
          conn.Open();
          using (SqlDataReader reader = comando.ExecuteReader())
          {
            while (reader.Read())
            {
              TipoCobro tc = (TipoCobro)Convert.ToInt32(reader["codTipoCobro"]);
              decimal importe = (decimal)reader["importe"];
              decimal descuento = (decimal)reader["descuento"];

              int codVet = (int)reader["codVeterinaria"];
              string razon = (string)reader["razon"];

              Veterinaria vet = new(codVet, razon);

              listaAtenciones.Add(new(descuento, importe, tc, vet));
            }
          }
        }
      }

      return listaAtenciones;
    }

    public void AñadirAtencionTienda(AtencionTienda aten)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "INSERT INTO atencionesmedicas VALUES(@codTipoCobro, @importe, @descuento, @codVeterinaria)";

        using (SqlCommand comando = new(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@codTipoCobro", SqlDbType.Int) { Value = aten.TipoCobro });
          comando.Parameters.Add(new SqlParameter("@importe", SqlDbType.Decimal) { Value = aten.Importe });
          comando.Parameters.Add(new SqlParameter("@descuento", SqlDbType.Int) { Value = aten.Descuento });
          comando.Parameters.Add(new SqlParameter("@codVeterinaria", SqlDbType.Int) { Value = aten.Veterinaria.Codigo });

          try
          {
            conn.Open();
            comando.ExecuteNonQuery();
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }


    public void ActualizarAtencionTienda(int codigoAtencion, AtencionTienda aten)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "UPDATE atencionestienda SET codTipoCobro = @codTipoCobro, importe = @importe, descuento = @descuento, codVeterinaria = @codVeterinaria WHERE id = @id";

        using (SqlCommand comando = new(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = codigoAtencion });
          comando.Parameters.Add(new SqlParameter("@codTipoCobro", SqlDbType.Int) { Value = aten.TipoCobro });
          comando.Parameters.Add(new SqlParameter("@importe", SqlDbType.Decimal) { Value = aten.Importe });
          comando.Parameters.Add(new SqlParameter("@descuento", SqlDbType.Decimal) { Value = aten.Descuento });
          comando.Parameters.Add(new SqlParameter("@codVeterinaria", SqlDbType.Int) { Value = aten.Veterinaria.Codigo });

          try
          {
            conn.Open();
            int rowsAffected = comando.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
              Console.WriteLine("El ID especificado no se encontró. No se realizó ninguna actualización.");
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }

    public void EliminarAtencionTienda(int codigoAtencion)
    {
      Env.Load();
      string cadenaConexion = Env.GetString("CONNECTION_STRING");

      using (SqlConnection conn = new(cadenaConexion))
      {
        string query = "DELETE FROM atencionestienda WHERE id = @id";

        using (SqlCommand comando = new(query, conn))
        {
          comando.Parameters.Add(new SqlParameter("@id", SqlDbType.Int) { Value = codigoAtencion });

          try
          {
            conn.Open();
            int rowsAffected = comando.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
              Console.WriteLine("El ID especificado no se encontró. No se realizó ninguna eliminación.");
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex.Message);
          }
        }
      }
    }

  }
}