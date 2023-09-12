namespace Patrones
{
    class PatternMatching
    {
        public static string ObtenerDeposito(string[] texto) 
        {
            if(texto is ICollection<string> vector)
            {
                if (texto[1] is "DEPOSIT") {
                    return texto[3];
                } else {
                    return "Se que es un vector, pero no se deposito nada";
                }
            }

            return "No soy un vector";
        }



        public static string ObtenerDeposito()
    }
}