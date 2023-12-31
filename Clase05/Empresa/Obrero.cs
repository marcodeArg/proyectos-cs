namespace Empresa
{
    class Obrero : Empleado
    {
        public int DiasTrabajados { get; set; }
        public Obrero(int legajo, string nombre, decimal sueldobase, int dias) : base(legajo, nombre, sueldobase)
        {
            DiasTrabajados = dias;
        }

        public override decimal Sueldo()
        {
            return SueldoBase / 22 * DiasTrabajados;
        }




    }
}