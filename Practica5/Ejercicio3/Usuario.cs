using System.Runtime.CompilerServices;

namespace Ejercicio3;

public class Usuario
{
    public string nombre { get; set; }
    private string apellido;
    private int numeroAsociado;
    private string direccion;
    private bool acceso;
    public Dictionary<Libro, DateTime> librosPrestamo { get; set; }

    public Usuario(string nombre, string apellido, int numeroAsociado, string direccion)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.numeroAsociado = numeroAsociado;
        this.librosPrestamo = new Dictionary<Libro, DateTime>(); // Libro  ; string - fecha de vencimientos.direccion = direccion;
        this.acceso = false;// true - con acceso; false - sin acceso
    }

    public void SolicitarPrestamo(List<Libro> libros, string nombre)
    {
        int indice = Libro.BuscarNombre(libros, nombre);
        
        // verificar existencia de libro
        if (indice != -1)
        {
            // verificar si esta en prestamo o no
            if (!libros[indice].prestado)// si no esta prestado
            {
                libros[indice].prestado = true;
                
                //obtener fecha de vencimiento
                DateTime hoy = DateTime.Now;
                DateTime fechaDevolucion = hoy.AddDays(3);
                
                // agregar libro a diccionario de libros prestados
                this.librosPrestamo.Add(libros[indice], fechaDevolucion);

                Console.WriteLine($"Se autorizo el prestamo de {nombre}, tienes 3 dias para devolverlo");
                
            }
            else
            {
                Console.WriteLine($"El libro {nombre} ya esta en prestamo");
            }

        }
        else
        {
            Console.WriteLine($"El libro {nombre} no existe");
        }
    

    }

    public void VerPrestamos()
    {  
        Console.WriteLine($"\n{"Titulo",25} {"ISBN", 20} {"Autor", 25} {"Fecha Vencimiento", 25} {"Adeudo", 25}");
        foreach (var item in this.librosPrestamo)// itera los libros prestados
        {
            Console.WriteLine($"{item.Key.titulo,25} {item.Key.isbn, 20} {item.Key.autor, 25} {item.Value.ToString(), 25} {"$" + this.VerificarAdeudo(item.Value), 25}");
            
        }
    }
    
    public int VerificarAdeudo(DateTime fVencimiento)
    {
        DateTime hoy = DateTime.Now;
        int diferencia = (hoy - fVencimiento).Days;
        
        
        if (diferencia > 3) // han pasado de 3 dias y se debera pagar $15
        {
            return 15;
        }

        return 0;
    }

    public static Usuario signUp()
    {
        Console.WriteLine($"{"Registro", 50}");
        Console.Write("\nNombre: ");
        string nombre = Console.ReadLine();
        
        Console.Write("Apellido: ");
        string apellido = Console.ReadLine();
        
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        Random seed = new Random(); // seed 10 para numero random
        int numeroAsociado = seed.Next(10000000, 99999999);

        Usuario user = new Usuario(nombre, apellido, numeroAsociado, direccion);
        
        Console.WriteLine($"Se registro exitosamente a {nombre} {apellido} con el número de asociado {numeroAsociado} ");

        return user;
    }


    public bool login()
    {
        Console.WriteLine($"{"Inicio de Sesión", 50}");
        this.acceso = false; // niega el acceso desde un principio
        
        Console.Write("\nNombre: ");
        string nombre = Console.ReadLine();
        
        Console.Write("\nNumero de asociado: ");
        int numeroAsociado = int.Parse(Console.ReadLine());

        
        if (this.nombre != nombre || this.numeroAsociado != numeroAsociado) // en caso de no colocar alguno de los campos bien
        {
            Console.WriteLine("Ingrese los datos correctamente");
            return this.acceso;
        } 
        
        this.acceso = true;
        return this.acceso; // no se inicio sesion
    }

    public void modificarPerfil()
    {
        if (!this.acceso)
        {
            return;// sale sin realizar acciones
        }
        
        Console.Write("\nNombre: ");
        this.nombre = Console.ReadLine();
        
        Console.Write("Apellido: ");
        this.apellido = Console.ReadLine();
        
        Console.Write("Dirección: ");
        this.direccion = Console.ReadLine();
        
    }
    
}