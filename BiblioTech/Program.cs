using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
    }

    static void ShowMainMenu()
    {
        Boolean next = true;
        while (next)
        {
            

            Console.WriteLine("BiblioTech");
            Console.WriteLine("1.Libros");
            Console.WriteLine("2.Usuarios");
            Console.WriteLine("3.Prestamos");
            Console.WriteLine("4.Búsquedas y Reportes");
            Console.WriteLine("5.Guardar/Cargar Datos");
            Console.WriteLine("6.Salir");
            Console.Write("Seleccione una opción: ");

            string option = Console.ReadLine();

            Console.Clear();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Funcion de Libros");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.WriteLine("Funcion de Usuarios");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("Funcion de Prestamos");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine("Funcion de Búsquedas y Reportes");
                    Console.ReadKey();
                    break;
                case "5":
                    Console.WriteLine("Funcion de Guardar/Cargar Datos");
                    Console.ReadKey();
                    break;
                case "6":
                    next = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Presione Enter para intentar de nuevo.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}