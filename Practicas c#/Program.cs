using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Practica
{
    class Practica1
    {
        static void Main(string[] args)  
        {
            Console.WriteLine(Num(5));
        }
        public static string Num(int n)
        {
            int Contador = 1;
            double Dividendo = 4;
            double A = 1;
            while (n > Contador)
            {
                A += (1 / Dividendo);
                Dividendo += 3;
                Contador++;
            }
            return A.ToString("F2");
        }
    }
        
}
