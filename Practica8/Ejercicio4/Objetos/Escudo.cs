using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Objetos
{
    public class Escudo:Objeto
    {
        public static Escudo escudoGenerico = new Escudo("Escudo Basico",
                                                  1,
                                                  "Comun",
                                                  5.00,
                                                  5.00,
                                                  0); // por si no se ingres un escudo este se setea como su escudo
        private double proteccion;
        private double posibilidadAtaqueNulo; // parar por completo un ataque enemigo

        public Escudo(string nombre, 
                      int nivel, 
                      string clase, 
                      double durabilidad,
                      double proteccion,
                      double posibilidadAtaqueNulo) : base(nombre, nivel, clase, durabilidad)
        {
            this.proteccion = proteccion;
            this.posibilidadAtaqueNulo = posibilidadAtaqueNulo;
            PuntosMejoraNecesarios = 1;
        }

        public new void Mejorar(int puntosMejora)
        {
            base.Mejorar(puntosMejora);

            this.proteccion+=4;
            this.posibilidadAtaqueNulo+=0.04;
            
            Console.WriteLine($"Proteccion (+4) -> {this.Proteccion}");
            Console.WriteLine($"Posibilidad Ataque Nulo(+0.05) -> {this.PosibilidadAtaqueNulo}");

        }
        public new void GetInformacion()
        {
            // informacion adicional
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("Proteccion", this.Proteccion.ToString());
            info.Add("P. Ataque Nulo ", this.PosibilidadAtaqueNulo.ToString());
            base.GetInformacion(info, false);
        }



        public double Proteccion { get => proteccion; set => proteccion = value; }
        public double PosibilidadAtaqueNulo { get => posibilidadAtaqueNulo; set => posibilidadAtaqueNulo = value; }
    }

}
