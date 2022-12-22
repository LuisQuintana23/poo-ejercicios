using ConsoleTables;
using Ejercicio4.Personajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Objetos
{
    public abstract class Objeto
    {
        private string nombre;
        private int nivel;
        private string clase; // legendario; epico; raro; comun
        private double durabilidad; 
        private bool consumible; 
        private double puntosMejoraNecesarios; // puntos necesarios para mejorar 
        private double precio;

        public Objeto(string nombre, int nivel, string clase, double durabilidad)
        {
            this.nivel = nivel;
            this.clase = clase; // la clase no cambia
            this.durabilidad = durabilidad;
            this.nombre = nombre;
            this.setPrecio(); // establece el precio segun su clase
        }


        public void Mejorar(int puntosMejora)
        {
            // verificar puntos de mejora de heroe
            if (puntosMejora < PuntosMejoraNecesarios)
            {
                Console.WriteLine($"Puntos de mejora insuficientes, regresa cuando tengas por lo menos {puntosMejoraNecesarios}");
                return;
            }

            Console.WriteLine();

            Console.WriteLine("Mejorando...");
            using (var progreso = new ProgressBar())
            {
                for (int i = 0; i <= 100; i++)
                {
                    progreso.Report((double)i / 100);
                    Thread.Sleep(5);
                }
            }

            this.Nivel++;
            this.Durabilidad+=50;
            
            Console.WriteLine($"Se ha mejorado {this.Nombre}") ;
            Console.WriteLine($"Nivel (+1) -> {this.Nivel}");
            Console.WriteLine($"Durabilidad (+50) -> {this.Durabilidad}");

            // aumentar puntos de mejora necesarios

            PuntosMejoraNecesarios *= 2; // se duplican
        }


        public void GetInformacion(Dictionary<string, string>? info, bool repetirTitulo)
        {
            var tabla = new ConsoleTable("Nombre", "Nivel", "Clase", "Durabilidad", "Precio");

            if (info != null)
            {
                string[] att = { this.nombre.ToString(), this.nivel.ToString(), this.clase.ToString(), this.durabilidad.ToString(), this.precio.ToString()};
                string[] attExtras = info.Values.ToArray(); // convierte los valores del diccionario a un array de strings
                string[] valores = att.Concat(attExtras).ToArray(); // agrega los atributos extras a los atributos originales

                tabla.AddColumn(info.Keys); // acepta el objeto IEnumerable
                tabla.AddRow(valores); // como no acepta IEnumerable, se debe convertir a array
            }
            else
            {
                tabla.AddRow(this.nombre, this.nivel, this.clase, this.durabilidad, this.precio);
            }

            tabla.Write(Format.Minimal);

        }

        public void setPrecio()
        {
            if (this.clase == "Comun")
            {
                this.precio = 20;
            } 
            else if(this.clase == "Rara" )
            {
                this.precio = 60;
            }
            else if(this.clase == "Epica" )
            {
                this.precio = 100;
            }
            else if(this.clase == "Legendaria" )
            {
                this.precio = 100;
            }
            else // en caso de que no se encuntre en alguna de estas clases
            {
                this.precio = Double.MaxValue;
            }
        }

        public System.Collections.IEnumerable GetValores(Dictionary<string, string> info)
        {
            foreach(var value in info.Values)
            {
                yield return value;
            }
        }

        public int Nivel { get => nivel; set => nivel = value; }
        public string Clase { get => clase; set => clase = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Durabilidad { get => durabilidad; set => durabilidad = value; }
        public bool Consumible { get => consumible; set => consumible = value; }
        public double PuntosMejoraNecesarios { get => puntosMejoraNecesarios; set => puntosMejoraNecesarios = value; }
    }
}
