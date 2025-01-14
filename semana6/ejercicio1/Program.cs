// Función que calcule el número de elementos de una lista

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear una lista de ejemplo
        List<int> miLista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

        // Llamar a la función para calcular la longitud
        int longitud = CalcularLongitud(miLista);

        // Imprimir el resultado
        Console.WriteLine("La longitud de la lista es: " + longitud);
    }

    static int CalcularLongitud<T>(List<T> lista)
    {
        // Inicializamos el contador
        int contador = 0;

        // Recorremos la lista y contamos los elementos
        foreach (var _ in lista)
        {
            contador++;
        }

        // Devolvemos la longitud de la lista
        return contador;
    }
}


