// resuelva el código en C# la verificación  de una operación matemática se encuentran balanceados:
// Ej: {7+(8*5)-[(9-7)+(4+1)]} resultado => formula balanceada.

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = 3; // Número de discos
        Stack<int> origen = new Stack<int>();
        Stack<int> auxiliar = new Stack<int>();
        Stack<int> destino = new Stack<int>();

        // Inicializa la torre de origen con los discos
        for (int i = n; i > 0; i--)
        {
            origen.Push(i);
        }

        Console.WriteLine("Estado inicial:");
        PrintTowers(origen, auxiliar, destino);

        // Resuelve el problema
        Hanoi(n, origen, destino, auxiliar);

        Console.WriteLine("\nEstado final:");
        PrintTowers(origen, auxiliar, destino);
    }

    static void Hanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar)
    {
        if (n == 1)
        {
            destino.Push(origen.Pop());
            PrintTowers(origen, auxiliar, destino);
            return;
        }

        // Mueve n-1 discos de origen a auxiliar usando destino como apoyo
        Hanoi(n - 1, origen, auxiliar, destino);

        // Mueve el disco más grande al destino
        destino.Push(origen.Pop());
        PrintTowers(origen, auxiliar, destino);

        // Mueve los n-1 discos de auxiliar a destino usando origen como apoyo
        Hanoi(n - 1, auxiliar, destino, origen);
    }

    static void PrintTowers(Stack<int> origen, Stack<int> auxiliar, Stack<int> destino)
    {
        Console.WriteLine("Origen: " + string.Join(",", origen));
        Console.WriteLine("Auxiliar: " + string.Join(",", auxiliar));
        Console.WriteLine("Destino: " + string.Join(",", destino));
        Console.WriteLine("----------------------------");
    }
}

