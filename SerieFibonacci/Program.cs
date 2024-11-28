using System;
using System.Numerics;

namespace Fibo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new string('-',20));
            Console.WriteLine("Serie Fibonacci");
            Console.WriteLine(new string('-',20));
            Console.Write("Ïntroduce la cantidad de numeros que deseas de la serie:");
            int Cantidad = int.Parse(Console.ReadLine());
            BigInteger[]Serie = SerieFibo(Cantidad);
            foreach (BigInteger i in Serie) 
                Console.WriteLine(i);

        }


        static BigInteger[] SerieFibo(int Cantidad)
        {
            BigInteger[] Serie = new BigInteger[Cantidad];
            if (Cantidad <= 1)
                return new BigInteger[1]{0};

            Serie[0] = 0;
            Serie[1] = 1;
            int Contador = 3;

            while(Contador <=Cantidad)
            {
                Serie[Contador-1] = Serie[Contador-2] + Serie[Contador-3];
                Contador++;
            }
            return Serie;

        }
    }
}