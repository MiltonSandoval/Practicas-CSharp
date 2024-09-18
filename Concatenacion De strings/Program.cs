using System;
using System.Linq;


namespace Practica
{
    class Program
    {
        static void Main()
        {
            var a = LongestConsec(new string[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" }, 1);
            foreach (var b in a)
            {
                Console.WriteLine(b);   
            }
        }
        public static string LongestConsec(string[] strarr, int k)
        {
            if(!(strarr.Length == 0 || k >strarr.Length || k<= 0))
            {
                string[] Guardador = new string[strarr.Length];
                for (int i = 0; i < strarr.Length - k ; i++)
                {
                    for (int j = 0; j < k; j++)
                        Guardador[i] += strarr[j + i];
                }

                return k != 1?  Guardador.Where(s2 => s2 != null).OrderByDescending(s1 => s1.Length).FirstOrDefault() : strarr.Where(s2 => s2 != null).OrderByDescending(s1 => s1.Length).FirstOrDefault();
            }
            return "";
        }
    }

}
