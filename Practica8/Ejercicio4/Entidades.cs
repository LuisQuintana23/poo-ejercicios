using Ejercicio4.Objetos;
using Ejercicio4.Personajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    public class Entidades
    {
        // Armas
        public static Arma arco = new Arma(nombre:"Arco de elfo",
                                 nivel:2,
                                 clase:"Comun",
                                 durabilidad:50,
                                 damage:30,
                                 posibilidadCritico:0.06,
                                 damageCritico:90);

        public static Arma hacha = new Arma(nombre:"Hacha de leñador",
                                 nivel:3,
                                 clase:"Rara",
                                 durabilidad:100,
                                 damage:50,
                                 posibilidadCritico:0.1,
                                 damageCritico: 30);

        public static Arma kunai = new Arma(nombre:"Kunai",
                                 nivel:1,
                                 clase:"Rara",
                                 durabilidad:20,
                                 damage:30,
                                 posibilidadCritico:0.04,
                                 damageCritico:120);

        public static Arma lanza = new Arma(nombre:"Lanza",
                                 nivel:1,
                                 clase:"Rara",
                                 durabilidad:1,
                                 damage:300,
                                 posibilidadCritico:0.4,
                                 damageCritico:200);


        public static Arma espadaHierro = new Arma(nombre:"Espada de Hierro",
                                 nivel:2,
                                 clase:"Rara",
                                 durabilidad:80,
                                 damage:40,
                                 posibilidadCritico:0.07,
                                 damageCritico:60);

        public static Arma espadaDeSangre = new Arma(nombre:"Espada de Sangre",
                                 nivel:6,
                                 clase:"Epica",
                                 durabilidad:120,
                                 damage:60,
                                 posibilidadCritico:0.6,
                                 damageCritico:80);


        public static Arma catana = new Arma(nombre:"Catana",
                                 nivel:4,
                                 clase:"Epica",
                                 durabilidad:40,
                                 damage:130,
                                 posibilidadCritico:0.2,
                                 damageCritico:60);

        public static Arma bastonMago = new Arma(nombre:"Baston de Mago",
                                 nivel:4,
                                 clase:"Epica",
                                 durabilidad:300,
                                 damage:120,
                                 posibilidadCritico:0.15,
                                 damageCritico:100);

        public static Arma excalibur = new Arma(nombre:"Excalibur",
                                 nivel:90,
                                 clase:"Legendaria",
                                 durabilidad:700,
                                 damage:600,
                                 posibilidadCritico:0.3,
                                 damageCritico:300);

        public static Arma rayoZeus = new Arma(nombre:"Rayo de zeus",
                                 nivel:90,
                                 clase:"Legendaria",
                                 durabilidad:999,
                                 damage:400,
                                 posibilidadCritico:0.3,
                                 damageCritico:500);


        
        // ESCUDOS
        public static Escudo escudoRaro = new Escudo("Escudo Raro",
                                         1,
                                         "Raro",
                                         50,
                                         30,
                                         0.05); // por si no se ingres un escudo este se setea como su escudo

        public static Escudo escudoEpico = new Escudo("Escudo Epico",
                                         1,
                                         "Epico",
                                         100,
                                         60,
                                         0.1); // por si no se ingres un escudo este se setea como su escudo

        public static Escudo escudoLegendario = new Escudo("Escudo Legendario",
                                         1,
                                         "Legendario",
                                         150,
                                         120,
                                         0.2); // por si no se ingres un escudo este se setea como su escudo



        // ENEMIGOS
        public static Enemigo duende = new Enemigo(nombre:"Duende del bosque",
                                     vida:60,
                                     nivel:2,
                                     ataque:30,
                                     defensa:20,
                                     arma:null,
                                     escudo:null);

        public static Enemigo orco = new Enemigo(nombre:"Orco",
                                     vida:120,
                                     nivel:4,
                                     ataque:40,
                                     defensa:80,
                                     arma:arco,
                                     escudo:null);

        public static Enemigo demonio = new Enemigo(nombre:"Demonio",
                                     vida:80,
                                     nivel:3,
                                     ataque:60,
                                     defensa:30,
                                     arma:espadaDeSangre,
                                     escudo:escudoRaro);

        public static Enemigo dragon = new Enemigo(nombre:"Dragon",
                                     vida:80,
                                     nivel:4,
                                     ataque:80,
                                     defensa:70,
                                     arma:espadaDeSangre,
                                     escudo:escudoRaro);

        public static Enemigo leviatan = new Enemigo(nombre:"Leviatan",
                                     vida:200,
                                     nivel:5,
                                     ataque:130,
                                     defensa:130,
                                     arma:null,
                                     escudo:escudoEpico);

        public static Enemigo angelCaido = new Enemigo(nombre:"Angel Caido",
                                     vida:600,
                                     nivel:6,
                                     ataque:400,
                                     defensa:400,
                                     arma:espadaDeSangre,
                                     escudo:escudoLegendario);

    }

}
