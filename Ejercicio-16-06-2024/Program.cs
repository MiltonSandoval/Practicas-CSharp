using System;
using System.Runtime.CompilerServices;

namespace Practicas
{
    class Programa
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SpinWords("Hey fellow warriors"));
        }

        public static string SpinWords(string sentencia)
        {
            var a = sentencia.Split(' ');
            string b = "";
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].Count() >= 5)
                    b += new string(a[i].Reverse().ToArray());
                else
                    b += a[i];
                if (i < a.Length - 1)
                    b += " ";
            }
            return b;
        }

    }
}   