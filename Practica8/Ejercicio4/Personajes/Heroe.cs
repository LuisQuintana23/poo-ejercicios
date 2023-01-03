using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using Ejercicio4.Objetos;

namespace Ejercicio4.Personajes
{
    public class Heroe : Personaje
    {
        private int puntosMejora;
        private Inventario inventario;

        public Heroe(string nombre,
            double vida, 
            int nivel, 
            double ataque, 
            double defensa, 
            Arma? arma, 
            Escudo? escudo) : base(nombre, vida, nivel, ataque, defensa, arma, escudo)
        {
            this.puntosMejora = 3;
            this.inventario = new Inventario("Mochila básica",
                1,
                "Comun",
                double.MaxValue,
                10); // inventario de 10 objetos
        }

        public void Pelear(Enemigo enemigo, bool? loop, int? turno)
        {
            double damage;

            Random seed = new Random(); 

            if (loop == false)
                turno = seed.Next(0,1);

            // ataque de heroe

            if (turno == 0) { // turno del jugador
                
                damage = this.Atacar(enemigo);
                enemigo.Vida = BajarVida(enemigo.Vida, damage);

                // cuando la vida del enemigo llega a 0 se acaba la batalla
                if (enemigo.Vida <= 0)
                {
                    Console.WriteLine($"{enemigo.Nombre} ha sido derrotado");
                    this.BonificarPuntos();
                    return;
                }

                Console.WriteLine($"Turno de {this.Nombre}");
                Console.WriteLine($"Vida {this.Nombre}: {this.Vida}");
                Console.WriteLine($"Vida {enemigo.Nombre}: {enemigo.Vida}");

                Console.WriteLine("\nPulse cualquier tecla para continuar...");
                Console.ReadKey();
                
                this.Pelear(enemigo, true, 1);
            }
            else
            {
                damage = enemigo.Atacar(this);
                this.Vida = BajarVida(this.Vida, damage);

                if (this.Vida <= 0)
                {
                    Console.WriteLine($"Has sido derrotado");
                    this.BonificarPuntos();
                    return;
                }

                Console.WriteLine($"Turno de {enemigo.Nombre}");
                Console.WriteLine($"Vida {this.Nombre}: {this.Vida}");
                Console.WriteLine($"Vida {enemigo.Nombre}: {enemigo.Vida}");

                Console.WriteLine("\nPulse cualquier tecla para continuar...");
                Console.ReadKey();
                this.Pelear(enemigo, true, 0);
            }

        }

        public void BonificarPuntos() // agrega puntos de mejora segun el rendimiento en batalla
        {
            this.Regenerar();

            if (this.Vida < (this.VidaTotal * 0.8) && this.Vida > (this.VidaTotal * 0.1)){

                puntosMejora += 20;
                Console.WriteLine("Puntos de mejora +20");
            }
            else if (this.Vida > (this.VidaTotal * 0.8))
            {
                puntosMejora += 20;
                Console.WriteLine("Puntos de mejora +20");
                this.SubirNivel();
            }
            else
            {
                puntosMejora += 5;
                Console.WriteLine("Puntos de mejora +5");
            }
            
            
        }

        public void SubirNivel()
        {
            Console.WriteLine($"{this.Nombre} ha subido de nivel");

            double multiplicador = this.Nivel + (0.2 * this.Nivel); // si es level 1: 1 + 0.2 = 1.2; nivel 2: 2 + (0.4) = 2.4


            Console.WriteLine($"Nivel (+1) -> {this.Nivel + 1}");
            Console.WriteLine($"Vida (+{(Vida * multiplicador) - Vida}) -> {this.Vida * multiplicador}");
            Console.WriteLine($"Ataque (+{(Ataque * multiplicador) - Ataque}) -> {this.Ataque * multiplicador}");
            Console.WriteLine($"Defensa (+{(Defensa * multiplicador) - Defensa}) -> {this.Defensa * multiplicador}");

            this.Nivel++;
            this.Vida = Vida * multiplicador;
            this.Ataque = Ataque * multiplicador;
            this.Defensa = Defensa * multiplicador;

            return;
        }

        public static Heroe CrearHeroe()
        {

            Heroe heroe;
            Console.Write("\nNombre: ");
            string nombre = Console.ReadLine();

            Console.Write($"\n{"Selecciona el tipo", 20}");
            Console.Write($"\n\t1. Luchador" +
                          $"\n\t2. Hechicero" +
                          $"\n\t3. Tanque" +
                          $"\n\n: ");

            int tipo = int.Parse(Console.ReadLine());

            switch (tipo)
            {
                case 1: //luchador
                    heroe = new Heroe(
                        nombre,
                        80,
                        1,
                        35,
                        35,
                        null,
                        null
                    );

                    Console.WriteLine($"\nSe ha creado un luchador con el nombre de {nombre}\n");

                    break;

                case 2: //hechicero
                    heroe = new Heroe(
                        nombre,
                        70,
                        1,
                        20,
                        50,
                        null,
                        null
                    );

                    Console.WriteLine($"\nSe ha creado un hechicero con el nombre de {nombre}\n");
                    break;

                case 3: //tanque
                    heroe = new Heroe(
                        nombre,
                        100,
                        1,
                        25,
                        45,
                        null,
                        null
                    );

                    Console.WriteLine($"\nSe ha creado un tanque con el nombre de {nombre}\n");
                    break;

                default:
                    heroe = new Heroe(
                        nombre,
                        80,
                        1,
                        35,
                        35,
                        null,
                        null
                    );
                    Console.WriteLine($"\nSe ha creado un luchador con el nombre de {nombre}\n");
                    break;
            }



            return heroe;
        }

        public void MostrarInformacion()
        {
            var tabla = new ConsoleTable("Nombre", "Vida", "Nivel", "Ataque", "Defensa", "Puntos de Mejora");
            tabla.AddRow(this.Nombre, this.Vida, this.Nivel, this.Ataque, this.Defensa, this.PuntosMejora);

            Console.WriteLine($"\n{"Personaje",20}\n");
            tabla.Write(Format.Minimal);

            Console.WriteLine($"\n{"Arma Principal",20}\n");
            ArmaPrincipal.GetInformacion();

            Console.WriteLine($"\n{"Escudo Principal",20}\n");
            EscudoPrincipal.GetInformacion();

        }


        public static double BajarVida(double vida, double damage)
        {
            if (damage < 0)
            {
                damage *= -1;
            }

            vida -= damage;

            return vida;
        }
        
        public int PuntosMejora { get => puntosMejora; set => puntosMejora = value; }
        public Inventario Inventario { get => inventario; protected set => inventario = value; }
        
    }
    
    
    
    
}