using System.Dynamic;

namespace Partido
{
    class Partido
    {
        private Equipo local;
        private Equipo visitante;
        private int golesLocal;
        private int golesVisitante;

        public int GolesLocal
        {
            get
            {
                return golesLocal;
            }
            set
            {
                if (value >= 0)
                {
                    golesLocal = value;
                }
            }
        }

        public int GolesVisitante
        {
            get
            {
                return golesVisitante;
            }
            set
            {
                if (value >= 0)
                {
                    golesVisitante = value;
                }
            }
        }

        public Partido(Equipo local, int golesLocal, Equipo visitante, int golesVisitante)
        {
            this.local = local;
            this.local.PartidosLocal++;
            this.golesLocal = golesLocal;
            this.local.GolesRealizados += golesLocal;
            this.local.GolesRecibidos += golesVisitante;

            this.visitante = visitante;
            this.visitante.PartidosVisitante++;
            this.golesVisitante = golesVisitante;
            this.visitante.GolesRealizados += golesVisitante;
            this.local.GolesRecibidos += golesLocal;

        }

        public Partido(Equipo local, Equipo visitante)
        {
            this.local = local;
            this.local.PartidosLocal++;

            this.visitante = visitante;
            this.visitante.PartidosVisitante++;

            golesLocal = 0;
            golesVisitante = 0;
        }

        public void GolLocal()
        {
            golesLocal++;
            local.GolesRealizados++;
            visitante.GolesRealizados++;
        }

        public void GolVisitante()
        {
            golesVisitante++;
            visitante.GolesRealizados++;
            local.GolesRealizados++;
        }

        public void Ganador()
        {
            if (golesLocal > golesVisitante)
            {
                Console.WriteLine(local);
                local.PartidosGanados++;
                visitante.PartidosPerdidos--;
            }
            else if (golesVisitante > golesLocal)
            {
                Console.WriteLine(visitante);
                visitante.PartidosGanados++;
                local.PartidosPerdidos--;
            }
            else
            {
                Console.WriteLine("Empata!");
                local.PartidosEmpatados++;
                visitante.PartidosEmpatados++;
            }
        }


    }
}