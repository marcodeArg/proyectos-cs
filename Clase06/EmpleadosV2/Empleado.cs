namespace Empresa
{
    abstract class Empleado
    {
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public decimal SueldoBase { get; set; }

        public Empleado(int legajo, string nombre, decimal sueldoBase)
        {
            Legajo = legajo;
            Nombre = nombre;
            SueldoBase = sueldoBase;
        }

        public abstract decimal Sueldo();

        public override string ToString()
        {
            return $"{base.ToString()}, Legajo: {Legajo} - Nombre: {Nombre} - Sueldo: {Sueldo():C}";
        }
    }
}