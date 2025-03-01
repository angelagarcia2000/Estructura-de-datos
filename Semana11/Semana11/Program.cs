// Traductor básico2

using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario con palabras iniciales
    static Dictionary<string, string> diccionario = new Dictionary<string, string>
    {
        { "Time", "tiempo" },
        { "Person", "persona" },
        { "Year", "año" },
        { "Way", "camino/forma" },
        { "Day", "día" },
        { "Thing", "cosa" },
        { "Man", "hombre" },
        { "World", "mundo" },
        { "Life", "vida" },
        { "Hand", "mano" },
        { "Part", "parte" },
        { "Child", "niño/a" },
        { "Eye", "ojo" },
        { "Woman", "mujer" },
        { "Place", "lugar" },
        { "Work", "trabajo" },
        { "Week", "semana" },
        { "Case", "caso" },
        { "Point", "punto/tema" },
        { "Government", "gobierno" },
        { "Company", "empresa/compañía" }
    };

    // Función para traducir una frase
    static string TraducirFrase(string frase, string idioma)
    {
        string[] palabras = frase.Split(' ');
        List<string> fraseTraducida = new List<string>();

        foreach (string palabra in palabras)
        {
            string palabraCapitalizada = CapitalizarPalabra(palabra);
            // Si la palabra está en el diccionario, la traducimos
            if (diccionario.ContainsKey(palabraCapitalizada))
            {
                if (idioma == "es")  // Traducir de inglés a español
                {
                    fraseTraducida.Add(diccionario[palabraCapitalizada]);
                }
                else if (idioma == "en")  // Traducir de español a inglés
                {
                    fraseTraducida.Add(GetClavePorValor(diccionario, palabra.ToLower()));
                }
            }
            else
            {
                // Si no está en el diccionario, la dejamos tal cual
                fraseTraducida.Add(palabra);
            }
        }

        return string.Join(" ", fraseTraducida);
    }

    // Función para capitalizar la primera letra de la palabra
    static string CapitalizarPalabra(string palabra)
    {
        return char.ToUpper(palabra[0]) + palabra.Substring(1);
    }

    // Función para obtener la clave por su valor (para traducir de español a inglés)
    static string GetClavePorValor(Dictionary<string, string> diccionario, string valor)
    {
        foreach (var par in diccionario)
        {
            if (par.Value.ToLower() == valor.ToLower())
            {
                return par.Key;
            }
        }
        return valor;  // Si no se encuentra, devolvemos el valor original
    }

    // Función para agregar nuevas palabras al diccionario
    static void AgregarPalabra(string ingles, string espanol)
    {
        if (!diccionario.ContainsKey(ingles))
        {
            diccionario[ingles] = espanol;
            Console.WriteLine($"Palabra '{ingles}' agregada al diccionario como '{espanol}'.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }

    // Función principal del programa
    static void Main(string[] args)
    {
        while (true)
        {
            // Mostrar menú de opciones
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Traducir frase");
            Console.WriteLine("2. Agregar nueva palabra al diccionario");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción (1, 2, 3): ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                // Traducir una frase
                Console.Write("¿De qué idioma desea traducir? (español=es, inglés=en): ");
                string idioma = Console.ReadLine().ToLower();
                Console.Write("Ingrese la frase a traducir: ");
                string frase = Console.ReadLine();

                string fraseTraducida = TraducirFrase(frase, idioma);
                Console.WriteLine($"Frase traducida: {fraseTraducida}");
            }
            else if (opcion == "2")
            {
                // Agregar una nueva palabra al diccionario
                Console.Write("Ingrese la palabra en inglés: ");
                string palabraIngles = Console.ReadLine().Trim();
                Console.Write("Ingrese la traducción en español: ");
                string palabraEspanol = Console.ReadLine().Trim();
                AgregarPalabra(palabraIngles, palabraEspanol);
            }
            else if (opcion == "3")
            {
                // Salir del programa
                Console.WriteLine("Gracias por usar el traductor. ¡Hasta luego!");
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}
