using System.Runtime.CompilerServices;

namespace Ejercicio3;

public class Libro
{
    public string isbn { get; set; } // id de los libros
    public string autor { get; set; }
    public string titulo { get; set; }
    public string genero { get; set; }
    public int paginas { get; set; }
    public bool prestado { get; set; } // true - prestado ; false - no prestado

    public Libro(string isbn, string autor, string titulo, string genero, int paginas)
    {
        this.isbn = isbn;
        this.autor = autor;
        this.titulo = titulo;
        this.genero = genero;
        this.paginas = paginas;
        this.prestado = false;
    }

    public Libro()
    {
        this.isbn = "x";
        this.autor = "x";
        this.titulo = "x";
        this.genero = "x";
        this.paginas = 0;
        this.prestado = false;
    }

    public static void MostrarCatalogo(List<Libro> libros)
    {
        Console.WriteLine($"{"Titulo",35} {"ISBN", 30} {"Autor", 35} {"Genero", 30} {"Paginas", 10} {"Prestado", 10}");
        foreach (var libro in libros)
        {
            Console.WriteLine($"{libro.titulo,35} {libro.isbn, 30} {libro.autor, 35} {libro.genero, 30} {libro.paginas, 10} {libro.prestado, 10}");
        }

    }
    public static int BuscarNombre(List<Libro> libros, string nombre)// retorna indice
    {
        int indice = 0;
        
        
        foreach (var libro in libros) // busqueda por nombre
        {
            if (libro.titulo == nombre)
            {
                Console.WriteLine($"{libro.titulo,25} {libro.isbn, 20} {libro.autor, 25} {libro.genero, 20} {libro.paginas, 10} {libro.prestado, 10}");
                return indice;
            }
            
            indice++;
            
        }
        return -1;
    }
    
    public static int BuscarAutor(List<Libro> libros, string autor)
    {
        int total = 0;
        foreach (var libro in libros) // busqueda por autor
        {
            if (libro.autor == autor)
            {
                Console.WriteLine($"{libro.titulo,25} {libro.isbn, 20} {libro.autor, 25} {libro.genero, 20} {libro.paginas, 10} {libro.prestado, 10}");
                total++;
            }
            
        }
        return total;
    }
    
    public static int BuscarGenero(List<Libro> libros, string genero)
    {
        int total = 0;
        foreach (var libro in libros) // busqueda por genero
        {
            if (libro.genero == genero)
            {
                Console.WriteLine($"{libro.titulo,25} {libro.isbn, 20} {libro.autor, 25} {libro.genero, 20} {libro.paginas, 10} {libro.prestado, 10}");
                total++;
            }
            
        }
        return total;
    }

    public static void BuscarByKeyword(List<Libro> libros, string keyword) // busqueda por keyword
    {
        Console.WriteLine($"\n{"Titulo",25} {"ISBN", 20} {"Autor", 25} {"Genero", 20} {"Paginas", 10} {"Prestado", 10}");
        BuscarNombre(libros, keyword);
        BuscarAutor(libros, keyword);
        BuscarGenero(libros, keyword);

    }
    
    
    
}

