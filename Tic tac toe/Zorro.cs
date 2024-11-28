using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe
{
    class ZorroTic
    {
        public static List<int> Zorro = new List<int> { -1, -1, -1,
                                                        -1, -1, -1, 
                                                        -1, -1, -1 };
        public string jugador1, jugador2;
        public ZorroTic(string jugador1, string jugador2)
        {
            this.jugador1 = jugador1;
            this.jugador2 = jugador2;

        }

        public void ImprimirCuadro()
        {

            Console.WriteLine($"            {(Zorro[0] != -1 ? Zorro[0].ToString() : " ")}|{(Zorro[1] != -1 ? Zorro[1].ToString() : " ")}|{(Zorro[2] != -1 ? Zorro[2].ToString() : " ")}");
            Console.WriteLine("            -----");
            Console.WriteLine($"            {(Zorro[3] != -1 ? Zorro[3].ToString() : " ")}|{(Zorro[4] != -1 ? Zorro[4].ToString() : " ")}|{(Zorro[5] != -1 ? Zorro[5].ToString() : " ")}");
            Console.WriteLine("            -----");
            Console.WriteLine($"            {(Zorro[6] != -1 ? Zorro[6].ToString() : " ")}|{(Zorro[7] != -1 ? Zorro[7].ToString() : " ")}|{(Zorro[8] != -1 ? Zorro[8].ToString() : " ")}");
        }
        //static int VerificarGanador()
        //{
        //    if (Zorro[0] == 1 -)
        //    {
        //        return 0;
        //    }
        //    return 1;
        //}


    }
}
