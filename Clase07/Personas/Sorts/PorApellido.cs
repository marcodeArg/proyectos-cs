namespace Personas
{
    class OrdenarPorApellido : IComparer<Persona>
    {
        public int Compare(Persona? x, Persona? y)
        {
            if (x.Apellido.CompareTo(y.Apellido) == 0)
            {
                return x.Nombre.CompareTo(y.Nombre);
            }

            return x.Apellido.CompareTo(y.Apellido);

        }
    }
}