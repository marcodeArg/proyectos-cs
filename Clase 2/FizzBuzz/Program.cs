using System;


namespace FizzBuz {
    class Program {
        private static void Main(string[] args) {
            Console.WriteLine("=======FIZZBUZZ=======");

            for (int i = 1; i <= 100; i++)
            {
                if(i % 15 == 0) 
                {
                    Console.Write("fizzbuzz ");
                } 
                else if (i % 5 == 0)
                {
                    Console.Write("buzz ");
                }
                else if (i % 3 == 0)
                {
                    Console.Write("fizz ");
                } 
                else 
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}