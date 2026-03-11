using System;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
    }


    // Función para mostrar el menú principal
    static void ShowMainMenu()
    {
        Boolean next = true;
        while (next)
        {
            
            Console.Clear();

            Console.WriteLine("-- BiblioTech --");
            Console.WriteLine("1.Libros");
            Console.WriteLine("2.Usuarios");
            Console.WriteLine("3.Prestamos");
            Console.WriteLine("4.Búsquedas y Reportes");
            Console.WriteLine("5.Guardar/Cargar Datos");
            Console.WriteLine("6.Salir");

            Console.Write("Seleccione una opción: ");
            string option = Console.ReadLine();


            switch (option)
            {
                case "1":
                    ShowBooksMenu();
                    break;
                case "2":
                    ShowUsersMenu();
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

    // Función para mostrar el menú de libros
    static void ShowBooksMenu()
    {   Boolean stayinbooksMenu = true;
         while (stayinbooksMenu){

        Console.Clear();
             
        Console.WriteLine("-- Función de Libros --");
        Console.WriteLine("1.Agregar Libro");
        Console.WriteLine("2.Listar Libro");
        Console.WriteLine("3.Ver detalles de un Libro");
        Console.WriteLine("4.Actualizar Libro");
        Console.WriteLine("5.Eliminar Libro");
        Console.WriteLine("6.Regresar al menú principal");

        Console.Write("Seleccione una opción: ");
        string option = Console.ReadLine();


        switch (option)
        {
            case "1":
                Console.Clear();
                Console.WriteLine("--- Registrar Nuevo Libro ---");
                Console.Write("Título: ");
                string t = Console.ReadLine();
                Console.Write("Autor: ");
                string a = Console.ReadLine();
                Console.WriteLine($"\nEl libro '{t}' de {a} ha sido guardado en el sistema.");
                Console.WriteLine("Presione una tecla para volver...");
                Console.ReadKey();
                break;
            case "2":
                showlistenbooks();
                break;
            case "3":
                Console.WriteLine("-- Función de Ver detalles de un Libro --");
                Console.WriteLine("IDs disponibles: 101, 202, 303, 404, 505");
                Console.WriteLine("Ingrese el ID del libro para ver detalles:");
                int ID = int.Parse(Console.ReadLine());
                if (ID == 101)
                {
                    Console.WriteLine("Detalles del libro 101: 'Cien Años de Soledad' de Gabriel García Márquez (Disponible)");
                }
                else if (ID == 202)
                {
                    Console.WriteLine("Detalles del libro 202: '1984' de George Orwell (Prestado)");
                }
                else if (ID == 303)
                {
                    Console.WriteLine("Detalles del libro 303: 'To Kill a Mockingbird' de Harper Lee (Disponible)");
                }
                else if (ID == 404)
                {
                    Console.WriteLine("Detalles del libro 404: 'The Great Gatsby' de F. Scott Fitzgerald (Disponible)");
                }
                else if (ID == 505)
                {
                    Console.WriteLine("Detalles del libro 505: 'Harry Potter' de J.K. Rowling (Disponible)");
                }
                else
                {
                    Console.WriteLine("ID no encontrado. Presione una tecla para volver...");
                }
                Console.ReadKey();
                break;
            case "4":
                ShowUpdateBookMenu();
                break;
            case "5":
                Console.WriteLine("-- Función de Eliminar Libro --");
                Console.WriteLine("Validar no permitir si está prestado");
                Console.ReadKey();
                break;
            case "6":
                stayinbooksMenu = false;
                break;
            default:
                Console.WriteLine("Opción no válida. Presione Enter para intentar de nuevo.");
                Console.ReadLine();
                break;
        }
    
        }

    }

        // Función para mostrar el menú de listar libros
    static void showlistenbooks()
    {   Boolean stayinlistbooksMenu = true;
         while (stayinlistbooksMenu){

        Console.Clear();

        Console.WriteLine("-- Función de Listar Libro --");
        Console.WriteLine("1.Listar todos los libros");
        Console.WriteLine("2.Listar Disponibles");
        Console.WriteLine("3.Listar Prestados");
        Console.WriteLine("4.Regresar al menú de Libros");


        Console.Write("Seleccione una opción: ");
        string option = Console.ReadLine();


        switch (option)
        {   case "1":
                Console.WriteLine("-- Listar todos los libros --");
                Console.WriteLine("Libro 101: 'Cien Años de Soledad' de Gabriel García Márquez (Disponible)");
                Console.WriteLine("Libro 202: '1984' de George Orwell (Prestado)");
                Console.WriteLine("Libro 303: 'To Kill a Mockingbird' de Harper Lee (Disponible)");
                Console.WriteLine("Libro 404: 'The Great Gatsby' de F. Scott Fitzgerald (Disponible)");
                Console.WriteLine("Libro 505: 'Harry Potter' de J.K. Rowling (Disponible)");
                Console.ReadKey();
                break;
            case "2":
                Console.WriteLine("-- Listar Disponibles --");
                Console.WriteLine("Libro 101: 'Cien Años de Soledad' de Gabriel García Márquez (Disponible)");
                Console.WriteLine("Libro 303: 'To Kill a Mockingbird' de Harper Lee (Disponible)");
                Console.WriteLine("Libro 404: 'The Great Gatsby' de F. Scott Fitzgerald (Disponible)");
                Console.WriteLine("Libro 505: 'Harry Potter' de J.K. Rowling (Disponible)");
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("-- Listar Prestados --");
                Console.WriteLine("Libro 202: '1984' de George Orwell (Prestado)");
                Console.ReadKey();
                break;
            case "4":
                stayinlistbooksMenu = false;
                break;
            default:
                Console.WriteLine("Opción no válida. Presione Enter para intentar de nuevo.");
                Console.ReadLine();
                break;
         }
        }
    }

    // Función para mostrar el menú de actualizar libros
            static void ShowUpdateBookMenu(){
            bool stayInUpdateMenu = true;
            while (stayInUpdateMenu)
                {
            Console.Clear();
            Console.WriteLine("--- Actualizar Libro ---");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año / categoría");
            Console.WriteLine("4. Regresar al menú de Libros");

            Console.Write("\nSeleccione qué desea editar: ");
            string option = Console.ReadLine();

            switch (option){
            case "1":
                Console.WriteLine("\nIngrese el nuevo título:");
                Console.ReadLine(); 
                Console.WriteLine("Título actualizado con éxito.");
                Console.ReadKey();
                break;
            case "2":
                Console.WriteLine("\nIngrese el nuevo autor:");
                Console.ReadLine();
                Console.WriteLine("Autor actualizado con éxito.");
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("\nIngrese el nuevo año o categoría:");
                Console.ReadLine();
                Console.WriteLine("Datos actualizados con éxito.");
                Console.ReadKey();
                break;
            case "4":
                stayInUpdateMenu = false;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                Console.ReadKey();
                break;
        }
    }
  }

            static void ShowUsersMenu()
            {   Boolean stayinUsersMenu = true;
                while (stayinUsersMenu) {
                Console.Clear();
                Console.WriteLine("-- Funcion de Usuarios --");
                Console.WriteLine("1.Registrar Usuario");
                Console.WriteLine("2.Listar Usuarios");
                Console.WriteLine("3.Ver detalles por ID/Documento");
                Console.WriteLine("4.Actualizar Usuario");
                Console.WriteLine("5.Eliminar Usuario");
                Console.WriteLine("6.Regresar al menú principal");

                Console.Write("Seleccione una opción: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("-- Registrar Usuario --");
                           Console.WriteLine("Ingrese el nombre del usuario:");
                            string N = (Console.ReadLine());
                            Console.WriteLine("Ingrese el documento del usuario:");
                            string D = (Console.ReadLine());
                            Console.WriteLine($"El usuario '{N}' con documento '{D}' ha sido registrado en el sistema.");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.WriteLine("-- Listar Usuarios --");
                        Console.WriteLine("Usuario 1: Juan Pérez (Documento: 1234)");
                        Console.WriteLine("Usuario 2: María García (Documento: 4321)");
                        Console.WriteLine("Usuario 3: Carlos López (Documento: 5678)");
                        Console.WriteLine("Usuario 4: Ana Martínez (Documento: 8765)");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.WriteLine("-- Ver detalles por ID/Documento --");
                        Console.WriteLine("IDs Disponibles: 1234, 4321, 5678, 8765");
                        Console.WriteLine("Ingrese el ID correspondiente:");
                        string ID = Console.ReadLine();
                        if (ID == "1234")
                        {
                            Console.WriteLine("Detalles del usuario 1234: Juan Pérez (Documento: 1234)");
                        }
                        else if (ID == "4321")
                        {
                            Console.WriteLine("Detalles del usuario 4321: María García (Documento: 4321)");
                        }
                        else if (ID == "5678")
                        {
                            Console.WriteLine("Detalles del usuario 5678: Carlos López (Documento: 5678)");
                        }
                        else if (ID == "8765")
                        {
                            Console.WriteLine("Detalles del usuario 8765: Ana Martínez (Documento: 8765)");
                        }
                        else
                        {
                            Console.WriteLine("ID no encontrado. Presione una tecla para volver...");
                        }

                        Console.ReadKey();
                        break;
                    case "4":
                        ShowUpdateUserMenu();
                        break;
                    case "5":
                        Console.WriteLine("-- Eliminar Usuario --");
                        Console.WriteLine("Validar no permitir si tiene préstamos activos");
                        Console.ReadKey();
                        break;
                    case "6":
                        stayinUsersMenu = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Presione Enter para intentar de nuevo.");
                        Console.ReadLine();
                        break;
                }
                }

               
            }
         static void ShowUpdateUserMenu(){
            bool stayInUpdateMenu = true;
            while (stayInUpdateMenu)
                {
            Console.Clear();
            Console.WriteLine("--- Actualizar Usuario ---");
            Console.WriteLine("1. Editar Nombre");
            Console.WriteLine("2. Editar Contacto");
            Console.WriteLine("3. Activar o Desactivar");
            Console.WriteLine("4. Regresar al menú de Usuarios");

            Console.Write("\nSeleccione qué desea editar: ");
            string option = Console.ReadLine();

            switch (option){
            case "1":
                Console.WriteLine("\nIngrese el nuevo nombre:");
                Console.ReadLine(); 
                Console.WriteLine("Nombre actualizado con éxito.");
                Console.ReadKey();
                break;
            case "2":
                Console.WriteLine("\nIngrese el nuevo contacto:");
                Console.ReadLine();
                Console.WriteLine("Contacto actualizado con éxito.");
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("\nIngrese el nuevo estado (activo/inactivo):");
                Console.ReadLine();
                Console.WriteLine("Estado actualizado con éxito.");
                Console.ReadKey();
                break;
            case "4":
                stayInUpdateMenu = false;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                Console.ReadKey();
                break;
        }
    }
  }    
}