using System;
using System.Collections.Generic;

namespace Practica
{
    class Practica1
    {
        static void Main(string[] args)
        {
            
            int[,] DosBloques = new int[2,10];
            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("Ingresa el valor " + (i+1) + " en la posicion:" + j +":");
                    DosBloques[i,j] = int.Parse(Console.ReadLine());
                }
            }

            int contador = 0, mayor1 = DosBloques[0,0], mayor2 = DosBloques[1, 0];
            foreach (var item in DosBloques)
            {
                if(contador == 10)
                {
                    Console.WriteLine("--------------------------------------------------------");
                }else if(contador < 10)
                {
                    if(mayor1<item)
                        mayor1 = item;
                }else if (contador >= 10)
                {
                    if (mayor2 < item)
                        mayor2 = item;
                }
                contador++;
            }
            Console.WriteLine($"El numero mayor del primer bloque es:{mayor1}\n" +
                $"El numero mayor del segundo bloque es:{mayor2}");



        }
    }
}
