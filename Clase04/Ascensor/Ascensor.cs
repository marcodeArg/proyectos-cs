namespace Ascensor
{
  class Ascensor
  {
    private int pisoActual;
    private int personas;
    private const int pisoMax = 10;
    private const int pisoMin = -2;
    private const int capacidadMax = 5;

    public Ascensor()
    {
      pisoActual = 0;
      personas = 0;
    }

    public void CambiarPiso(int numPiso)
    {
      if (ValidarPiso(numPiso))
      {
        pisoActual = numPiso;
      }
      else
      {
        Console.WriteLine($"El piso ingresado no existe");
      }
    }

    public void SubirPersonas(int personas)
    {
      if (ValidarSubidaPersonas(personas) == 0)
      {
        this.personas += personas;
      }
      else
      {
        Console.WriteLine($"{ValidarSubidaPersonas(personas)} personas no se pudieron subir al ascensor");
        this.personas += personas - ValidarSubidaPersonas(personas);
      }

    }

    // Devuelve la cantidad de personas que no entraron
    private int ValidarSubidaPersonas(int personas)
    {
      if (this.personas + personas <= capacidadMax)
      {
        return 0;
      }

      return this.personas + personas - capacidadMax;
    }


    public void BajarPersonas(int personas)
    {
      if (ValidarBajadaPersonas(personas) == 0)
      {
        this.personas -= personas;
      }
      else
      {
        //                    mas por menos = menos. Puedo Hacer esto, o que el validar devuelva el valor abs.
        this.personas -= personas + ValidarBajadaPersonas(personas);
      }

    }

    // Devuelve la cantidad de personas que no se bajaron porque no existen
    private int ValidarBajadaPersonas(int personas)
    {
      if (this.personas - personas >= 0)
      {
        return 0;
      }
      else
      {
        return this.personas - personas;
      }
    }


    private bool ValidarPiso(int piso)
    {
      return piso > pisoMin && piso < pisoMax;
    }

    public override string ToString()
    {
      return $"Actualmente hay {this.personas} personas en el ascensor y se encuentra en el piso {pisoActual}";
    }

  }
}

