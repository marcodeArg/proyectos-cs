namespace Banco
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<Cuenta> cuentas = new List<Cuenta>();

            Console.WriteLine("Desea Cargar cuentas? (s/n)");
            string opcion = Console.ReadLine().ToLower();

            while (opcion != "n")
            {
                Console.WriteLine("Tipo de cuenta que desea cargar: 1.Corriente 2.Ahorro");
                string tipoCuenta = Console.ReadLine();


                if (tipoCuenta == "1")
                {
                    Console.Write("\nLegajo: ");
                    int legajo = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Saldo: ");
                    decimal saldo = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Limite: ");
                    decimal limite = Convert.ToDecimal(Console.ReadLine());

                    cuentas.Add(new CuentaCorriente(legajo, nombre, saldo, limite * -1));
                }
                else if (tipoCuenta == "2")
                {
                    Console.Write("\nLegajo: ");
                    int legajo = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Saldo: ");
                    decimal saldo = Convert.ToDecimal(Console.ReadLine());

                    cuentas.Add(new CuentaAhorro(legajo, nombre, saldo));
                }
                else
                {
                    continue;
                }

                Console.WriteLine("Desea Cargar cuentas? (s/n)");
                opcion = Console.ReadLine().ToLower();
            }

        }
    }
}

