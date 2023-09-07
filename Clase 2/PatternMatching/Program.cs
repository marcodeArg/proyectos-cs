using System;
using System.IO;

namespace Patrones
{
    class Program
    {
        public static void Main() 
        {
            using (StreamReader sr = new StreamReader("./recursos.txt"))
            {
                while (!sr.EndOfStream)
                {
                    string[] palabras = sr.ReadLine().Split(",");
                    int index = 0;
                    //string[] palabras = linea.Split(",");

                    foreach (string item in palabras)
                    {
                        palabras[index] = item.Trim();
                        index++;
                    }

                    string deposito = PatternMatching.ObtenerDeposito(palabras);

                    Console.WriteLine(deposito);
                }

            }


        }
    }
}