namespace Partido
{
    //    * Cantidad de partidos jugados
    //    * Cantidad de partidos jugados como local
    //    * Cantidad de partidos jugados como visitante
    //    * Suma de goles realizados
    //    * Suma de goles recibidos
    //    * Diferencia total de goles
    //    * Cantidad de partidos ganados
    //    * Cantidad de partidos empatados
    //    * Cantidad de partidos recibidos
    //    * Sumatoria de puntos (suponiendo que todos los partidos son de un mismo campeonato)
    class Equipo
    {
        public string NombreEqupo { get; set; }
        public int PartidosGanados { get; set; }
        public int PartidosPerdidos { get; set; }
        public int PartidosEmpatados { get; set; }
        public int PartidosLocal { get; set; }
        public int PartidosVisitante { get; set; }
        public int GolesRealizados { get; set; }
        public int GolesRecibidos { get; set; }

        private Partido? partidoAnotado;

        public Equipo(string nombre)
        {
            NombreEqupo = nombre;
        }

        public void RegistrarPartido(Partido p)
        {
            partidoAnotado = p;
        }

        public void Informacion()
        {
            Console.WriteLine("\n====== Info del equipo ======");
            Console.WriteLine($"Nombre del equipo {NombreEqupo}");
            Console.WriteLine($"Partidos jugados = {PartidosGanados + PartidosEmpatados + PartidosPerdidos}");
            Console.WriteLine($"Partidos jugados como local = {PartidosLocal}");
            Console.WriteLine($"Partidos jugados como visitante = {PartidosVisitante}");
            Console.WriteLine($"Goles realizados = {GolesRealizados}");
            Console.WriteLine($"Goles recibidos = {GolesRecibidos}");
            Console.WriteLine($"Diferencia de goles = {Math.Abs(GolesRealizados - GolesRecibidos)}");
            Console.WriteLine($"Partidos ganados = {PartidosGanados}");
            Console.WriteLine($"Partidos perdidos = {PartidosPerdidos}");
            Console.WriteLine($"Partidos empatados = {PartidosEmpatados}");
        }

        public override string ToString()
        {
            return NombreEqupo;
        }


    }
}