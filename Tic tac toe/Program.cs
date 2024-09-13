namespace Tic
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            Console.WriteLine("Tic Tac Toe");
            ImprimirCuadro(list);
            Console.WriteLine("Ingresa la posicion que quieres jugar donde 1 es la primer casilla izquierda de arriba y la 9 es la ultima casilla derecha de abajo");
            Console.Write("Ingrese su opcion:");
            string op = Console.ReadLine();
            int opcion;

            if (int.TryParse(op, out opcion)) ;
            else
                opcion = -1;


            Console.WriteLine(opcion);
        }

        static void ImprimirCuadro(List<int> Zorro)
        {

            Console.WriteLine($"            {(Zorro[0] != -1 ? Zorro[0].ToString() : " ")}|{(Zorro[1] != -1 ? Zorro[1].ToString() : " ")}|{(Zorro[2] != -1 ? Zorro[2].ToString() : " ")}");
            Console.WriteLine("            -----");
            Console.WriteLine($"            {(Zorro[3] != -1 ? Zorro[3].ToString() : " ")}|{(Zorro[4] != -1 ? Zorro[4].ToString() : " ")}|{(Zorro[5] != -1 ? Zorro[5].ToString() : " ")}");
            Console.WriteLine("            -----");
            Console.WriteLine($"            {(Zorro[6] != -1 ? Zorro[6].ToString() : " ")}|{(Zorro[7] != -1 ? Zorro[7].ToString() : " ")}|{(Zorro[8] != -1 ? Zorro[8].ToString() : " ")}");
        }
    }
}
