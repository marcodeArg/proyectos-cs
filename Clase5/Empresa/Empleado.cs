namespace Empresa
{
    class Empleado
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public decimal SueldoBase { get; set; }

        public Empleado(int legajo, string nombre, decimal sueldobase)
        {
            Legajo = legajo;
            Nombre = nombre;
            SueldoBase = sueldobase;
        }

        public virtual decimal Sueldo()
        {
            return SueldoBase;
        }

        public override string ToString()
        {
            return $"{base.ToString()}  {Math.Round(Sueldo(), 2)} ";
        }
    }
}