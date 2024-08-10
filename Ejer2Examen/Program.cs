using System;

namespace Ejercicio2
{
    class Programa
    {
        static void Main(string[] args)
        {
            int[,] Matris4x3 = new int[4, 3];
            int[] MatrisDimensional = new int[9];

            //For para recibir solo los 9 numeros, nada mas
            int contador = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Ingresa el numero {contador}:");
                    Matris4x3[i, j] = int.Parse(Console.ReadLine());
                    contador++;
                }
            }
            //For que imprime en consola el array ingresado
            Console.WriteLine("El array desordenado es:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    Console.Write(Matris4x3[i, j].ToString() + " ");
                }
            }

            //For que sirve para pasar los numeros de la matris 4x3 a una matris dimensional
            //de solo 9 valores tal cual como dice en el examen
            contador = 0;
            for (int i = 0; i < 3; i++)
            {

                for (int j = 0; j < 3; j++)
                {

                    MatrisDimensional[contador] = Matris4x3[i, j];
                    contador++;
                }
            }
            //se ordena la matris de una dimension
            MatrisDimensional = Ordenamiento(MatrisDimensional);
            // se hace el cambio de la matris de una dimension a la otra de dos dimension para 
            //imprimir los valores, esto realmente no es necesario pero para evitar problemas mejor hice el cambio a la matris 4x3
            contador = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Matris4x3[i, j] = MatrisDimensional[contador];
                    contador++;
                }
            }
            //se imprimen los valores de la matris 4x3 sin contar los 0 que se colocan automaticamente
            Console.WriteLine("\nEl array ordenado de forma ascendente es:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    Console.Write(Matris4x3[i, j].ToString()+" ");
                }

            }
            //funcion para ordenar la matris dimensional
            static int[] Ordenamiento(int[] Vector)
            {
                int Menor, Temporal;
                for (int i = 0; i < Vector.Length; i++)
                {
                    Menor = i;
                    for (int j = i; j < Vector.Length; j++)
                    {
                        if (Vector[j] < Vector[Menor])
                        {
                            Menor = j;
                        }
                    }
                    Temporal = Vector[i];
                    Vector[i] = Vector[Menor];
                    Vector[Menor] = Temporal;
                }
                return Vector;
            }
        }
    }
}