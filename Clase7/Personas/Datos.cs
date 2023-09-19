namespace Personas
{
    class Datos
    {
        public static List<Persona> ProcesarDatos()
        {
            List<Persona> personas = new List<Persona>();

            using (StreamReader sr = new StreamReader("./personas.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string[] linea = sr.ReadLine().Split(",");

                    int dni = Convert.ToInt32(linea[0]);
                    string nombre = linea[1];
                    string apellido = linea[2];
                    int edad = Convert.ToInt32(linea[3]);

                    personas.Add(new Persona(dni, nombre, apellido, edad));
                }
            }

            return personas;
        }

        public static List<Persona> Filtrar(List<Persona> personas, string? orden, string? apellido)
        {
            if (apellido is not null && orden is not null)
            {
                List<Persona> personasFiltradas = personas.FindAll(persona => persona.Apellido == apellido.ToUpper());

                switch (orden)
                {
                    case "1":
                        personasFiltradas.Sort(new OrdenarPorDocumento());
                        break;
                    case "2":
                        personasFiltradas.Sort(new OrdenarPorDocumento());
                        personasFiltradas.Reverse();
                        break;
                    case "3":
                        personasFiltradas.Sort(new OrdenarPorApellido());
                        break;
                    case "4":
                        personasFiltradas.Sort(new OrdenarPorApellido());
                        personasFiltradas.Reverse();
                        break;
                    case "5":
                        personasFiltradas.Sort(new OrdenarPorEdad());
                        break;
                    case "6":
                        personasFiltradas.Sort(new OrdenarPorEdad());
                        personasFiltradas.Reverse();
                        break;
                }

                return personasFiltradas;
            }
            else
            {
                throw new Exception("Debe ingresar todos los datos");
            }
        }

        public static List<Persona> Filtrar(List<Persona> personas, string? orden, int edadMinima, int edadMaxima)
        {
            List<Persona> personasFiltradas = personas.FindAll(persona => persona.Edad >= edadMinima && persona.Edad <= edadMaxima);

            switch (orden)
            {
                case "1":
                    personasFiltradas.Sort(new OrdenarPorDocumento());
                    break;
                case "2":
                    personasFiltradas.Sort(new OrdenarPorDocumento());
                    personasFiltradas.Reverse();
                    break;
                case "3":
                    personasFiltradas.Sort(new OrdenarPorApellido());
                    break;
                case "4":
                    personasFiltradas.Sort(new OrdenarPorApellido());
                    personasFiltradas.Reverse();
                    break;
                case "5":
                    personasFiltradas.Sort(new OrdenarPorEdad());
                    break;
                case "6":
                    personasFiltradas.Sort(new OrdenarPorEdad());
                    personasFiltradas.Reverse();
                    break;
            }

            return personasFiltradas;
        }

        public static List<Persona> Filtrar(List<Persona> personas, string? orden, int secuencia)
        {
            List<Persona> personasFiltradas = personas.FindAll(persona => persona.Documento.ToString().EndsWith(secuencia.ToString()));

            switch (orden)
            {
                case "1":
                    personasFiltradas.Sort(new OrdenarPorDocumento());
                    break;
                case "2":
                    personasFiltradas.Sort(new OrdenarPorDocumento());
                    personasFiltradas.Reverse();
                    break;
                case "3":
                    personasFiltradas.Sort(new OrdenarPorApellido());
                    break;
                case "4":
                    personasFiltradas.Sort(new OrdenarPorApellido());
                    personasFiltradas.Reverse();
                    break;
                case "5":
                    personasFiltradas.Sort(new OrdenarPorEdad());
                    break;
                case "6":
                    personasFiltradas.Sort(new OrdenarPorEdad());
                    personasFiltradas.Reverse();
                    break;
            }

            return personasFiltradas;
        }
    }
}