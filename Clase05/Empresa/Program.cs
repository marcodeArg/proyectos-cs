
namespace Empresa
{
    class Program
    {
        private static void Main(string[] args)
        {
            Empleado e1 = new Empleado(51545, "Empleado", 1000);
            Empleado obrero = new Obrero(51545, "Obrero", 1000, 20);
            Empleado administrativo = new Administrativos(51545, "Administrativo", 1000, true);
            Empleado vendedor = new Vendedores(51545, "Vendedor", 1000, 250);

            Console.WriteLine(e1);
            Console.WriteLine(obrero);
            Console.WriteLine(administrativo);
            Console.WriteLine(vendedor);
        }
    }
}
