namespace Personas
{
    class Program
    {
        private static void Main(string[] args)
        {
            Persona p = new Persona();
            List<Persona> personas = p.getPersonas();


            Persona? mayor = null;

            foreach (Persona personaActual in personas)
            {
                if (mayor == null || mayor.Edad < personaActual.Edad)
                {
                    mayor = personaActual;
                }
            }

            Console.WriteLine(mayor);

        }
    }
}

