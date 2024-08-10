using System;

namespace Matris
{
    class Programa
    {
        static void Main(string[] args)
        {
            double[,] Matris = new double[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"Ingresa el numero para la posicion {i},{j}:");
                    Matris[i, j] = double.Parse(Console.ReadLine()); 
                }
            }

            double Fila1 = 1;
            double Fila2 = 1;
            int Ayuda1 = 0, Ayuda2 = 1;
            for (int i = 0; i < 2; i++)
            {
                Fila1 = (double)Fila1 * Matris[i, i];
                Fila2 = (double)Fila2 * Matris[Ayuda2, Ayuda1];
                int tem = Ayuda1;
                Ayuda1 = Ayuda2;
                Ayuda2 = tem;
            }

            Console.WriteLine($"La Determinante de la matriz es:{(double)Fila1-(Fila2)}");

        }
    }
}