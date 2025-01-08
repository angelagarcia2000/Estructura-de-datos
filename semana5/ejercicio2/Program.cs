//Escribir un programa que pregunte al usuario los números ganadores de la lotería 
//primitiva, los almacene en una lista y los muestre por pantalla ordenados de menor a mayor.

using System;
using System.Collections.Generic;
using System.Linq;

namespace LoteriaPrimitiva
{
    // Clase que representa la gestión de números de la lotería
    public class Loteria
    {
        // Lista para almacenar los números ganadores
        private List<int> numerosGanadores;

        // Constructor que inicializa la lista
        public Loteria()
        {
            numerosGanadores = new List<int>();
        }

        // Método para agregar un número ganador
        public void AgregarNumero(int numero)
        {
            // Validar que el número esté dentro del rango permitido (1-49)
            if (numero < 1 || numero > 49)
            {
                Console.WriteLine("El número debe estar entre 1 y 49.");
            }
            else if (numerosGanadores.Contains(numero))
            {
                Console.WriteLine("El número ya ha sido ingresado.");
            }
            else
            {
                numerosGanadores.Add(numero);
            }
        }

        // Método para mostrar los números ganadores ordenados
        public void MostrarNumerosOrdenados()
        {
            Console.WriteLine("Números ganadores ordenados de menor a mayor:");
            foreach (var numero in numerosGanadores.OrderBy(n => n))
            {
                Console.WriteLine(numero);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Loteria loteria = new Loteria();

            Console.WriteLine("Ingrese los números ganadores de la lotería primitiva.");
            Console.WriteLine("Escriba un número por vez y presione Enter. Ingrese '0' para terminar.");

            while (true)
            {
                Console.Write("Número: ");
                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    if (numero == 0)
                    {
                        break; // Terminar la entrada de números
                    }

                    loteria.AgregarNumero(numero);
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un número válido.");
                }
            }

            // Mostrar los números ganadores ordenados
            loteria.MostrarNumerosOrdenados();
        }
    }
}

