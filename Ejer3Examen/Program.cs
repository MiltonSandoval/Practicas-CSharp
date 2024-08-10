using System;

namespace Ejercicio3
{
    class Programa
    {
        static void Main(string[] args)
        {
            int[,] Matris3x2 = new int[3, 2];
            int Mayor;

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Ingresa el numero de la posicion {i},{0}:");
                Matris3x2[i, 0] = int.Parse(Console.ReadLine());
                Console.Write($"Ingresa el numero de la posicion {i},{1}:");
                Matris3x2[i, 1] = int.Parse(Console.ReadLine()); ;
            }

            Mayor = Matris3x2[0, 0];
            foreach (int Numero in Matris3x2)
            {
                if (Numero > Mayor)
                {
                    Mayor = Numero;
                }
            }
            Console.WriteLine($"El numero mayor de todos los numeros ingresados es: {Mayor}");
            Console.ReadKey();
        }

    }
}
