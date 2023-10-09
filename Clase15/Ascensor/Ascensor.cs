/*


Un ascensor posee una capacidad máxima de n personas y está
instalado en un edificio cuyos pisos se encuentran numerados. Se
necesita desarrollar una clase Ascensor que represente el
funcionamiento del mismo y que posea métodos para:

*   Desplazarse a un piso determinado
*   Subir personas
*   Bajar personas
*   Informar el piso donde se encuentra y la cantidad de personas que hay adentro

Los métodos deben verificar que el estado siempre sea correcto:

-   Si se solicitar ir a un piso debe retornar verdadero si el piso
    existe y falso si no. Por ejemplo, si el ascensor puede viajar
    entre los pisos -2 y 10, debe retornar falso si le solicitan ir
    a un piso fuera de ese rango.
-   Si la cantidad de personas que quieren subir supera la
    capacidad, debe retornar la cantidad de personas que
    efectivamente entren.
-   Si la cantidad de personas que quieren bajar supera a la
    cantidad de personas que efectivamente hay adentro del ascensor,
    debe retornar esa última cantidad, es decir, que todos salen.
-   Si para subir o bajar el método recibe una cantidad no válida,
    debe retornar -1.
-   El método toString debe informar el piso en que se encuentra y
    la cantidad de personas que hay adentro en ese momento.

*/
namespace Ascensor
{
    class Ascensor
    {
        private int pisoActual;
        private int personas;
        private int pisoMax;
        private int pisoMin;
        private int capacidadMax;

        public Ascensor(int pisoMin, int pisoMax, int capacidadMax)
        {
            this.pisoMax = pisoMax;
            this.pisoMin = pisoMin;
            this.capacidadMax = capacidadMax;
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

