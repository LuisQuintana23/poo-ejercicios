namespace Practica7;

public class Utilidades
{
    public static string MostrarMenu(Dictionary<string, string> opciones, string? titulo)
    {
        if (titulo != null)
            Console.WriteLine($"{titulo, 50}\n");
        else
            Console.WriteLine($"{"Menu", 50}\n");
        
        // Mostrar opciones
        foreach (var (clave, valor) in opciones)
        {
            Console.Write($"\t{clave}. {valor}\n");
        }
        
        Console.WriteLine(": ");
        string eleccion = Console.ReadLine();

        if (opciones.ContainsKey(eleccion))
        {
            return eleccion;
        }

        return null;
    }

    public static string Capitalize(string word) // la primera letra la convierte a mayuscula, lo demas a minuscula
    {
        return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
    }

}