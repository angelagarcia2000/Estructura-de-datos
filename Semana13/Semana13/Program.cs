// Utilice una búsqueda recursiva o búsqueda iterativa para saber si un titulo existe dentro 
//de un catálogo de revistas, adjunte el link del repositorio de código.// 
//Cree un catálogo de revistas.//
//Ingrese 10 títulos al catálogo//
//Muestre un menú que permita//
//Buscar un titulo//
//La respuesta de la búsqueda será "encontrado" o "no encontrado"//

using System;
using System.Collections.Generic;

class CatalogoRevistas
{
    // Método principal
    static void Main()
    {
        // Creación de un catálogo (lista) de revistas
        List<string> catalogo = new List<string>();

        // Ingresar 10 títulos al catálogo
        Console.WriteLine("Ingresa 10 títulos para el catálogo de revistas:");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("Título " + (i + 1) + ": ");
            string titulo = Console.ReadLine();
            catalogo.Add(titulo); // Agregar el título a la lista
        }

        // Menú para realizar acciones
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Buscar título (Iterativo)");
            Console.WriteLine("2. Buscar título (Recursivo)");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción (1/2/3): ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Búsqueda iterativa
                    Console.Write("Introduce el título a buscar: ");
                    string tituloBuscarIterativo = Console.ReadLine();
                    if (BuscarIterativo(catalogo, tituloBuscarIterativo))
                    {
                        Console.WriteLine("Título encontrado (Búsqueda iterativa).");
                    }
                    else
                    {
                        Console.WriteLine("Título no encontrado (Búsqueda iterativa).");
                    }
                    break;

                case 2:
                    // Búsqueda recursiva
                    Console.Write("Introduce el título a buscar: ");
                    string tituloBuscarRecursivo = Console.ReadLine();
                    if (BuscarRecursivo(catalogo, tituloBuscarRecursivo, 0))
                    {
                        Console.WriteLine("Título encontrado (Búsqueda recursiva).");
                    }
                    else
                    {
                        Console.WriteLine("Título no encontrado (Búsqueda recursiva).");
                    }
                    break;

                case 3:
                    // Salir del programa
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción no válida, por favor elige una opción correcta.");
                    break;
            }
        }
    }

    // Método de búsqueda iterativa
    static bool BuscarIterativo(List<string> catalogo, string titulo)
    {
        foreach (string item in catalogo)
        {
            if (item.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                return true; // Si el título coincide, retorna verdadero
            }
        }
        return false; // Si no se encuentra el título, retorna falso
    }

    // Método de búsqueda recursiva
    static bool BuscarRecursivo(List<string> catalogo, string titulo, int index)
    {
        // Caso base: Si el índice alcanza el final de la lista, significa que no se encontró
        if (index == catalogo.Count)
        {
            return false;
        }

        // Si el título en la posición actual coincide, retornamos verdadero
        if (catalogo[index].Equals(titulo, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }

        // Llamada recursiva al siguiente índice
        return BuscarRecursivo(catalogo, titulo, index + 1);
    }
}
