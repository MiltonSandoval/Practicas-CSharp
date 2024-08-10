
using System;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.IO;


namespace Sistema
{
    class Programa
    {
        static void Main(string[] args)
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
                    Console.WriteLine("Hasta Prondo Administrador");
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

        static string MenuAdministrador()
        {
            Console.Clear();
            Console.WriteLine("Administrador del Sistema de Gestión de Biblioteca Virtual\n");
            Console.WriteLine("1. Agregar un Libro");
            Console.WriteLine("2. Eliminar un Libro");
            Console.WriteLine("3. Buscar un Libro");
            Console.WriteLine("4. Listar Libros");
            Console.WriteLine("5. Agregar Libros desde un archivos Json");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            return Console.ReadLine();
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
        private string ActualizarJson;
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
                ActualizarJson = JsonConvert.SerializeObject(libros, Formatting.Indented);
                File.WriteAllText(RutaOrigen, ActualizarJson);

                if (BuscarLibro(Libro.Isbn) != null)
                    return $"El Producto ha sido agregado con éxito";
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
                libros.Remove(Libro);  // Elimina el producto de la lista
                ActualizarJson = JsonConvert.SerializeObject(libros, Formatting.Indented);
                File.WriteAllText(RutaOrigen, ActualizarJson);
                return $"El Producto ha sido eliminado con éxito";
            }
            else
                return $"Error al eliminar el libro o el libro no existe en la Biblioteca";
        }
        public void ListarLibros()
        {
            foreach (Libro Libros in libros)
            {
                Console.WriteLine(Libros.GetLibro());  // Muestra la información de cada producto
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

                    ActualizarJson = JsonConvert.SerializeObject(libros, Formatting.Indented);
                    File.WriteAllText(RutaOrigen, ActualizarJson);

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


    }
}
