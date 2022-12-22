using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Objetos
{
    public class Pocion:Objeto
    {
        public Pocion(string nombre, int nivel, string clase, double durabilidad) : base(nombre, nivel, clase, durabilidad)
        {
            this.Durabilidad = double.MaxValue;
        }

    }


    public class PocionCuracion : Pocion
    {
        private double vidaExtra;

        public PocionCuracion(string nombre, int nivel, string clase, double durabilidad, double vidaExtra) : base(nombre, nivel, clase, durabilidad)
        {
            this.vidaExtra = vidaExtra;
        }

        
        public double VidaExtra
        {
            get => vidaExtra;
            set => vidaExtra = value;
        }
    }
}
