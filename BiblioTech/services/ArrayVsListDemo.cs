namespace BiblioTech.Services
{
    public class ArrayVsListDemo
    {
        public static void MostrarComparacion()
        {
            Console.WriteLine("\n===== COMPARACIÓN: ARRAY vs LIST =====\n");

            
            Console.WriteLine("--- CON ARRAY ---");
            
            string[] librosArray = new string[3];
            librosArray[0] = "Cien Años de Soledad";
            librosArray[1] = "1984";
            librosArray[2] = "El Quijote";

            Console.WriteLine("Libros en array:");
            foreach (string libro in librosArray)
                Console.WriteLine($"  - {libro}");

       
            Console.WriteLine("→ No puedo agregar un 4to libro sin crear un array nuevo\n");

      
            Console.WriteLine("--- CON LIST ---");
       
            List<string> librosList = new List<string>();
            librosList.Add("Cien Años de Soledad");
            librosList.Add("1984");
            librosList.Add("El Quijote");

            Console.WriteLine("Libros en lista:");
            foreach (string libro in librosList)
                Console.WriteLine($"  - {libro}");

           
            librosList.Add("Harry Potter");
            Console.WriteLine("→ Agregué 'Harry Potter' sin problema");
            Console.WriteLine($"→ La lista ahora tiene {librosList.Count} libros");

            
            librosList.Remove("1984");
            Console.WriteLine($"→ Eliminé '1984', ahora tiene {librosList.Count} libros");

            Console.WriteLine("\nCONCLUSIÓN:");
            Console.WriteLine("  Array  → tamaño FIJO, más rápido en acceso directo");
            Console.WriteLine("  List   → tamaño DINÁMICO, más flexible para agregar/eliminar");
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}