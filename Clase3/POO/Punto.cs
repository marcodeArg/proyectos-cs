using System;

namespace Program
{
  public record Punto(float X, float Y)
  {
    public double DistanciaAlOrigen()
    {
      return Math.Round(Math.Sqrt(X * X + Y * Y), 2);
    }

    public double DistanciaAPunto(float x1, float y1)
    {
      return Math.Round(Math.Sqrt((X - x1) * (X - x1) + (Y - y1) * (Y - y1)), 2);
    }

    public double DistanciaAPunto(Punto p)
    {
      return Math.Round(Math.Sqrt((X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y)), 2);
    }

    public Cuadrantes Cuadrate()
    {
      return (Math.Sign(X), Math.Sign(Y)) switch
      {
        (1, 1) => Cuadrantes.Primer,
        (-1, 1) => Cuadrantes.Segundo,
        (-1, -1) => Cuadrantes.Tercero,
        (1, -1) => Cuadrantes.Cuarto,
        (0, 0) => Cuadrantes.Origen,
        (_, 0) => Cuadrantes.EjeX,
        (0, _) => Cuadrantes.EjeY,
        _ => Cuadrantes.Error
      };
    }
  }
}