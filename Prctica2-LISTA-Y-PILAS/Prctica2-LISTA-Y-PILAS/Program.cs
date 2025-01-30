using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Definimos una cola para gestionar los asientos de la atracción
        Queue<string> colaAsientos = new Queue<string>();
        int capacidadMaxima = 30;

        // Simulación de llegada de personas a la cola
        for (int i = 1; i <= capacidadMaxima; i++)
        {
            // Se agrega cada persona a la cola en orden de llegada
            colaAsientos.Enqueue("Persona " + i);
            Console.WriteLine("Persona " + i + " ha llegado a la cola.");
        }

        Console.WriteLine("\nTodos los asientos están ocupados. Asignando asientos...\n");

        // Asignación de asientos en orden de llegada
        while (colaAsientos.Count > 0)
        {
            // Se atiende a la primera persona en la cola y se le asigna un asiento
            string persona = colaAsientos.Dequeue();
            Console.WriteLine(persona + " ha subido a la atracción.");
        }

        Console.WriteLine("\nTodas las personas han subido a la atracción.");
    }
}