// Escribir un programa que almacene en una lista los números del 1 al 10 y
// los muestre por pantalla en orden inverso separados por comas.

using System;
using System.Collections.Generic;
using System.Linq;

namespace NumerosInverso
{
    // Clase que gestiona una lista de números
    public class GestorNumeros
    {
        // Lista para almacenar los números
        private List<int> numeros;

        // Constructor que inicializa la lista con los números del 1 al 10
        public GestorNumeros()
        {
            numeros = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numeros.Add(i);
            }
        }

        // Método para mostrar los números en orden inverso separados por comas
        public void MostrarNumerosInverso()
        {
            var numerosInverso = numeros.AsEnumerable().Reverse();
            Console.WriteLine(string.Join(", ", numerosInverso));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase GestorNumeros
            GestorNumeros gestorNumeros = new GestorNumeros();

            Console.WriteLine("Números del 1 al 10 en orden inverso:");
            gestorNumeros.MostrarNumerosInverso();
        }
    }
}




