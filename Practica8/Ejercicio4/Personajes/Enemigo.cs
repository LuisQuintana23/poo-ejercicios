using Ejercicio4.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Personajes
{
    public class Enemigo : Personaje
    {
        public Enemigo(string nombre, double vida, int nivel, double ataque, double defensa, Arma? arma, Escudo? escudo) : base(nombre, vida, nivel, ataque, defensa, arma, escudo)
        {
        }
    }
}
