namespace Banco
{
    class Program
    {
        private static void Main(string[] args)
        {
            List<Cuenta> cuentas = new List<Cuenta>
            {
                new CuentaCorriente(156156, "cc1", 1000, 200),
                new CuentaAhorro(2424545, "ca1", 25000),
                new CuentaCorriente(354312, "cc2", 0, 100),
                new CuentaAhorro(548751, "ca2", 150),
                new CuentaCorriente(345541, "cc3", 10000, 890),
                new CuentaAhorro(3782135, "ca3", 1980),
                new CuentaCorriente(154254, "cc4", 230, 100),
                new CuentaAhorro(13784, "ca4", 6500),
                new CuentaCorriente(735431, "cc5", 560, 125),
                new CuentaAhorro(9434345, "ca15", 11230)
            };



        }
    }
}

