using DotNetEnv;
using System.Data.SqlClient;

Env.Load();

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

SqlConnection c = new SqlConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING"));
System.Console.WriteLine(c.State);

c.Open();

SqlCommand comm = c.CreateCommand();
comm.CommandText = "SELECT * FROM personas";
SqlDataReader dr = comm.ExecuteReader();

System.Console.WriteLine(c.State);

int cant = 0;

while (dr.Read())
{
  int doc = dr.GetInt32(0);
  string nom = dr.GetString(1);
  string ape = dr.GetString(3);
  int edad = dr.GetInt32(4);
  cant++;

}

dr.Close();
c.Close();

System.Console.WriteLine($"Se leyo {cant} personas");


