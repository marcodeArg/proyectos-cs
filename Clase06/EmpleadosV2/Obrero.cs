namespace Empresa
{
    class Obrero : Empleado
    {
        public int DiasTrabajados { get; set; }
        public Obrero(int legajo, string nombre, decimal sueldoBase, int dias) : base(legajo, nombre, sueldoBase)
        {
            DiasTrabajados = dias;
        }

        public override decimal Sueldo()
        {
            return SueldoBase / 20 * DiasTrabajados;
        }
    }
}