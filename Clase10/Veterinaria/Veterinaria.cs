namespace Veterinaria
{
  class Veterinaria
  {
    public int Codigo { get; set; }

    private HashSet<Atencion> atenciones;

    public Veterinaria(int codigo)
    {
      Codigo = codigo;
      atenciones = new();
    }

    public void AñadirAtencion(Atencion atencion)
    {
      atenciones.Add(atencion);
    }

    public decimal ImporteTotalGatos()
    {
      decimal total = 0;

      foreach (Atencion atencion in atenciones)
      {
        if (atencion is AtencionMedica aten)
        {

          if (aten.Mascota.Especie == Especie.Gato)
          {
            total += atencion.ImporteACobrar();
          }

        }
      }

      return total;
    }

    public int CantidadAtencionesHasta(decimal importe)
    {
      return atenciones.Count(x => 1000 <= x.Importe && x.Importe <= importe);
    }

    public AtencionMedica? primerAtencionMedicaGato()
    {
      foreach (Atencion atencion in atenciones)
      {
        if (atencion is AtencionMedica aten)
        {
          if (aten.Mascota.Especie == Especie.Gato)
          {
            return aten;
          }
        }
      }

      return null;
    }




  }

}