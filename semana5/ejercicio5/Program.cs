//Escribir un programa que almacene en una lista los siguientes precios, 50, 75, 46, 22, 80, 65, 8,
// y muestre por pantalla el menor y el mayor de los precios.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Precios
{
    // Clase para gestionar una lista de precios
    public class GestorPrecios
    {
        // Lista de precios
        private List<int> precios;

        // Constructor que inicializa la lista con los precios dados
        public GestorPrecios()
        {
            precios = new List<int> { 50, 75, 46, 22, 80, 65, 8 };
        }

        // Método para obtener el precio menor
        public int ObtenerMenorPrecio()
        {
            return precios.Min();
        }

        // Método para obtener el precio mayor
        public int ObtenerMayorPrecio()
        {
            return precios.Max();
        }

        // Método para mostrar los precios
        public void MostrarPrecios()
        {
            Console.WriteLine("Lista de precios: " + string.Join(", ", precios));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase GestorPrecios
            GestorPrecios gestorPrecios = new GestorPrecios();

            // Mostrar la lista de precios
            gestorPrecios.MostrarPrecios();

            // Obtener y mostrar el precio menor
            int menorPrecio = gestorPrecios.ObtenerMenorPrecio();
            Console.WriteLine($"El menor precio es: {menorPrecio}");

            // Obtener y mostrar el precio mayor
            int mayorPrecio = gestorPrecios.ObtenerMayorPrecio();
            Console.WriteLine($"El mayor precio es: {mayorPrecio}");
        }
    }
}

