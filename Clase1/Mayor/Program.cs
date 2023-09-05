
class Program
{
  public static void Main()
  {
    Console.WriteLine("Mayor de dos números\n");

    Console.Write("Ingrese el primer número: ");
    int numero1 = Convert.ToInt32(Console.ReadLine());
    Console.Write("Ingrese el segundo número: ");
    int numero2 = Convert.ToInt32(Console.ReadLine());

    int mayor = Math.Max(numero1, numero2);
    Console.Write($"\nEl mayor es: {mayor}");


  }
}