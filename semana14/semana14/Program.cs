//Ejemplo de arbol binario con datos primitivos//


using System;

//Clase que representa el nodo en el árbol
class Nodo
{
    public int dato;                        //Valor almacenedo en el nodo
    public Nodo izquierda, derecha;        

    public Nodo(int dato)
    {
        this.dato = dato;
        izquierda = derecha = null;
    }
}

// Clase de árblo de busqueda
class ArbolBinario
{
    private Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

 // Método para insertar un nuevo valor en el árbol
    public void Insertar(int dato)
    {
        raiz = InsertarRec(raiz, dato);
    }

 // Método para insertar un nodo en la posición correcta
    private Nodo InsertarRec(Nodo nodo, int dato)
    {
        if (nodo == null)
            return new Nodo(dato);

        if (dato < nodo.dato)
            nodo.izquierda = InsertarRec(nodo.izquierda, dato);
        else if (dato > nodo.dato)
            nodo.derecha = InsertarRec(nodo.derecha, dato);
        
        return nodo;
    }

//Busca un valor en el árbol
    public bool Buscar(int dato)
    {
        return BuscarRec(raiz, dato);
    }

    private bool BuscarRec(Nodo nodo, int dato)
    {
        if (nodo == null)
            return false;
        
        if (dato == nodo.dato)
            return true;
        
        return dato < nodo.dato ? BuscarRec(nodo.izquierda, dato) : BuscarRec(nodo.derecha, dato);
    }

 // Método para recorrer el árbol en inorden (izquierda, raíz, derecha)
    public void InOrden() => InOrdenRec(raiz);
    private void InOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrdenRec(nodo.izquierda);
            Console.Write(nodo.dato + " ");
            InOrdenRec(nodo.derecha);
        }
    }

 // Método para recorrer el árbol en preorden (raíz, izquierda, derecha)
    public void PreOrden() => PreOrdenRec(raiz);
    private void PreOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.dato + " ");
            PreOrdenRec(nodo.izquierda);
            PreOrdenRec(nodo.derecha);
        }
    }

 // Método para recorrer el árbol en postorden (izquierda, derecha, raíz)
    public void PostOrden() => PostOrdenRec(raiz);
    private void PostOrdenRec(Nodo nodo)
    {
        if (nodo != null)
        {
            PostOrdenRec(nodo.izquierda);
            PostOrdenRec(nodo.derecha);
            Console.Write(nodo.dato + " ");
        }
    }
}

class Program
{
    static void Main()
    {
        ArbolBinario arbol = new ArbolBinario();
        int opcion, valor;
        
        do
        {
            // Menú 
            Console.WriteLine("\n--- MENÚ ÁRBOL BINARIO ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Recorrido InOrden");
            Console.WriteLine("4. Recorrido PreOrden");
            Console.WriteLine("5. Recorrido PostOrden");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el número a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    arbol.Insertar(valor);
                    break;
                case 2:
                    Console.Write("Ingrese el número a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(arbol.Buscar(valor) ? "El número está en el árbol." : "Número no encontrado.");
                    break;
                case 3:
                    Console.Write("Recorrido InOrden: ");
                    arbol.InOrden();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.Write("Recorrido PreOrden: ");
                    arbol.PreOrden();
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Write("Recorrido PostOrden: ");
                    arbol.PostOrden();
                    Console.WriteLine();
                    break;
                case 6:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 6);
    }
}
