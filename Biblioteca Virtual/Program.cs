using System;
using System.Reflection.Emit;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace Biblioteca
{
    class Programa
    {
        static void Main(string[] args)
        {
            Login Loguear = new Login();
            Usuario user = Loguear.PedirUser();
            if (user != null && user.Correo != "")
            {
                if (user.Correo == "admin" && user.Contrasena == "1234")
                {
                    Console.WriteLine("Bienvenido Administrador");
                    Console.ReadKey();
                    OpcionesAdminUser.OpcionesAdmin();
                }
                else
                {
                    Console.WriteLine("Bienvenido " + user.Nombre);
                    OpcionesAdminUser.OpcionesUser(user);
                }
            }
        }
    }
    class OpcionesAdminUser
    {
        static string MenuAdministrador()
        {
            string texto = "Administrador del Sistema de Gestión de Biblioteca Virtual";
            int anchoVentana = Console.WindowWidth;
            int longitudTexto = texto.Length;
            int padding = (anchoVentana - longitudTexto) / 2;
            Console.Clear();


            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(texto.PadLeft(longitudTexto + padding));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Agregar un Libro");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("2. Eliminar un Libro");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3. Buscar un Libro");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("4. Listar Libros");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("5. Agregar Libros desde un archivo Json");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("6. Salir");


            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Seleccione una opción: ");
            Console.ResetColor();

            string opcion = Console.ReadLine();
            return opcion;
        }

        static string MenuUser()
        {
            string Texto = "Bienvenido a la Biblioteca Virtual";
            int AltoVentana = Console.WindowWidth;
            int LongitudTexto = Texto.Length;
            int padding = (AltoVentana - LongitudTexto) / 2;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Texto.PadLeft(LongitudTexto + padding));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Ver Todos los libros");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("2. Prestar un libro");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3. Buscar un libro");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("4. Salir");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Seleccione una opción: ");
            Console.ResetColor();
            return Console.ReadLine();
        }

        public static void OpcionesAdmin()
        {
            Biblioteca biblioteca = new Biblioteca();
            bool esperar = true;

            while (esperar)
            {
                string opcion = MenuAdministrador();
                if (opcion == "1")
                {
                    Console.Clear();
                    Console.Write("Ingrese el título del libro: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese el autor del libro: ");
                    string autor = Console.ReadLine();
                    Console.Write("Ingrese el ISBN del libro: ");
                    string isbn = Console.ReadLine();
                    Console.Write("¿El libro está disponible? (true/false): ");
                    bool disponibilidad = bool.Parse(Console.ReadLine());
                    Console.WriteLine(biblioteca.AgregarLibro(new Libro(titulo, autor, isbn, disponibilidad)));
                    Console.ReadKey();
                }
                else if (opcion == "2")
                {
                    Console.Clear();
                    Console.Write("Ingresa el ISBN del libro a eliminar:");
                    string ISBN = Console.ReadLine();
                    Console.WriteLine(biblioteca.EliminarLibro(ISBN));
                    Console.ReadKey();
                }
                else if (opcion == "3")
                {
                    Console.Clear();
                    Console.Write("Ingresa el ISBN del libro a Buscar:");
                    string ISBN = Console.ReadLine();
                    Libro libro = biblioteca.BuscarLibro(ISBN);
                    if (libro != null)
                        Console.WriteLine(libro.GetLibro());
                    else
                        Console.WriteLine("Libro no encontrado");
                    Console.ReadKey();
                }
                else if (opcion == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Lista de libros:");
                    biblioteca.ListarLibros();
                    Console.ReadKey();
                }
                else if (opcion == "5")
                {
                    Console.Clear();
                    Console.Write("Ingrese la ruta del archivo JSON: ");
                    string rutaArchivo = Console.ReadLine();
                    Console.WriteLine(biblioteca.AgregarLibrosDesdeArchivo(rutaArchivo));
                    Console.ReadKey();
                }

                else if (opcion == "6")
                {
                    Console.Clear();
                    esperar = false;
                    Console.WriteLine("Hasta Pronto Administrador");
                    Console.ReadKey();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opcion invalida");
                    Console.ReadKey();
                }
            }
        }
        public static void OpcionesUser(Usuario user)
        {
            Biblioteca biblioteca = new Biblioteca();
            bool esperar = true;

            while (esperar)
            {
                string opcion = MenuUser();

                if (opcion == "1")
                {
                    Console.Clear();
                    Console.WriteLine("Libros De La Biblioteca Virtual");
                    biblioteca.ListarLibros();
                    Console.ReadKey();
                }
                else if (opcion == "2")
                {
                    Console.Clear();
                    Console.Write("Ingresa el ISBN del libro:");
                    string ISBN = Console.ReadLine();
                    Libro libro = biblioteca.BuscarLibro(ISBN);
                    if (libro != null)
                    {
                        if (libro.Disponibilidad)
                        {
                            Console.WriteLine($"Gracias por usar la Biblioteca Virtual. Has prestado el libro: \n{libro.GetLibro()}\nSe enviará un correo de confirmación a: {user.Correo}");
                            libro.Disponibilidad = false;
                            Correo.Prestamos(user);
                            biblioteca.GuardarLibros();
                        }
                        else
                        {
                            Console.WriteLine("Lo sentimos, el libro ya está prestado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Libro no encontrado.");
                    }
                    Console.ReadKey();
                }
                else if (opcion == "3")
                {
                    Console.Clear();
                    Console.Write("Ingresa el ISBN del libro a Buscar:");
                    string ISBN = Console.ReadLine();
                    Libro libro = biblioteca.BuscarLibro(ISBN);
                    if (libro != null)
                        Console.WriteLine(libro.GetLibro());
                    else
                        Console.WriteLine("Libro no encontrado");
                    Console.ReadKey();
                }
                else if (opcion == "4")
                {
                    Console.Clear();
                    esperar = false;
                    Console.WriteLine($"Hasta Pronto {user.Nombre}");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Opcion invalida");
                    Console.ReadKey();
                }
                biblioteca.GuardarLibros();
            }
        }

    }
    class Usuario
    {
        public string Nombre { get; }
        public string Apellido { get; }
        public string Correo { get; }
        public string Contrasena { get; }

        public Usuario(string Nombre, string Apellido, string Correo, string Contra)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Correo = Correo;
            this.Contrasena = Contra;
        }
    }
    class Login
    {
        string filePath = "archivo.txt";
        StreamWriter archivo;
        string opc;
        string cor = "", contr = "", cor2 = "", contr2 = "";
        bool ver = true;
        string nomb = "", apell = "";
        public void Menu()
        {
            string Texto = "Bienvenido a la Biblioteca Virtual El s";
            int AltoVentana = Console.WindowWidth;
            int LongitudTexto = Texto.Length;
            int padding = (AltoVentana - LongitudTexto) / 2;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(Texto.PadLeft(LongitudTexto + padding));
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Elige una opción");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("#1: Iniciar Sesion ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("#2: Registrarse");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("#3: Salir");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Ingresa tu opcion:");
            Console.ResetColor();
            opc = Console.ReadLine();
        }
        public Usuario PedirUser()
        {
            while (ver)
            {
                Menu();
                switch (opc)
                {
                    case "1":
                        Console.Write("Ingrese su Correo:");
                        cor = Console.ReadLine();
                        Console.Write("Ingrese su Contraseña:");
                        contr = Console.ReadLine();

                        if (VerificarUsuario(filePath, cor, contr, out nomb, out apell))
                        {
                            Console.Clear();
                            return new Usuario(nomb, apell, cor, contr);
                        }
                        else
                        {
                            Console.WriteLine("Usuario no registrado o contraseña incorrecta");
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Ingrese su Nombre:");
                        nomb = Console.ReadLine();
                        Console.Write("Ingrese su Apellido:");
                        apell = Console.ReadLine();
                        Console.Write("Ingrese su Correo:");
                        cor2 = Console.ReadLine();
                        Console.Write("Ingrese su Contraseña:");
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
                        return null;
                    default:
                        Console.WriteLine("Opción inválida, intente de nuevo.");
                        Console.ReadLine();
                        break;
                }
            }
            return null;

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
        static bool VerificarUsuario(string filePath, string correo, string contrasena, out string nombre, out string apell)
        {
            nombre = "";
            apell = "";
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
                            apell = datos[3];
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
    class Libro
    {
        private string _Titulo;
        private string _Autor;
        private string _Isbn;
        private bool _Disponibilidad;

        public string Titulo
        {
            get
            {
                return _Titulo;
            }
        }
        public string Autor
        {
            get
            {
                return _Autor;
            }
        }
        public string Isbn
        {
            get
            {
                return _Isbn;
            }
        }
        public bool Disponibilidad
        {
            get
            {
                return _Disponibilidad;
            }
            set
            {
                _Disponibilidad = value;
            }
        }
        public Libro(string Titulo, string Autor, string Isbn, bool Disponibilidad)
        {
            this._Titulo = Titulo;
            this._Autor = Autor;
            this._Isbn = Isbn;
            this._Disponibilidad = Disponibilidad;
        }
        public string GetLibro()
        {
            return $"Titulo = {_Titulo}\nAutor = {_Autor}\nISBN = {_Isbn}\nDisponibilidad = {_Disponibilidad}\n";
        }
    }
    class Biblioteca
    {
        private string RutaOrigen = "C:\\Users\\Premi\\OneDrive\\Escritorio\\Origen.json";
        private List<Libro> libros;

        public Biblioteca()
        {
            var json = File.ReadAllText(RutaOrigen);
            libros = JsonConvert.DeserializeObject<List<Libro>>(json) ?? new List<Libro>();
        }
        public Libro BuscarLibro(string ISBN)
        {
            foreach (Libro libro in libros)
            {
                if (libro.Isbn == ISBN)
                {
                    return libro;
                }
            }
            return null;
        }
        public string AgregarLibro(Libro Libro)
        {
            try
            {
                if (Libro == null)
                    return "Libro inválido";
                libros.Add(Libro);  // Agrega el producto a la lista
                GuardarLibros();

                if (BuscarLibro(Libro.Isbn) != null)
                    return $"El Libro ha sido agregado con éxito";
                else
                    return $"Error al agregar el producto";

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "Ocurrió un error al escribir en el archivo:";

            }
        }
        public string EliminarLibro(string Isbn)
        {
            Libro Libro = BuscarLibro(Isbn);
            if (Libro != null)
            {
                libros.Remove(Libro);
                GuardarLibros();
                return $"El Libro ha sido eliminado con éxito";
            }
            else
                return $"Error al eliminar el libro o el libro no existe en la Biblioteca";
        }
        public void ListarLibros()
        {
            foreach (Libro Libros in libros)
            {
                Console.WriteLine(Libros.GetLibro()); 
            }
        }
        public string AgregarLibrosDesdeArchivo(string rutaArchivo)
        {
            try
            {
                var jsonNuevo = File.ReadAllText(rutaArchivo);
                var nuevosLibros = JsonConvert.DeserializeObject<List<Libro>>(jsonNuevo);

                if (nuevosLibros != null)
                {
                    foreach (Libro libro in nuevosLibros)
                    {
                        if (BuscarLibro(libro.Isbn) == null)
                        {
                            libros.Add(libro);
                        }
                    }
                    GuardarLibros();
                    return "Libros agregados con éxito";
                }
                else
                {
                    return "El archivo JSON no contiene libros válidos";
                }
            }
            catch (Exception e)
            {
                return $"Ocurrió un error al procesar el archivo: {e.Message}";
            }
        }
        public void GuardarLibros()
        {
            string actualizarJson = JsonConvert.SerializeObject(libros, Formatting.Indented);
            File.WriteAllText(RutaOrigen, actualizarJson);
        }
    }
    class Correo
    {
        public static void Prestamos(Usuario user)
        {
            DateTime date = DateTime.Now;
            string Fecha = date.ToLongDateString();

            MailAddress MiCorreo = new MailAddress("bibliotecavirtual978@gmail.com", "Biblioteca Virtual");
            const string MiContra = "grrctxhpwzbvfwvq";
            MailAddress CorreoDelPrestador = new MailAddress(user.Correo, user.Nombre);
            const string subject = "Prestamo De libro";
            string body = $"Gracias por usar la Biblioteca Virtual, prestamo del libro exitoso\n Fecha de adquisicion:{Fecha}";
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(MiCorreo.Address, MiContra)
            };
            using (var message = new MailMessage(MiCorreo, CorreoDelPrestador)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}