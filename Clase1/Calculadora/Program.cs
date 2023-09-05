class Program
{
    private static void Main(string[] args)
    {
        try {

            Console.Write("Introduzca el primer número: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduzca el segundo número: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int suma = num1 + num2;
            int resta = num1 - num2;
            int producto = num1 * num2;
            double cociente = (double)num1 / (double)num2;

            Console.WriteLine($"\nSuma = {suma}\nResta = {resta}\nProducto = {producto}\nCociente = {Math.Round(cociente, 2)}");

        }

        catch(Exception ex) {
            Console.WriteLine($"\nError: {ex.Message}");
        }

        
        
    }
}