//Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua) 
//en una lista, pregunte al usuario la nota que ha sacado en cada asignatura y elimine de la lista las asignaturas aprobadas. 
//Al final el programa debe mostrar por pantalla las asignaturas que el usuario tiene que repetir.





using System;
using System.Collections.Generic;

namespace RepetirAsignaturas
{
    // Clase que representa un curso con asignaturas y notas
    public class Curso
    {
        // Diccionario para almacenar asignaturas y sus notas
        private Dictionary<string, int> asignaturas;

        // Constructor que inicializa las asignaturas
        public Curso()
        {
            asignaturas = new Dictionary<string, int>();
            asignaturas.Add("Matemáticas", 0);
            asignaturas.Add("Física", 0);
            asignaturas.Add("Química", 0);
            asignaturas.Add("Historia", 0);
            asignaturas.Add("Lengua", 0);
        }

        // Método para asignar notas a las asignaturas
        public void AsignarNotas()
        {
            foreach (var asignatura in asignaturas.Keys)
            {
                Console.Write($"Ingrese la nota de {asignatura}: ");
                if (int.TryParse(Console.ReadLine(), out int nota))
                {
                    asignaturas[asignatura] = nota;
                }
                else
                {
                    Console.WriteLine("Nota inválida. Se asignará un 0.");
                    asignaturas[asignatura] = 0;
                }
            }
        }

        // Método para eliminar asignaturas aprobadas
        public void EliminarAprobadas()
        {
            List<string> aprobadas = new List<string>();

            foreach (var asignatura in asignaturas)
            {
                if (asignatura.Value >= 5) // Consideramos aprobado con nota >= 5
                {
                    aprobadas.Add(asignatura.Key);
                }
            }

            foreach (var asignatura in aprobadas)
            {
                asignaturas.Remove(asignatura);
            }
        }

        // Método para mostrar las asignaturas que deben repetirse
        public void MostrarRepetir()
        {
            if (asignaturas.Count == 0)
            {
                Console.WriteLine("¡Felicidades! No tienes asignaturas que repetir.");
            }
            else
            {
                Console.WriteLine("Debes repetir las siguientes asignaturas:");
                foreach (var asignatura in asignaturas.Keys)
                {
                    Console.WriteLine($"- {asignatura}");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase Curso
            Curso curso = new Curso();

            // Asignar notas a las asignaturas
            curso.AsignarNotas();

            // Eliminar asignaturas aprobadas
            curso.EliminarAprobadas();

            // Mostrar asignaturas que deben repetirse
            curso.MostrarRepetir();
        }
    }
}
