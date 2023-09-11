using System;

namespace Program
{
  class Program
  {
    private static void Main(string[] args)
    {
      string msg = """
      1. Agregar Puntos 
      2. Salir
      >> 
      """;

      int opcion = -1;

      while (opcion != 2)
      {
        Console.Write(msg);
        opcion = Convert.ToInt32(Console.ReadLine());

        if (opcion == 1)
        {
          try
          {
            Console.Write("\nIngrese la cordenada x: ");
            float x = float.Parse(Console.ReadLine());
            Console.Write("Ingrese la cordenada y: ");
            float y = float.Parse(Console.ReadLine());

            Punto p = new(x, y);

            Console.Write("\nTe gustaria compararlo con otro punto(S/N): ");

            Console.WriteLine($"\nDistancia al origen: {p.DistanciaAlOrigen()}");
            if (p.Cuadrate() == Cuadrantes.EjeX || p.Cuadrate() == Cuadrantes.EjeY)
            {
              Console.WriteLine($"El punto ({x}, {y}) se encuentra sobre el {p.Cuadrate()}");
            }
            else
            {
              Console.WriteLine($"El punto ({x}, {y}) se encuentra en el {p.Cuadrate()} cuadrante");
            }


          }
          catch (Exception)
          {

            throw;
          }




        }

      }
    }
  }
}
