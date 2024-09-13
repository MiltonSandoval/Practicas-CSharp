class Program
{
    static void Main(string[] args)
    {
        var Juego = new string[] { "Piedra", "Papel", "Tijera" };

        Random random = new Random((int.Parse(DateTime.Now.Millisecond.ToString())));

        while (true)
        {
            int Maquina = random.Next(0, 3);
            string opcion = Preguntar();
            int jugador = int.Parse(opcion) - 1; 

            if (jugador == Maquina)
            {
                Console.WriteLine($"{Juego[jugador]} vs {Juego[Maquina]}");
                Console.WriteLine("Empate");
            }
            else if ((jugador == 0 && Maquina == 2) || (jugador == 1 && Maquina == 0) || (jugador == 2 && Maquina == 1))
            {
                Console.WriteLine($"{Juego[jugador]} vs {Juego[Maquina]}");
                Console.WriteLine("Ganaste");
            }
            else if ((Maquina == 0 && jugador == 2) || (Maquina == 1 && jugador == 0) || (Maquina == 2 && jugador == 1))
            {
                Console.WriteLine($"{Juego[jugador]} vs {Juego[Maquina]}");
                Console.WriteLine("Perdiste");
            }
            else
            {
                Console.WriteLine("Error, ingresa una opción válida");
            }
        }
    }

    static string Preguntar()
    {
        Console.WriteLine("Piedra (1), Papel (2), Tijera (3)");
        Console.Write("Ingrese su opción: ");
        return Console.ReadLine();
    }
}
