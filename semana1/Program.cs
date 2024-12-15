using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloWorld
{
  // La clase Circulo 
    public class Circulo
    {
        // Propiedad encapsulada para almacenar el radio
        private double radio;

        // Constructor 
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Método para calcular el área del círculo
        public double CalcularArea()
        {
            return Math.PI * radio * radio; // Fórmula del área: PI * radio^2
        }

        // Método para calcular el perímetro del círculo
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio; // Fórmula del perímetro: 2 * PI * radio
        }
    }
    // La clase Cuadrado 
    public class Cuadrado
    {
        // Propiedad encapsulada para almacenar el lado
        private double lado;

        // Constructor 
        public Cuadrado(double lado)
        {
            this.lado = lado;
        }

        // Método para calcular el área del cuadrado
        public double CalcularArea()
        {
            return lado * lado; // Fórmula del área: lado^2
        }

        // Método para calcular el perímetro del cuadrado
        public double CalcularPerimetro()
        {
            return 4 * lado; // Fórmula del perímetro: 4 * lado
        }
    }


  
  // clase principal de la pantalla
	public class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Unidad Estatal Amazónica");

            Console.WriteLine("=============================================");

			// Crear un objeto de la clase Circulo con un radio de 5
      Circulo miCirculo = new Circulo(5);
      Console.WriteLine("Círculo:");
      Console.WriteLine("Área: " + miCirculo.CalcularArea()); // Mostrar el área del círculo
      Console.WriteLine("Perímetro: " + miCirculo.CalcularPerimetro()); // Mostrar el perímetro del círculo

        Console.WriteLine("=============================================");

      // Crear un objeto de la clase Cuadrado con un lado de 4
      Cuadrado miCuadrado = new Cuadrado(4);
      Console.WriteLine("\nCuadrado:");
      Console.WriteLine("Área: " + miCuadrado.CalcularArea()); // Mostrar el área del cuadrado
      Console.WriteLine("Perímetro: " + miCuadrado.CalcularPerimetro()); // Mostrar el perímetro del cuadrado

		}
	}
}
