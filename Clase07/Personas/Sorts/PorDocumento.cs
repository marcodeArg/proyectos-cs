namespace Personas
{
    class OrdenarPorDocumento : IComparer<Persona>
    {
        public int Compare(Persona? x, Persona? y)
        {
            return x.Documento - y.Documento;
        }
    }
}