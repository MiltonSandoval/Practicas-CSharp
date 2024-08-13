
using System;
using CerveceriaDB;

namespace Cerveceria
{
    class Programa
    {
        static void Main(string[] args)
        {
            CervesasDB cervesasDB = new CervesasDB("LAPTOP-3MN70QT8", "CursoCsharp", "Milton", "123456");
            while (true)
            {
                Console.WriteLine("Opcion:");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.Write("dame el nombre de la cervesa:");
                    string name = Console.ReadLine();
                    Console.Write("dame el id de la marca:");
                    int marcaid = int.Parse(Console.ReadLine());
                    cervesasDB.AddBeer(new Cervesas(name, marcaid));

                }
                else if (opcion == "2")
                {
                    List<Cervesas> Beers =  cervesasDB.ListBeer();

                    foreach (var Beer in Beers)
                    {
                        Console.WriteLine($"Id: {Beer.Id}\nNombre:{Beer.Name}\n" +
                            $"Marca id:{Beer.MarcaId}\n");
                    }

                }
                else
                {
                    break;
                }
            }

        }
    }
}