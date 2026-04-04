using BiblioTech.Models;
using BiblioTech.Services;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks.Dataflow;

class Program
{

    static LibroService libroService = new LibroService();
    static UsuarioService usuarioService = new UsuarioService();
    static PrestamoService prestamoService = new PrestamoService();

    static void Main(string[] args)
{
    // Datos de prueba - Libros
    libroService.AgregarLibro(new Libro("101", "Cien Años de Soledad", "Gabriel García Márquez"));
    libroService.AgregarLibro(new Libro("202", "1984", "George Orwell"));
    libroService.AgregarLibro(new Libro("303", "El Quijote", "Miguel de Cervantes"));
    libroService.AgregarLibro(new Libro("404", "The Great Gatsby", "F. Scott Fitzgerald"));

    // Datos de prueba - Usuarios
    usuarioService.AgregarUsuario(new Usuario("001", "Camilo Montes", "camilo@mail.com"));
    usuarioService.AgregarUsuario(new Usuario("002", "Ana Martínez", "ana@mail.com"));
    usuarioService.AgregarUsuario(new Usuario("003", "Carlos López", "carlos@mail.com"));

    // Datos de prueba - Préstamo
    Libro l1 = libroService.BuscarPorIsbn("202");
    Usuario u1 = usuarioService.BuscarPorDocumento("001");
    l1.Disponible = false;
    prestamoService.AgregarPrestamo(new Prestamo(1, l1, u1, 
        DateTime.Now.AddDays(-10), DateTime.Now.AddDays(-2)));

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
                    ShowLoansMenu();
                    break;
                case "4":
                   ShowReportsMenu();
                    break;
                case "5":
                    ShowDataMenu();
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
                Console.Write("ISBN: ");
                string isbn = Console.ReadLine();
                Console.Write("Título: ");
                string titulo = Console.ReadLine();
                Console.Write("Autor: ");
                string autor = Console.ReadLine();
                libroService.AgregarLibro(new Libro(isbn, titulo, autor));
                Console.WriteLine($"\nLibro '{titulo}' agregado con éxito.");
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
                Console.Clear();
                Console.WriteLine("-- Eliminar Libro --");
                Console.Write("Ingrese el ISBN del libro a eliminar: ");
                string isbnEliminar = Console.ReadLine();
                Libro libroEliminar = libroService.BuscarPorIsbn(isbnEliminar);
                if (libroEliminar == null)
                {
                    Console.WriteLine("Libro no encontrado.");
                }
                else if (!libroEliminar.Disponible)
                {
                    Console.WriteLine("No se puede eliminar un libro prestado.");
                }
                else
                {
                    libroService.EliminarLibro(isbnEliminar);
                    Console.WriteLine("Libro eliminado con éxito.");
                }
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
                Console.Clear();
                Console.WriteLine("-- Listado Completo de Libros --");
                foreach (Libro l in libroService.ObtenerTodos())
                    Console.WriteLine(l.DetalleCompleto());
                Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                Console.ReadKey();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine("-- Libros Disponibles --");
                foreach (Libro l in libroService.ObtenerDisponibles())
                    Console.WriteLine(l.DetalleCompleto());
                Console.ReadKey();
                break;
            case "3":
                Console.Clear();
                Console.WriteLine("-- Libros Prestados --");
                foreach (Libro l in libroService.ObtenerPrestados())
                    Console.WriteLine(l.DetalleCompleto());
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
                       Console.Clear();
                        Console.WriteLine("-- Listado de Usuarios Registrados --");
                        Usuario user1 = new Usuario("12345", "Juan Camilo", "juan@correo.com");
                        Usuario user2 = new Usuario("67890", "Maria Lopez", "maria@correo.com");
                        
                        user2.Activo = false;

                        Console.WriteLine(user1.DetalleCompleto());
                        Console.WriteLine(user2.DetalleCompleto());

                        Console.WriteLine("\nPresione cualquier tecla para regresar...");
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

        static void ShowLoansMenu()
{
    bool stayInLoans = true;
    while (stayInLoans)
    {
        Console.Clear();
        Console.WriteLine("-- Módulo de Préstamos --");
        Console.WriteLine("1. Registrar Préstamo");
        Console.WriteLine("2. Listar Préstamos");
        Console.WriteLine("3. Ver detalle de préstamo (por ID)");
        Console.WriteLine("4. Registrar devolución");
        Console.WriteLine("5. Eliminar préstamo");
        Console.WriteLine("6. Regresar al menú principal");

        Console.Write("\nSeleccione una opción: ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                RegisterLoan();
                break;
            case "2":
                ShowListLoansMenu();
                break;
            case "3":
                ShowLoanDetail();
                break;
            case "4":
                RegisterReturn();
                break;
            case "5":
                DeleteLoan();
                break;
            case "6":
                stayInLoans = false;
                break;
            default:
                Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                Console.ReadKey();
                break;
        }
    }
}

        static void ShowListLoansMenu()
{
    bool stayInList = true;
    while (stayInList)
    {
        Console.Clear();
        Console.WriteLine("-- Listado de Préstamos --");
        Console.WriteLine("1. Ver Todos");
        Console.WriteLine("2. Ver Activos");
        Console.WriteLine("3. Ver Cerrados");
        Console.WriteLine("4. Regresar al menú de Préstamos");

        string op = Console.ReadLine();
        if (op == "4") stayInList = false;
        else {
            Console.WriteLine("\nMostrando lista seleccionada...");
            Console.ReadKey();
        }
    }
}

        static void RegisterLoan()
{
    Console.Clear();
    Console.WriteLine("-- Registrar Préstamo --");
    Console.Write("ISBN del Libro: ");
    string isbnPrestamo = Console.ReadLine();
    Libro libroPrestamo = libroService.BuscarPorIsbn(isbnPrestamo);

    if (libroPrestamo == null)
    {
        Console.WriteLine("Libro no encontrado.");
        Console.ReadKey();
        return;
    }
    if (!libroPrestamo.Disponible)
    {
        Console.WriteLine("El libro no está disponible.");
        Console.ReadKey();
        return;
    }

    Console.Write("Documento del Usuario: ");
    string docUsuario = Console.ReadLine();
    Usuario usuarioPrestamo = usuarioService.BuscarPorDocumento(docUsuario);

    if (usuarioPrestamo == null)
    {
        Console.WriteLine("Usuario no encontrado.");
        Console.ReadKey();
        return;
    }

    int nuevoId = prestamoService.TotalPrestamos() + 1;
    libroPrestamo.Disponible = false;
    prestamoService.AgregarPrestamo(new Prestamo(nuevoId, libroPrestamo, 
        usuarioPrestamo, DateTime.Now, DateTime.Now.AddDays(7)));

    Console.WriteLine($"\nÉXITO: Préstamo #{nuevoId} registrado.");
    Console.ReadKey();
}

static void ShowLoanDetail()
{
    Console.Clear();
    Console.WriteLine("-- Detalle de Préstamos Activos --");

    Libro libroPrestamo = new Libro("303", "El Quijote", "Miguel de Cervantes");
    Usuario usuarioPrestamo = new Usuario("001", "Camilo", "camilo@mail.com");

    DateTime fechaInicio = DateTime.Now.AddDays(-10);
    DateTime fechaFin = DateTime.Now.AddDays(-2);

    Prestamo prestamoPrueba = new Prestamo(1, libroPrestamo, usuarioPrestamo, fechaInicio, fechaFin);

    Console.WriteLine(prestamoPrueba.DetalleCompleto());
    Console.WriteLine($"Estado actual: {prestamoPrueba.Estado}");
    Console.WriteLine($"Días transcurridos: {prestamoPrueba.DiasTranscurridos()}");
    Console.WriteLine("\nPresione cualquier tecla para regresar...");
    Console.ReadKey();
}

static void RegisterReturn()
{
    Console.Clear();
    Console.WriteLine("-- Registrar Devolución --");
    Console.Write("ID del préstamo: ");
    int idDevolucion = int.Parse(Console.ReadLine());
    Prestamo prestamoDev = prestamoService.BuscarPorId(idDevolucion);

    if (prestamoDev == null)
    {
        Console.WriteLine("Préstamo no encontrado.");
    }
    else if (prestamoDev.Estado == EstadoPrestamo.Devuelto)
    {
        Console.WriteLine("Este préstamo ya fue devuelto.");
    }
    else
    {
        prestamoService.RegistrarDevolucion(idDevolucion);
        Console.WriteLine($"\nÉXITO: Préstamo #{idDevolucion} marcado como devuelto.");
        Console.WriteLine($"Libro '{prestamoDev.Libro.Titulo}' ahora disponible.");
    }
    Console.ReadKey();
}

static void DeleteLoan()
{
    Console.Clear();
    Console.WriteLine("-- Eliminar Préstamo --");
    Console.WriteLine("Reglas sugeridas: No eliminar si está activo, solo si tiene más de 5 años (historial).");
    Console.Write("ID a eliminar: "); Console.ReadLine();
    Console.WriteLine("\nRegistro eliminado.");
    Console.ReadKey();
}


static void ShowReportsMenu()
{
    bool stayInReports = true;
    while (stayInReports)
    {
        Console.Clear();
        Console.WriteLine("-- Módulo 4: Búsquedas y Reportes --");
        Console.WriteLine("1. Buscar Libro por Título/Autor");
        Console.WriteLine("2. Reporte de Libros más Prestados");
        Console.WriteLine("3. Reporte de Usuarios con Multas/Pendientes");
        Console.WriteLine("4. Inventario Total de la Biblioteca");
        Console.WriteLine("5. Comparación Array vs List");
        Console.WriteLine("6. Regresar al menú principal");

        Console.Write("\nSeleccione un reporte: ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                SearchBooks();
                break;
            case "2":
                Console.WriteLine("\n-- Ranking de Préstamos --");
                Console.WriteLine("1. 1984 - 15 préstamos");
                Console.WriteLine("2. El Quijote - 12 préstamos");
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("\n-- Usuarios con Pendientes --");
                Console.WriteLine("- Carlos López (ID: 5678) - 1 libro retrasado");
                Console.WriteLine("- Ana Martínez (ID: 8765) - Sin multas");
                Console.ReadKey();
                break;
            case "4":
                ShowInventory();
                break;
            case "5":
                ArrayVsListDemo.MostrarComparacion();
                break;
            case "6":
                stayInReports = false;
                break;
            default:
                Console.WriteLine("Opción no válida, intente de nuevo.");
                Console.ReadKey();
                break;
        }
    }
}

static void SearchBooks()
{
    Console.Clear();
    Console.WriteLine("-- Búsqueda de Libros --");
    Console.WriteLine("1. Buscar por ISBN");
    Console.WriteLine("2. Buscar por Título");
    Console.WriteLine("3. Buscar por Autor");
    Console.Write("\nSeleccione: ");
    string op = Console.ReadLine();

    Console.Write("Ingrese término de búsqueda: ");
    string termino = Console.ReadLine();

    Console.WriteLine($"\n[Resultados para '{termino}']:");

    if (op == "1")
    {
        Libro l = libroService.BuscarPorIsbn(termino);
        if (l != null) Console.WriteLine(l.DetalleCompleto());
        else Console.WriteLine("No encontrado.");
    }
    else if (op == "2")
    {
        Libro l = libroService.BuscarPorTitulo(termino);
        if (l != null) Console.WriteLine(l.DetalleCompleto());
        else Console.WriteLine("No encontrado.");
    }
    else if (op == "3")
    {
        foreach (Libro l in libroService.BuscarPorAutor(termino))
            Console.WriteLine(l.DetalleCompleto());
    }
    Console.ReadKey();
}

static void ShowInventory()
{
    Console.Clear();
    Console.WriteLine("-- Inventario General --");
    Console.WriteLine($"Total Libros: {libroService.TotalLibros()}");
    Console.WriteLine($"Disponibles: {libroService.TotalDisponibles()}");
    Console.WriteLine($"En Préstamo: {libroService.TotalPrestados()}");
    Console.WriteLine($"\nTotal Usuarios: {usuarioService.TotalUsuarios()}");
    Console.WriteLine($"Activos: {usuarioService.TotalActivos()}");
    Console.WriteLine($"Inactivos: {usuarioService.TotalInactivos()}");
    Console.WriteLine($"\nTotal Préstamos: {prestamoService.TotalPrestamos()}");
    Console.WriteLine($"Activos: {prestamoService.TotalActivos()}");
    Console.WriteLine($"Vencidos: {prestamoService.TotalVencidos()}");
    Console.WriteLine($"Devueltos: {prestamoService.TotalDevueltos()}");
    Console.WriteLine($"Promedio días préstamo: {prestamoService.PromedioDiasPrestamo():F1}");
    Console.ReadKey();
}

static void ShowDataMenu()
{
    bool stayInDataMenu = true;
    while (stayInDataMenu)
    {
        Console.Clear();
        Console.WriteLine("-- Módulo 5: Guardar / Cargar datos --");
        Console.WriteLine("1. Guardar datos");
        Console.WriteLine("2. Cargar datos");
        Console.WriteLine("3. Reiniciar datos");
        Console.WriteLine("4. Regresar al menú principal");

        Console.Write("\nSeleccione una opción: ");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.WriteLine("\nGuardando información en el sistema...");
                Console.WriteLine("¡Datos guardados con éxito!");
                Console.ReadKey();
                break;
            case "2":
                Console.WriteLine("\nCargando datos desde el almacenamiento...");
                Console.WriteLine("¡Datos cargados con éxito!");
                Console.ReadKey();
                break;
            case "3":
                ResetData();
                break;
            case "4":
                stayInDataMenu = false;
                break;
            default:
                Console.WriteLine("Opción no válida.");
                Console.ReadKey();
                break;
        }
    }
}

static void ResetData()
{
    Console.Clear();
    Console.WriteLine("-- Reiniciar datos --");
    Console.Write("¿Está seguro de que desea borrar todos los datos? (S/N): ");
    string confirm = Console.ReadLine().ToUpper();

    if (confirm == "S")
    {
        Console.WriteLine("\nBorrando registros...");
        Console.WriteLine("El sistema ha sido reiniciado a valores de fábrica.");
    }
    else
    {
        Console.WriteLine("\nOperación cancelada.");
    }
    Console.ReadKey();
}


}