using Ejercicio4.Personajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Objetos
{
    public class Arma : Objeto
    {
        public static Arma armaGenerica = new Arma("Daga",
                                                   1,
                                                   "Comun",
                                                   10.00,
                                                   5.00,
                                                   0.3,
                                                   3.0);
        private double damage;
        private double posibilidadCritico;
        private double damageCritico;

        public Arma(string nombre,
                    int nivel, 
                    string clase, 
                    double durabilidad, 
                    double damage, 
                    double posibilidadCritico, 
                    double damageCritico) : base(nombre, nivel, clase, durabilidad)
        {
            this.damage = damage;
            this.posibilidadCritico = posibilidadCritico;
            this.damageCritico = damageCritico;
            PuntosMejoraNecesarios = 1;
        }

        public new void Mejorar(int puntosMejora)
        {
            base.Mejorar(puntosMejora);

            this.Damage+=10;
            this.PosibilidadCritico+=0.05;
            this.damageCritico+=3.0;
            
            Console.WriteLine($"Daño (+10) -> {this.Damage}");
            Console.WriteLine($"Posibilidad Daño Critico (+0.05) -> {this.PosibilidadCritico}");
            Console.WriteLine($"Daño Critico (+3) -> {this.DamageCritico}");

        }

        public new void GetInformacion()
        {
            // informacion adicional
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("Daño", this.Damage.ToString());
            info.Add("Posibilidad Critico", this.PosibilidadCritico.ToString());
            info.Add("Daño Critico", this.DamageCritico.ToString());
            base.GetInformacion(info, false);
        }

        public double Damage { get => damage; set => damage = value; }
        public double PosibilidadCritico { get => posibilidadCritico; set => posibilidadCritico = value; }
        public double DamageCritico { get => damageCritico; set => damageCritico = value; }
    }
}
