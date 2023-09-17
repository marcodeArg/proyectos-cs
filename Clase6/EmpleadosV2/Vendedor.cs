namespace Empresa
{
    class Vendedor : Empleado
    {
        public decimal TotalVentas { get; set; }

        public Vendedor(int legajo, string nombre, decimal sueldoBase, decimal totalVentas) : base(legajo, nombre, sueldoBase)
        {
            TotalVentas = totalVentas;
        }

        public override decimal Sueldo()
        {
            return SueldoBase + TotalVentas * (decimal)0.1;
        }
    }
}