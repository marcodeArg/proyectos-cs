using System;

namespace Temperaturas
{
  class Program
  {
    // Ingresar un conjunto de temperaturas, 
    //  -Finalizar la carga cuando se reciba un 1000. 
    //  -Sólo aceptar temperaturas entre -20 y 50 grados.

    // Mostrar:
    // -Cantidad de días con temperatura bajo cero
    // -Promedio de temperaturas
    // -Promedio de temperaturas de los días cálidos, es decir con temp. mayor a 20
    // -Mostrar "Si" o "No" para indicar si hubo algún día con más de 40 grados.
    // -La mayor temperatura de los días que no fueron cálidos

    private static void Main(string[] args)
    {
      Console.WriteLine("=======Temperaturas=======");

      string msg = """

      Ingrese una temperatura
      -Sólo aceptar temperaturas entre -20 y 50 grados
      -Para finalizar la carga ingrese 1000
      >> 
      """;

      double temp = -1;
      // primer punto
      int contadorBajoCero = 0;

      // segundo punto
      int contadorTemps = 0;
      double acumuladorTemps = 0;

      // tercer punto
      int contadorCalido = 0;
      double acumuladorCalido = 0;

      // cuarto punto
      bool diaCaluroso = false;

      // quinto punto
      double mayorTemp = -1000;

      Console.Write(msg);
      temp = Convert.ToDouble(Console.ReadLine());

      while (temp != 1000)
      {

        if (temp >= -20 && temp <= 50)
        {
          contadorTemps++;
          acumuladorTemps += temp;

          if (temp > 40)
          {
            diaCaluroso = true;
          }
          else if (temp >= 20)
          {
            contadorCalido++;
            acumuladorCalido += temp;
          }
          else
          {

            if (temp < 0)
            {
              contadorBajoCero++;
            }

            if (temp > mayorTemp)
            {
              mayorTemp = temp;
            }
          }
        }

        else
        {
          Console.WriteLine("Error! Debe ingresar una temperatura valida");
        }

        Console.Write(msg);
        temp = Convert.ToDouble(Console.ReadLine());
      }

      Console.WriteLine($"\nCantidad de días con temperatura bajo cero: {contadorBajoCero}");
      Console.WriteLine($"Promedio de temperaturas: {acumuladorTemps / contadorTemps} grados");
      Console.WriteLine($"Promedio de temperaturas de los días cálidos: {acumuladorCalido / contadorCalido} grados");
      Console.WriteLine($"{(diaCaluroso ? "Si" : "No")} se ingresó al menos un día con mas de 40 grados");
      Console.WriteLine($"La mayor temperatura de los días que no fueron cálidos: {mayorTemp} grados");
    }
  }
}
