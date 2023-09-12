namespace Ascensor
{
  class Ascensor
  {

    // var cant maxPersonas, pisoMax, pisoMin, pisoActual, pasajeros
    // metodo Desplazarse 2. y cambiar la variable piso actual a el piso ingresado
    //      
    //
    //  metodo SubirPersonas 3. y sumarle a la variable pasajeros
    //     
    //  metodo BajarPersonas 4. y restarle a la variable pasajeros
    //      
    //
    //
    //
    // metodo auxiliares 
    // 2.Validar Piso -> verificar si el piso ingresado es correcto (bool)
    // 3.Validar si entran los pasajaros (int - cantidad de pasajareos que entraron)
    // 4.Validar que no se bajen menos pasajeros de los que hay y que tampoco sea menos a 0, en caso de que sea, solo poner que todos bajaron  (int - cantidad de pasajeron que salieron) 




    private int pisoActual;
    private int pasajeros;
    private const int pisoMax = 10;
    private const int pisoMin = -2;
    private const int capacidadMax = 5;

    public Ascensor()
    {
      this.pisoActual = 0;
      this.pasajeros = 0;
    }



    public void CambiarPiso(int numPiso)
    {
      if (VerificarPiso(numPiso))
      {
        this.pisoActual = numPiso;
        Console.WriteLine($"El ascensor se encuentra en el piso {this.pisoActual} y tiene {this.personas} personas");
      }
      else
      {
        Console.WriteLine($"El piso ingresado no existe");
      }
    }

    public bool SubirPersonas(int personas)
    {
      if (this.personas + personas <= capacidadMax)
      {
        Console.WriteLine($"Todas las personas subieron al ascensor. Actualmente hay {this.personas} personas");
        return true;
      }
      else
      {
        if (this.personas + personas - capacidadMax != 0)
        {
          Console.WriteLine($"Entraron solamente {this.personas} personas");
          return true;
        }
      }
      Console.WriteLine($"No entra nadie. El ascensor esta lleno");
      return false;
    }

    public bool BajarPersonas(int personas)
    {
      if (this.personas - personas >= 0)
      {
        Console.WriteLine($"Todas las personas bajaron del ascensor. Actualmente hay {this.personas} personas");
        return true;
      }
      else
      {
        if (this.personas - personas + capacidadMax != 0)
        {
          Console.WriteLine($"Entraron solamente {this.personas} personas");
          return true;
        }
      }
      Console.WriteLine($"No entra nadie. El ascensor esta lleno");
      return false;
    }


    private bool VerificarPiso(int piso)
    {
      return piso > pisoMin && piso < pisoMax;
    }


  }
}

