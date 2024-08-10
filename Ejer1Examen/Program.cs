using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "archivo.txt";
        StreamWriter archivo;
        string opc;
        string cor = "", contr = "", cor2 = "", contr2 = "";
        bool ver = true;
        string nomb = "", apell = "";

        while (ver)
        {
            Console.Clear();
            Console.WriteLine("Bienvenido a Renta de Libros");
            Console.WriteLine("Elige una opción");
            Console.WriteLine("#1: Iniciar Sesion ");
            Console.WriteLine("#2: Registrarse");
            Console.WriteLine("#3: Salir");
            opc = Console.ReadLine();

            switch (opc)
            {
                case "1":
                    Console.WriteLine("Ingrese su Correo");
                    cor = Console.ReadLine();
                    Console.WriteLine("Ingrese su Contraseña");
                    contr = Console.ReadLine();

                    if (VerificarUsuario(filePath, cor, contr, out nomb))
                    {
                        Console.WriteLine("Bienvenido " + nomb);
                    }
                    else
                    {
                        Console.WriteLine("Usuario no registrado o contraseña incorrecta");
                    }
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Ingrese su Nombre");
                    nomb = Console.ReadLine();
                    Console.WriteLine("Ingrese su Apellido");
                    apell = Console.ReadLine();
                    Console.WriteLine("Ingrese su Correo");
                    cor2 = Console.ReadLine();
                    Console.WriteLine("Ingrese su Contraseña");
                    contr2 = Console.ReadLine();

                    if (VerificarCorreoExistente(filePath, cor2))
                    {
                        Console.WriteLine("El correo ya esta registrado");
                    }
                    else
                    {
                        using (archivo = new StreamWriter(filePath, true))
                        {
                            archivo.WriteLine($"{cor2},{contr2},{nomb},{apell}");
                        }
                        Console.WriteLine("Registro Exitoso");
                    }
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Saliendo del programa");
                    ver = false;
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static bool VerificarCorreoExistente(string filePath, string correo)
    {
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] datos = line.Split(',');
                    if (datos[0] == correo)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    static bool VerificarUsuario(string filePath, string correo, string contrasena, out string nombre)
    {
        nombre = "";
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] datos = line.Split(',');
                    if (datos[0] == correo && datos[1] == contrasena)
                    {
                        nombre = datos[2];
                        return true;
                    }
                }
            }
        }
        return false;
    }
}