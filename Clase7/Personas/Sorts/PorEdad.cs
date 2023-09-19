namespace Personas
{
    class OrdenarPorEdad : IComparer<Persona>
    {
        public int Compare(Persona? x, Persona? y)
        {
            return x.Edad - y.Edad;
        }
    }
}