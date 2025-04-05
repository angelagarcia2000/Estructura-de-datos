
//Progama para daterminar los vuelos más economicos de una ciudad a otra

class Vuelos
{
    // Se crea un diccionario para almacenar las conexiones de vuelos, donde cada ciudad tiene una lista de destinos con su precio
    private Dictionary<string, List<Vuelo>> grafoVuelos;
 
    public Vuelos()
    {
        // Inicializamos el diccionario de vuelos
        grafoVuelos = new Dictionary<string, List<Vuelo>>();
    }
 
    // Método para agregar un vuelo entre dos ciudades con su respectivo precio
    public void AgregarVuelo(string ciudadOrigen, string ciudadDestino, double precio)
    {
        // Verificamos si la ciudad origen ya existe en el grafo, sino la agregamos
        if (!grafoVuelos.ContainsKey(ciudadOrigen))
        {
            grafoVuelos[ciudadOrigen] = new List<Vuelo>();
        }
 
        // Agregamos el vuelo (arista) al grafo
        grafoVuelos[ciudadOrigen].Add(new Vuelo(ciudadDestino, precio));
 
        // Aseguramos que la ciudad destino también esté en el grafo, aunque no tenga vuelos salientes
        if (!grafoVuelos.ContainsKey(ciudadDestino))
        {
            grafoVuelos[ciudadDestino] = new List<Vuelo>();
        }
    }
 
    // Método para encontrar la ruta más barata usando el algoritmo de Dijkstra
    public void EncontrarRutaMasBarata(string ciudadOrigen, string ciudadDestino)
    {
        // Inicializamos las estructuras necesarias para el algoritmo de Dijkstra
        var distancias = new Dictionary<string, double>();
        var padres = new Dictionary<string, string>();
        var ciudadesNoVisitadas = new List<string>();
 
        // Asignamos un valor infinito a todas las distancias, excepto la ciudad de origen
        foreach (var ciudad in grafoVuelos.Keys)
        {
            distancias[ciudad] = double.MaxValue;
            padres[ciudad] = null;
            ciudadesNoVisitadas.Add(ciudad);
        }
 
        distancias[ciudadOrigen] = 0; // La distancia a la ciudad de origen es 0
 
        // Aplicamos el algoritmo de Dijkstra
        while (ciudadesNoVisitadas.Count > 0)
        {
            // Encontramos la ciudad no visitada con la distancia más corta
            string ciudadActual = ObtenerCiudadMasCercana(ciudadesNoVisitadas, distancias);
            ciudadesNoVisitadas.Remove(ciudadActual);
 
            // Si llegamos a la ciudad destino, podemos terminar
            if (ciudadActual == ciudadDestino)
            {
                break;
            }
 
            // Actualizamos las distancias de los vecinos
            foreach (var vuelo in grafoVuelos[ciudadActual])
            {
                double nuevaDistancia = distancias[ciudadActual] + vuelo.Precio;
                if (nuevaDistancia < distancias[vuelo.CiudadDestino])
                {
                    distancias[vuelo.CiudadDestino] = nuevaDistancia;
                    padres[vuelo.CiudadDestino] = ciudadActual;
                }
            }
        }
 
        // Imprimimos el camino más barato
        ImprimirRuta(ciudadOrigen, ciudadDestino, padres);
        Console.WriteLine($"El costo total del vuelo más barato es: {distancias[ciudadDestino]:0.00} USD");
    }
 
    // Método para obtener la ciudad con la distancia más corta
    private string ObtenerCiudadMasCercana(List<string> ciudades, Dictionary<string, double> distancias)
    {
        double distanciaMinima = double.MaxValue;
        string ciudadCercana = null;
 
        foreach (var ciudad in ciudades)
        {
            if (distancias[ciudad] < distanciaMinima)
            {
                ciudadCercana = ciudad;
                distanciaMinima = distancias[ciudad];
            }
        }
 
        return ciudadCercana;
    }
 
    // Método para imprimir el camino desde el origen hasta el destino
    private void ImprimirRuta(string ciudadOrigen, string ciudadDestino, Dictionary<string, string> padres)
    {
        if (ciudadDestino == null)
        {
            Console.WriteLine("No hay ruta disponible.");
            return;
        }
 
        Stack<string> ruta = new Stack<string>();
        string ciudadActual = ciudadDestino;
 
        while (ciudadActual != ciudadOrigen)
        {
            ruta.Push(ciudadActual);
            ciudadActual = padres[ciudadActual];
        }
 
        ruta.Push(ciudadOrigen);
 
        Console.WriteLine("La ruta más barata es:");
        foreach (var ciudad in ruta)
        {
            Console.WriteLine(ciudad);
        }
    }
}
 
class Vuelo
{
    public string CiudadDestino { get; set; }
    public double Precio { get; set; }
 
    public Vuelo(string ciudadDestino, double precio)
    {
        CiudadDestino = ciudadDestino;
        Precio = precio;
    }
}
 
class Program
{
    static void Main()
    {
        Vuelos sistemaVuelos = new Vuelos();
 
        // Agregamos algunos vuelos entre Quito y Guayaquil con precios simulados
        sistemaVuelos.AgregarVuelo("Quito", "Guayaquil", 150);
        sistemaVuelos.AgregarVuelo("Quito", "Guayaquil", 120);
        sistemaVuelos.AgregarVuelo("Quito", "Guayaquil", 130);
        sistemaVuelos.AgregarVuelo("Quito", "Cuenca", 50);
        sistemaVuelos.AgregarVuelo("Cuenca", "Guayaquil", 60);
 
        // Buscamos la ruta más barata entre Quito y Guayaquil
        sistemaVuelos.EncontrarRutaMasBarata("Quito", "Guayaquil");
    }
}
