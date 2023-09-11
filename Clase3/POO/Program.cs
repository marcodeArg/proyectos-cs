using System;

namespace Program
{
  class Program
  {
    private static void Main(string[] args)
    {
      string msg = @"
===================================
1. Agregar Puntos
2. Salir
===================================
>> ";

      int opcion = -1;

      while (opcion != 2)
      {
        Console.Write(msg);
        opcion = Convert.ToInt32(Console.ReadLine());

        if (opcion == 1)
        {

          Console.Clear();

          Console.Write("\nIngrese la cordenada x: ");
          float x = float.Parse(Console.ReadLine());

          Console.Write("Ingrese la cordenada y: ");
          float y = float.Parse(Console.ReadLine());

          // PRIMER PUNTO
          Punto p = new(x, y);

          Console.Write("\nTe gustaria compararlo con otro punto(S/N): ");
          string punto2 = Console.ReadLine().ToLower();

          Console.Clear();

          if (punto2 == "s")
          {
            Console.Write("\nIngrese la cordenada x: ");
            float x1 = float.Parse(Console.ReadLine());

            Console.Write("Ingrese la cordenada y: ");
            float y1 = float.Parse(Console.ReadLine());

            Console.Clear();
            // SEGUNDO PUNTO
            Punto p2 = new(x1, y1);

            // MUESTRA DE RESULTADOS
            Console.WriteLine($"La distancia entre los puntos ({x}, {y}) y el punto ({x1}, {y1}) es de {p.DistanciaAPunto(p2)}");
          }


          Console.WriteLine($"Distancia entre el punto ({x}, {y}) y el origen: {p.DistanciaAlOrigen()}");

          if (p.Cuadrate() == Cuadrantes.EjeX || p.Cuadrate() == Cuadrantes.EjeY || p.Cuadrate() == Cuadrantes.Origen)
          {
            Console.WriteLine($"El punto ({x}, {y}) se encuentra sobre el {p.Cuadrate()}");
          }
          else
          {
            Console.WriteLine($"El punto ({x}, {y}) se encuentra en el {p.Cuadrate()} cuadrante");
          }
        }
        else if (opcion == 2)
        {
          break;
        }
        else
        {
          Console.WriteLine("Error, ingrese una opcion valida");
        }
      }
    }
  }
}
