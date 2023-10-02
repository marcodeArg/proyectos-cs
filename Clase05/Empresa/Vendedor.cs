namespace Empresa
{
    class Vendedores : Empleado
    {
        public decimal TotalVentas { get; set; }

        public Vendedores(int legajo, string nombre, decimal sueldobase, decimal totalventas) : base(legajo, nombre, sueldobase)
        {
            TotalVentas = totalventas;
        }

        public override decimal Sueldo()
        {
            return SueldoBase + TotalVentas * (decimal)0.1;
        }
    }
}