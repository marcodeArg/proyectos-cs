namespace Personas
{

    public class Persona
    {
        private int documento;
        private string nombre;
        private string apellido;
        private int edad;

        public int Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public Persona()
        {
        }

        public Persona(int documento, string nombre, string apellido, int edad)
        {
            Documento = documento;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }


        public List<Persona> getPersonas()
        {
            List<Persona> personas = new List<Persona>();

            using (StreamReader sr = new StreamReader("./personas.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string[] dto = sr.ReadLine().Split(",");
                    personas.Add(new Persona(Convert.ToInt32(dto[0]), dto[1], dto[2], Convert.ToInt32(dto[3])));
                }
            }

            return personas;
        }


        public override string ToString()
        {
            return $" {Documento} {Nombre} {Apellido} {Edad}";
        }
    }
}