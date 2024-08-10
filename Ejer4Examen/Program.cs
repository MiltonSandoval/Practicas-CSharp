using System;

namespace Ejercicio4
{
    class Programa
    {
        static void Main(string[] args)
        {
            int[] Numeros = new int[6];
            int[] Descendente;

            for (int i = 0; i < Numeros.Length; i++)
            {
                Console.Write($"Ingresa el numero {i+1}:");
                Numeros[i] = int.Parse(Console.ReadLine());
            }
            
            Console.WriteLine($"El vector desordenado es: {string.Join(",", Numeros)}");

            Descendente = SelectionSort(Numeros);

            Console.WriteLine($"El vector Ordenado de forma descendente es: {string.Join(",", (Descendente))}");
            Console.ReadKey();
        }
        static int[] SelectionSort(int[] Vector)
        {
            int Mayor, Temporal;
            for (int i = 0; i < Vector.Length; i++)
            {
                Mayor = i;
                for (int j = i; j < Vector.Length; j++)
                {
                    if (Vector[j] > Vector[Mayor] )
                    {
                        Mayor = j;
                    }
                }
                Temporal = Vector[i];
                Vector[i] = Vector[Mayor];
                Vector[Mayor] = Temporal;
            }
            return Vector;
        }
    }
}