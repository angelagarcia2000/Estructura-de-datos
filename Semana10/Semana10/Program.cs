// campaña de vacunación para la mitigación del COVID//

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Generación de ciudadanos ficticios
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
        {
            ciudadanos.Add("Ciudadano " + i);
        }

        // Generación de conjuntos de vacunados
        HashSet<string> vacunadosPfizer = GenerarVacunados(ciudadanos, 75);
        HashSet<string> vacunadosAstraZeneca = GenerarVacunados(ciudadanos.Except(vacunadosPfizer), 75);
        HashSet<string> vacunadosAmbos = GenerarVacunados(ciudadanos.Except(vacunadosPfizer).Except(vacunadosAstraZeneca), 100);

        // Conjuntos de ciudadanos vacunados
        HashSet<string> vacunados = new HashSet<string>(vacunadosPfizer.Union(vacunadosAstraZeneca).Union(vacunadosAmbos));
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos.Except(vacunados));

        // Resultados
        Console.WriteLine("Ciudadanos no vacunados:");
        MostrarLista(noVacunados);
        
        Console.WriteLine("\nCiudadanos con ambas vacunas:");
        MostrarLista(vacunadosAmbos);
        
        Console.WriteLine("\nCiudadanos vacunados solo con Pfizer:");
        MostrarLista(vacunadosPfizer.Except(vacunadosAmbos));
        
        Console.WriteLine("\nCiudadanos vacunados solo con AstraZeneca:");
        MostrarLista(vacunadosAstraZeneca.Except(vacunadosAmbos));
    }

    static HashSet<string> GenerarVacunados(IEnumerable<string> disponibles, int cantidad)
    {
        Random rnd = new Random();
        List<string> listaDisponibles = disponibles.ToList();
        HashSet<string> seleccionados = new HashSet<string>();

        while (seleccionados.Count < cantidad && listaDisponibles.Count > 0)
        {
            int index = rnd.Next(listaDisponibles.Count);
            seleccionados.Add(listaDisponibles[index]);
            listaDisponibles.RemoveAt(index);
        }

        return seleccionados;
    }

    static void MostrarLista(IEnumerable<string> lista)
    {
        foreach (var item in lista)
        {
            Console.WriteLine(item);
        }
    }
}
