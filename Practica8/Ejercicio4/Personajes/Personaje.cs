using Ejercicio4.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Personajes
{
    public class Personaje
    {
        private string nombre;
        private double vida;
        private double vidaTotal;
        private int nivel;
        private double ataque;
        private double defensa;
        private Arma armaPrincipal;
        private Escudo escudoPrincipal;

        public Personaje(string nombre,
                         double vida,
                         int nivel,
                         double ataque,
                         double defensa,
                         Arma? arma,
                         Escudo? escudo)
        {
            this.nombre = nombre;
            this.vida = vida;
            this.vidaTotal = vida;// almacenrar el total de vida que tenia antes de restar a this.vida en los combates
            this.nivel = nivel;
            this.ataque = ataque;
            this.defensa = defensa;
            // Tanto arma y escudo pueden ser nulos y se les asignara uno
            this.ArmaPrincipal = arma;
            this.EscudoPrincipal = escudo;
        }


        public double Atacar(Personaje enemigo)
        {
            double damageOcasionado = 0;
            
            //sumar ataque de personaje y el de su arma principal
            
            double ataqueTotal = this.ataque + armaPrincipal.Damage;

            /* generar numero aleatorio, si es menor que la probabilidad de critico
             * no se aumenta lo de dano critico
             */

            Random seed = new Random();
            double random = seed.NextDouble(); // genera double del 0 al 1.0
            random = Math.Truncate(random * 1000) / 1000;
            if (random < armaPrincipal.PosibilidadCritico) {
                ataqueTotal += armaPrincipal.DamageCritico;
                Console.WriteLine($"{this.Nombre} ha conseguido un ataque critico con su {armaPrincipal.Nombre}");
            }

            double defensaTotal = enemigo.Defender(ataqueTotal);// defensa del enemigo

            if (defensaTotal == ataqueTotal)
            {
                Console.WriteLine($"{this.Nombre} ha conseguido anular completamente el ataque con su {escudoPrincipal.Nombre}");
            }

            // restar defensa al ataque
            damageOcasionado = ataqueTotal - defensaTotal;

            return damageOcasionado;
        }
        public double Defender(double ataque)
        {
            double defensaTotal = this.defensa + escudoPrincipal.Proteccion;

            Random seed = new Random();
            double random = seed.NextDouble();

            if (random < escudoPrincipal.PosibilidadAtaqueNulo)
                defensaTotal = ataque;


            return defensaTotal;
        }

        public void Regenerar()// regenera toda la vida
        {
            PocionCuracion pocionVida = new PocionCuracion(
                "Pocion de Curacion",
                1,
                "Rara",
                Double.MaxValue,
                1.0
            );
            
            this.Vida = this.VidaTotal * pocionVida.VidaExtra;
            Console.WriteLine($"Se ha consumido una {pocionVida.Nombre}\nLa vida de {this.Nombre} ha sido reestablecida");
        }

        public void Regenerar(double porcentaje)  // se pasa como parametro el porcentaje de vida
        {
            // porcentaje = 1 -> aumenta toda la vida
            this.Vida = this.VidaTotal * porcentaje;
            Console.WriteLine($"La vida de {this.Nombre} ha sido reestablecida");
        }


        public Arma ArmaPrincipal 
        { 
            get => armaPrincipal;
            set { 
                if (value == null){ // si lo que se iguala es nulo {
                    armaPrincipal = Arma.armaGenerica;
                } else
                {
                    armaPrincipal = value;
                }
            } 
        }

        public Escudo EscudoPrincipal
        {
            get => escudoPrincipal;
            set {
                if (value == null) // si lo que se iguala es nulo
                {
                    escudoPrincipal = Escudo.escudoGenerico;
                } else
                {
                    escudoPrincipal = value;
                }
            }
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public double Vida { get => vida; set => vida = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public double Ataque { get => ataque; set => ataque = value; }
        public double Defensa { get => defensa; set => defensa = value; }
        public double VidaTotal { get => vidaTotal; set => vidaTotal = value; }
    }
}
