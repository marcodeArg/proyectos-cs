namespace Empresa
{
    class Administrativo : Empleado
    {
        public bool Presentismo { get; set; }

        public Administrativo(int legajo, string nombre, decimal sueldoBase, bool cumplioPresentismo) : base(legajo, nombre, sueldoBase)
        {
            Presentismo = cumplioPresentismo;
        }

        public override decimal Sueldo()
        {
            if (Presentismo)
            {
                return SueldoBase * 1.13m;
            }

            return SueldoBase;
        }

    }
}