using System;
using System.Runtime.CompilerServices;

namespace Practicas
{
    class Programa
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Par("Weird string case"));
        }

        public static string Par(string sentencia)
        {
            string Carri = "";
            bool Controlador = true;
            foreach (var item in sentencia)
            {
                if(Controlador)
                {
                    if (item.ToString() == " ")
                    {
                        Carri += item.ToString();
                        Controlador = true;
                    }
                    else
                    {
                        Carri += item.ToString().ToUpper();
                        Controlador = false;
                    }
                   
                }    
                else
                {
                    Carri += item.ToString().ToLower();
                    Controlador = true;
                }

            }
            return Carri;
        }

    }
}