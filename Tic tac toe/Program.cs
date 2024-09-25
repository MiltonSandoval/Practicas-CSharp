namespace Tic
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Tic Tac Toe");
            while (true)
            {
                ImprimirCuadro(list);
                ImprimirIntrucciones();
                Console.Write("Ingrese su opcion:");
                string op = Console.ReadLine();
                int opcion;
                if (int.TryParse(op, out opcion));
                else
                    opcion = -1;
            }
        }

        static void ImprimirIntrucciones()
        {
            Console.WriteLine("Ingresa la posicion que quieres jugar donde 1 es la primer casilla izquierda de arriba y la 9 es la ultima casilla derecha de abajo");
        }
        
        static void InsertarPosicion(int posicion)
        {
            if( posicion > 0 && posicion < 10)
            {
                if(list posicion - 1)
            }
        }
    }
}
