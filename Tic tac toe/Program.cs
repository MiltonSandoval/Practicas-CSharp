using System.Collections.Generic;
using Tic_tac_toe;

namespace Tic
{
    class Program
    {
        static void Main(string[] args)
        {
            var Jugadores = PedirNombres();
            ZorroTic Zorro = new ZorroTic(Jugadores[0], Jugadores[1]);
            Console.WriteLine("Tic Tac Toe");
            while (true)
            {
                Zorro.ImprimirCuadro();
                ImprimirIntrucciones();
                Console.Write("Ingrese su opcion:");
                string op = Console.ReadLine();
                int opcion;
                if (int.TryParse(op, out opcion)) ;
                else
                    opcion = -1;
            }
        }

        static void ImprimirIntrucciones()
        {
            Console.WriteLine("Ingresa la posicion que quieres jugar donde 1 es la primer casilla izquierda de arriba y la 9 es la ultima casilla derecha de abajo");
        }

        //static void InsertarPosicion(int posicion)
        //{
        //    if (posicion > 0 && posicion < 10)
        //    {
        //        if (list posicion - 1)
        //        return 1;
                        
        //    }
        //}

        static string[] PedirNombres()
        {
            Console.Write("Ingresa tu nombre Jugador 1:");
            string Jugador1 = Console.ReadLine();
            Console.WriteLine("Ingresa tu Nombre Jugador 2:");
            string Jugador2 = Console.ReadLine();
            return new string[] { Jugador1, Jugador2};

        }
    }
}
