using System.Data.SqlClient;
using System.Data;
using DotNetEnv;

namespace Veterinaria
{
  public class Veterinaria
  {
    public int Codigo { get; set; }
    public string RazonSocial { get; set; }

    private HashSet<Atencion> atenciones;

    public Veterinaria(int codigo, string razonSocial)
    {
      Env.Load();
      Codigo = codigo;
      RazonSocial = razonSocial;
      atenciones = new();
      CargarAtencionesDesdeBD();
    }

    public void AñadirAtencion(Atencion atencion)
    {
      atenciones.Add(atencion);
    }

    private void CargarAtencionesDesdeBD()
    {
      string cadenaConexion = Env.GetString("CONNECTION_STRING");
      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        conn.Open();
        string queryMedicas = "SELECT * FROM atencionesmedicas WHERE codVeterinaria = @codVeterinaria";
        using (SqlCommand cmdMedicas = new SqlCommand(queryMedicas, conn))
        {
          cmdMedicas.Parameters.Add(new SqlParameter("@codVeterinaria", SqlDbType.Int) { Value = Codigo });
          using (SqlDataReader readerMedicas = cmdMedicas.ExecuteReader())
          {
            while (readerMedicas.Read())
            {
              int codMascota = (int)readerMedicas["codMascota"];
              Mascota mascota = ObtenerMascotaDesdeBD(codMascota);
              TipoCobro tipoCobro = (TipoCobro)readerMedicas["codTipoCobro"];
              decimal importe = (decimal)readerMedicas["importe"];
              AtencionMedica atencionMedica = new AtencionMedica(mascota, tipoCobro, importe, this);
              AñadirAtencion(atencionMedica);
            }
          }
        }
      }

      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        conn.Open();
        string queryTienda = "SELECT * FROM atencionestiendas WHERE codVeterinaria = @codVeterinaria";
        using (SqlCommand cmdTienda = new SqlCommand(queryTienda, conn))
        {
          cmdTienda.Parameters.Add(new SqlParameter("@codVeterinaria", SqlDbType.Int) { Value = Codigo });
          using (SqlDataReader readerTienda = cmdTienda.ExecuteReader())
          {
            while (readerTienda.Read())
            {
              TipoCobro tipoCobro = (TipoCobro)readerTienda["codTipoCobro"];
              decimal importe = (decimal)readerTienda["importe"];
              decimal descuento = (decimal)readerTienda["descuento"];
              AtencionTienda atencionTienda = new AtencionTienda(descuento, importe, tipoCobro, this);
              AñadirAtencion(atencionTienda);
            }
          }
        }
      }
    }

    private Mascota ObtenerMascotaDesdeBD(int codigoMascota)
    {
      string cadenaConexion = Env.GetString("CONNECTION_STRING");
      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        conn.Open();
        string query = "SELECT * FROM Mascotas WHERE codigo = @codigoMascota";
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
          cmd.Parameters.Add(new SqlParameter("@codigoMascota", SqlDbType.Int) { Value = codigoMascota });
          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              string nombre = (string)reader["nombre"];
              Especie especie = (Especie)reader["codEspecie"];
              bool esHabitual = (bool)reader["esHabitual"];
              return new Mascota(codigoMascota, nombre, especie, esHabitual);
            }
          }
        }
      }
      return null;
    }

    public decimal ImporteTotalGatos()
    {
      decimal total = 0;

      foreach (Atencion atencion in atenciones)
      {
        if (atencion is AtencionMedica aten)
        {

          if (aten.Mascota.Especie == Especie.Gato)
          {
            total += atencion.ImporteACobrar();
          }

        }
      }

      return total;
    }

    public int CantidadAtencionesHasta(decimal importe)
    {
      string cadenaConexion = Env.GetString("CONNECTION_STRING");
      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        conn.Open();
        string query = "SELECT COUNT(*) FROM AtencionesMedicas WHERE importe >= 1000 AND importe <= @importe";
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
          cmd.Parameters.Add(new SqlParameter("@importe", SqlDbType.Decimal) { Value = importe });

          int cantidadAtenciones = (int)cmd.ExecuteScalar();
          return cantidadAtenciones;
        }
      }
    }

    public AtencionMedica? primerAtencionMedicaGato()
    {
      string cadenaConexion = Env.GetString("CONNECTION_STRING");
      using (SqlConnection conn = new SqlConnection(cadenaConexion))
      {
        conn.Open();
        string query = "SELECT TOP 1 * FROM AtencionesMedicas " +
                       "INNER JOIN Mascotas ON AtencionesMedicas.codMascota = Mascotas.codigo " +
                       "WHERE Mascotas.codEspecie = @especieGato " +
                       "ORDER BY AtencionesMedicas.codigo ASC";

        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
          cmd.Parameters.Add(new SqlParameter("@especieGato", SqlDbType.Int) { Value = (int)Especie.Gato });

          using (SqlDataReader reader = cmd.ExecuteReader())
          {
            if (reader.Read())
            {
              int codigo = (int)reader["codMascota"];
              string nombre = (string)reader["nombre"];
              Especie especie = (Especie)reader["codEspecie"];
              bool esHabitual = (bool)reader["esHabitual"];

              TipoCobro tc = (TipoCobro)reader["codTipoCobro"];
              decimal importe = (decimal)reader["importe"];
              Veterinaria vet = this;

              AtencionMedica atencionMedica = new(new(codigo, nombre, especie, esHabitual), tc, importe, this);

              return atencionMedica;
            }
          }
        }
      }

      return null;
    }




  }

}