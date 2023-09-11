using System;


namespace Program
{
  public record Punto(float x, float y)
  {
    public double DistanciaAlOrigen()
    {
      return Math.Sqrt(x * x + y * y);
    }

    public double DistanciaAPunto(float x1, float y1)
    {
      return Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
    }

    public double DistanciaAPunto(Punto p)
    {
      return Math.Sqrt((x - p.x) * (x - p.x) + (y - p.y) * (y - p.y));
    }

    public Cuadrantes Cuadrate()
    {
      return (Math.Sign(x), Math.Sign(y)) switch
      {
        (1, 1) => Cuadrantes.Primero,
        (-1, 1) => Cuadrantes.Segundo,
        (-1, -1) => Cuadrantes.Tercero,
        (1, -1) => Cuadrantes.Cuarto,
        (_, 0) => Cuadrantes.EjeX,
        (0, _) => Cuadrantes.EjeY,
        _ => Cuadrantes.Error
      };
    }
  }
}