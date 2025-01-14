//

using System;

class Nodo<T>
{
    public T Valor { get; set; }
    public Nodo<T> Siguiente { get; set; }

    public Nodo(T valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

class ListaEnlazada<T>
{
    private Nodo<T> cabeza;

    // Agregar un elemento al final de la lista
    public void Agregar(T valor)
    {
        if (cabeza == null)
        {
            cabeza = new Nodo<T>(valor);
        }
        else
        {
            Nodo<T> actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = new Nodo<T>(valor);
        }
    }

    // Método para invertir la lista enlazada
    public void Invertir()
    {
        Nodo<T> previo = null;
        Nodo<T> actual = cabeza;
        Nodo<T> siguiente = null;

        while (actual != null)
        {
            siguiente = actual.Siguiente; // Guardar el siguiente nodo
            actual.Siguiente = previo;   // Cambiar la referencia
            previo = actual;             // Mover el nodo previo hacia adelante
            actual = siguiente;          // Mover al siguiente nodo
        }

        cabeza = previo; // Actualizar la cabeza de la lista
    }

    // Mostrar los elementos de la lista
    public void Mostrar()
    {
        Nodo<T> actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.Valor + " ");
            actual = actual.Siguiente;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada<int> lista = new ListaEnlazada<int>();

        // Agregar elementos a la lista
        lista.Agregar(1);
        lista.Agregar(2);
        lista.Agregar(3);
        lista.Agregar(4);
        lista.Agregar(5);
        lista.Agregar(6);
        lista.Agregar(7);
        lista.Agregar(8);

        Console.WriteLine("Lista original:");
        lista.Mostrar();

        // Invertir la lista
        lista.Invertir();

        Console.WriteLine("Lista invertida:");
        lista.Mostrar();
    }
}

