using System.Collections;
using System.Net;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;

namespace Ejercicio3;
using System;
using Newtonsoft.Json;

class Program {
    public static void Main(string[] args)
    {
        List<Libro> biblioteca = getBiblioteca();
        
        /*biblioteca.Add(l1);
        biblioteca.Add(l2);
        biblioteca.Add(l3);
        biblioteca.Add(l4);
        biblioteca.Add(l5);
        biblioteca.Add(l6);
        biblioteca.Add(l7);
        biblioteca.Add(l8);
        biblioteca.Add(libros["libro9"]);
        biblioteca.Add(libros["libro10"]);*/


        //Agregar los libros del diccionario a la lista de libros
        
        Usuario user1 = Usuario.signUp();
        
        // Agregando 2 libros
        //Libro con fecha ya expirada
        DateTime fecha1 = new DateTime(2021, 1, 1);
        
        user1.librosPrestamo.Add(biblioteca[0], fecha1);
        biblioteca[0].prestado = true;
        
        //Libro 2
        user1.SolicitarPrestamo(biblioteca, biblioteca[5].titulo); // prestar libro 6
        
        //MENU PRINCIPAL

        bool loop = user1.login();
        int op = 0;

        while(loop)
        {
            Console.Clear(); // limpiar buffer de pantalla
            Console.WriteLine($"\n{"Biblioteca", 40} {user1.nombre, 30}");// texto centrado del menu principal
            Console.Write("\n\t1. Ver catálogo de libros" +
                              "\n\t2. Buscar Libro" +
                              "\n\t3. Solicitar préstamo de libros" +
                              "\n\t4. Ver mis préstamos" +
                              "\n\t5. Modificar mi perfil" + 
                              "\n\t9. Salir" + 
                              "\n\n:");
            
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1: // Mostrar biblioteca
                    Libro.MostrarCatalogo(biblioteca);
                    break;
                
                case 2: // buscar libro por palabra clave
                    
                    Console.Write("\nPalabra a buscar: ");
                    string keyword = Console.ReadLine();
                    Libro.BuscarByKeyword(biblioteca, keyword);

                    break; 
                
                case 3: // Solicitar un libro
                    
                    Console.Write("\nNombre del libro a solicitar: ");
                    string nombreSolicitado = Console.ReadLine();
                    user1.SolicitarPrestamo(biblioteca, nombreSolicitado);
                    
                    break;
                
                case 4:
                    user1.VerPrestamos();
                    break;
                
                case 5:
                    user1.modificarPerfil();
                    break;
                
                
                case 9:
                    Console.WriteLine("Saliendo...");
                    Environment.Exit(0);// devuelve 0 (sin error)
                    break;
                
                default:
                    Console.WriteLine("Ingresa una opción válida");
                    break;
                
            }
            
            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadLine();

        }


    }
    
    
    public static List<Libro> getBiblioteca() // conectar a api de google de libros
    {
        List<Libro> lista = new List<Libro>();

        //limita a 10 resultados con libros de programacion
        var url = "http://openlibrary.org/subjects/epic.json?limit=10";
 
        //crea una peticion con la url dada
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        
        try
        {
           using (WebResponse response = request.GetResponse())
           {
              using (Stream strReader = response.GetResponseStream())
              {
                 if (strReader == null) return null;
                 using (StreamReader objReader = new StreamReader(strReader))
                 {
                    string json = objReader.ReadToEnd();// json en texto plano o string

                    // Para convertir json a clase se utilizo: https://json2csharp.com/
                    LibroData librosData = JsonConvert.DeserializeObject<LibroData>(json);
                    
                    /*
                     * Libro data contiene todas las clases con sus propiedades necesarias
                     * para que al momento de deserializar el json no exista ningun problema
                     * con el proceso y se pueda acceder a cualquiera de sus propiedades
                    */

                    // iterar para agregar libros al diccionario
                    foreach (var libro in librosData.works)
                    {
                        Libro libObj = new Libro(
                            isbn: libro.availability.isbn,
                            autor: libro.authors[0].name,
                            titulo: libro.title,
                            genero: libro.subject[0],
                            paginas: libro.edition_count
                        );
                        lista.Add(libObj); //agregar a lista de libros

                    }
                    
                    
                 }
              }
           }
        }
        catch (WebException ex) // en caso de que falle el promise
        {
            Console.WriteLine(ex);
        }

        return lista;
    }


}
