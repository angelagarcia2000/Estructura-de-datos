//Escribir un programa que almacene las asignaturas de un curso
// (por ejemplo Matemáticas, Física, Química, Historia y Lengua) en una lista y la muestre por pantalla.


using System;
using System.Collections.Generic;

namespace CursoAsignaturas
{
    // Clase que representa un curso
    public class Curso
    {
        // Propiedad para el nombre del curso
        public string NombreCurso { get; set; }

        // Lista para almacenar las asignaturas
        private List<string> asignaturas;

        // Constructor de la clase Curso
        public Curso(string nombreCurso)
        {
            NombreCurso = nombreCurso;
            asignaturas = new List<string>(); // Inicializar la lista de asignaturas
        }

        // Método para agregar una asignatura al curso
        public void AgregarAsignatura(string asignatura)
        {
            asignaturas.Add(asignatura);
        }

        // Método para mostrar las asignaturas del curso
        public void MostrarAsignaturas()
        {
            Console.WriteLine($"Asignaturas del curso {NombreCurso}:");
            foreach (var asignatura in asignaturas)
            {
                Console.WriteLine("- " + asignatura);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Crear una instancia de la clase Curso
            Curso curso1 = new Curso("Primero de Secundaria");

            // Agregar asignaturas al curso
            curso1.AgregarAsignatura("Matemáticas");
            curso1.AgregarAsignatura("Física");
            curso1.AgregarAsignatura("Química");
            curso1.AgregarAsignatura("Historia");
            curso1.AgregarAsignatura("Lenguaje");

            // Mostrar las asignaturas del curso
            curso1.MostrarAsignaturas();
        }
    }
}

