
namespace Partido
{
    class Program
    {
        private static void Main(string[] args)
        {
            Equipo jl = new Equipo("Jota L");
            Equipo ntc = new Equipo("Nao tem como");

            Partido p = new Partido(jl, ntc);
            jl.RegistrarPartido(p);
            ntc.RegistrarPartido(p);

            p.GolesLocal = 4;
            p.GolesVisitante = 1;
            p.Ganador();


            Partido p1 = new Partido(jl, 0, ntc, 2);
            jl.RegistrarPartido(p1);
            ntc.RegistrarPartido(p1);
            p1.Ganador();
            Partido p3 = new Partido(jl, 1, ntc, 1);
            jl.RegistrarPartido(p3);
            ntc.RegistrarPartido(p3);
            p3.Ganador();
            Partido p4 = new Partido(jl, 3, ntc, 8);
            jl.RegistrarPartido(p4);
            ntc.RegistrarPartido(p4);
            p4.Ganador();
            Partido p5 = new Partido(jl, 4, ntc, 1);
            jl.RegistrarPartido(p5);
            ntc.RegistrarPartido(p5);
            p5.Ganador();

            jl.Informacion();
            ntc.Informacion();

        }
    }
}

