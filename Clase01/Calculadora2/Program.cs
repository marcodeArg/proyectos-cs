

class Program
{
    private static void Main(string[] args)
    {
        try
        {
            string texto = File.ReadAllText("./numeros.csv");

            string[] numeros = texto.Split(",");
            int indice = 0;

            while(indice < numeros.Length - 1) {

                int num1 = Convert.ToInt32(numeros[indice]);
                int num2 = Convert.ToInt32(numeros[indice + 1]);

                int suma =  num1 + num2;
                int resta = num1 - num2;
                int producto = num1 * num2;
                double cociente = (double)num1 / (double)num2;

                Console.WriteLine($"\nNumeros {indice+1} y {indice+2}\nSuma = {suma}\nResta = {resta}\nProducto = {producto}\nCociente = {Math.Round(cociente, 2)}");

                indice++;
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}