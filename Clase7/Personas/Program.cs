using Microsoft.VisualBasic;

namespace Personas
{
    class Program
    {
        public static void Main()
        {
            List<Persona> personas = Datos.ProcesarDatos();

            string msg = """ 
            
            Seleccione una opcion:
            1. Listar todas las personas cuyo apellido coincida con uno ingresado
            2. Listar todas las personas cuya edad se encuentre en un rango ingresado
            3. Listar todas las personas cuyo documento finalice en una secuencia ingresada
            4. Salir
            >> 
            """;

            string ordenamiento = """
            Seleccione el metodo de ordenamiento:
            1. Por documento (ascendente)
            2. Por documento (descendente)
            3. Por apellido (ascendente)
            4. Por apellido (descendente)
            5. Por edad (ascendente)
            6. Por edad (descendente)
            >>
            """;

            Console.Write(msg);
            int opcion = Convert.ToInt16(Console.ReadLine());

            while (opcion != 4)
            {
                if (opcion == 1)
                {
                    Console.Clear();
                    Console.Write("\nIntroduzca un apellido: ");
                    string? apellido = Console.ReadLine();

                    Console.Write($"\n{ordenamiento}");
                    string? orden = Console.ReadLine();

                    Console.WriteLine("");

                    foreach (Persona persona in Datos.Filtrar(personas, orden, apellido))
                    {
                        Console.WriteLine(persona);
                    }
                }
                else if (opcion == 2)
                {
                    Console.Clear();
                    Console.Write("\nIntroduzca la edad mas baja: ");
                    int edadMenor = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Introduzca la edad mas alta: ");
                    int edadMayor = Convert.ToInt32(Console.ReadLine());

                    Console.Write($"\n{ordenamiento}");
                    string? orden = Console.ReadLine();

                    Console.WriteLine("");

                    foreach (Persona persona in Datos.Filtrar(personas, orden, edadMenor, edadMayor))
                    {
                        Console.WriteLine(persona);
                    }
                }
                else if (opcion == 3)
                {
                    Console.Clear();
                    Console.Write("\nIntroduzca la secuencia: ");
                    int secuencia = Convert.ToInt32(Console.ReadLine());

                    Console.Write($"\n{ordenamiento}");
                    string? orden = Console.ReadLine();

                    Console.WriteLine("");

                    foreach (Persona persona in Datos.Filtrar(personas, orden, secuencia))
                    {
                        Console.WriteLine(persona);
                    }
                }
                else
                {
                    Console.WriteLine("El valor ingresado no existe");
                }

                Console.Write(msg);
                opcion = Convert.ToInt16(Console.ReadLine());
            }

        }
    }

}