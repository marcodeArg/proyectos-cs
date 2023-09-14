namespace Empresa
{
    class Administrativos : Empleado
    {
        public bool Presentismo { get; set; }

        public Administrativos(int legajo, string nombre, decimal sueldobase, bool cumplioprecentismo) : base(legajo, nombre, sueldobase)
        {
            Presentismo = cumplioprecentismo;
        }

        public override decimal Sueldo()
        {
            if (Presentismo)
            {
                return SueldoBase * (decimal)1.13;
            }

            return SueldoBase;
        }

    }
}