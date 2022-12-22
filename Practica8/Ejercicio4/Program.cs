using Ejercicio4;
using Ejercicio4.Objetos;
using Ejercicio4.Personajes;

class Program
{
    public static void Main(string[] args)
    {


        List<Arma> armas = new List<Arma>();
        armas.Add(Entidades.arco);
        armas.Add(Entidades.hacha);
        armas.Add(Entidades.kunai);
        armas.Add(Entidades.lanza);
        armas.Add(Entidades.espadaHierro);
        armas.Add(Entidades.espadaDeSangre);
        armas.Add(Entidades.catana);
        armas.Add(Entidades.bastonMago);
        armas.Add(Entidades.excalibur);
        armas.Add(Entidades.rayoZeus);

        List<Enemigo> enemigos = new List<Enemigo>();
        enemigos.Add(Entidades.duende);
        enemigos.Add(Entidades.orco);
        enemigos.Add(Entidades.demonio);
        enemigos.Add(Entidades.dragon);
        enemigos.Add(Entidades.leviatan);
        enemigos.Add(Entidades.angelCaido);

        List<Escudo> escudos = new List<Escudo>();
        escudos.Add(Entidades.escudoRaro);
        escudos.Add(Entidades.escudoEpico);
        escudos.Add(Entidades.escudoLegendario);

        //heroe1.Pelear(enemigo1, false, null);

        // HEROE POR DEFECTO

        Heroe heroe = new Heroe(
            nombre:"Luis",
            vida:900,
            nivel:20,
            ataque:20,
            defensa:40,
            null,
            null
        );

        bool loop = true;
        int op = 0;
        //Heroe heroe = null;
        
        while(loop)
        {

            Console.Clear(); // limpiar buffer de pantalla
            
            Console.WriteLine($"\n{"Buenos vs Malos: El videojuego", 40}");// texto centrado del menu principal
            Console.Write("\n\t1. Crear Heroe" +
                          "\n\t2. Pelear" +
                          "\n\t3. Estadisticas" +
                          "\n\t4. Abrir Inventario" +
                          "\n\t9. Salir" + 
                          "\n\n: ");

            try
            {
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1: // crear heroe
                        heroe = Heroe.CrearHeroe();
                       
                        break;
                   
                    case 2: // pelear
                        Console.Clear(); // limpiar buffer de pantalla
                        if (heroe == null)
                        {
                            Console.WriteLine("Primero crea un heroe");
                        }
                        else
                        {
                            // enemigo aleatorio
                            Enemigo enemigo = enemigos[new Random().Next(0, 6)];
                            Console.WriteLine ($"{"Pelea iniciada", 10}{"Oponente: ", 30} {enemigo.Nombre}");
                            heroe.Pelear(enemigo, false, null);
                        }


                        break; 
                   
                    case 3: // estadisticas
                        Console.Clear(); // limpiar buffer de pantalla
                        if (heroe == null)
                        {
                            Console.WriteLine("Primero crea un heroe");
                        }
                        else
                        {
                            heroe.MostrarInformacion();
                        }

                        break;
                    
                    case 4: // abrir inventario
                        if (heroe == null)
                        {
                            Console.WriteLine("Primero crea un heroe");
                        }
                        else
                        {
                            heroe.ArmaPrincipal.GetInformacion();
                            heroe.EscudoPrincipal.GetInformacion();
                            heroe.Inventario.MostrarInventario();
                        }

                        break;
                   
                    case 9: // salir
                        Console.WriteLine("Saliendo...");
                        Environment.Exit(0);// devuelve 0 (sin error)
                        break;
                   
                    default:
                        Console.WriteLine("Ingresa una opción válida");
                        break;
               
                }
            
            }
            catch (Exception e) // en caso de no colocar un dato bien
            {
                // descomente si existen errores
                Console.WriteLine($"\tError\n\n{e}\n");

                Console.WriteLine($"\nAdvertencia: {e.Message}\n");
            }


            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadLine();

        }

    }

}