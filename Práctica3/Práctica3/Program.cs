//Aplicación para el registro de jugadores y equipos en un torneo de futbol.

// Clase que gestiona el torneo de fútbol
class TorneoFutbol
{
    private const int MAX_JUGADORES = 30; // Límite de jugadores en el torneo
    private HashSet<string> jugadores = new HashSet<string>(); // Conjunto para evitar duplicados
    private Dictionary<string, string> equipoPorJugador = new Dictionary<string, string>(); // Diccionario para asociar jugadores con equipos

    // Método para registrar un jugador en el torneo
    public void RegistrarJugador(string nombre, string equipo)
    {
        // Verifica si el límite de jugadores ya fue alcanzado
        if (jugadores.Count >= MAX_JUGADORES)
        {
            Console.WriteLine("El torneo ha alcanzado el límite de 30 jugadores.");
            return;
        }

        // Verifica si el jugador ya está registrado
        if (jugadores.Add(nombre))
        {
            equipoPorJugador[nombre] = equipo;
            Console.WriteLine($"Jugador {nombre} registrado en el equipo {equipo}.");
        }
        else
        {
            Console.WriteLine($"El jugador {nombre} ya está registrado.");
        }
    }

    // Método para mostrar todos los jugadores registrados con sus equipos ordenados
    public void MostrarJugadores()
    {
        Console.WriteLine("\nLista de jugadores y sus equipos:");

        // Agrupar jugadores por equipo y ordenar los jugadores alfabéticamente dentro de cada equipo
        var jugadoresPorEquipo = equipoPorJugador
            .GroupBy(j => j.Value) // Agrupamos por el nombre del equipo
            .OrderBy(g => g.Key); // Ordenamos los equipos alfabéticamente

        foreach (var grupo in jugadoresPorEquipo)
        {
            Console.WriteLine($"\n{grupo.Key}:"); // Nombre del equipo
            foreach (var jugador in grupo.OrderBy(j => j.Key)) // Ordenar jugadores alfabéticamente por su nombre
            {
                Console.WriteLine($"  {jugador.Key}"); // Nombre del jugador
            }
        }
    }
}

// Clase principal donde se ejecuta el programa
class Program
{
    static void Main()
    {
        TorneoFutbol torneo = new TorneoFutbol();

        // Nombres ficticios para los jugadores
        string[] nombresJugadores = {
            "Carlos Mendez", "Ana Ruiz", "Pedro Gomez", "Maria Fernandez", "Luis Vargas",
            "Jose Perez", "Javier Lopez", "Marta Romero", "Ricardo Torres", "Sofia Diaz",
            "Raul Hernandez", "Lucia Gonzalez", "Victor Castillo", "Elena Moreno", "Sergio Ortega",
            "Carmen Garcia", "Juan Martin", "Alba Sanchez", "Antonio Lopez", "Teresa Jimenez",
            "Ruben Diaz", "Pablo Gutierrez", "Isabel Alonso", "Manuel Fernandez", "Victoria Ruiz",
            "Enrique Reyes", "Paula Salazar", "David Ramos", "Monica Perez", "Jorge Soto"
        };

        // Registrar automáticamente los jugadores con nombres ficticios
        for (int i = 0; i < nombresJugadores.Length; i++)
        {
            // Asignar equipos alternados entre 'Equipo A' y 'Equipo B'
            string equipo = (i % 2 == 0) ? "Equipo A" : "Equipo B";

            // Registrar al jugador en el torneo
            torneo.RegistrarJugador(nombresJugadores[i], equipo);
        }

        // Muestra la lista final de jugadores registrados, ordenados por equipo
        torneo.MostrarJugadores();
    }
}