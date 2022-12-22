using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4.Objetos
{
    public class Inventario:Objeto
    {
        private List<Objeto> objetos;
        private int capacidad; // numero de objetos que se pueden almacenar


        public Inventario(string nombre, int nivel, string clase, double durabilidad, int capacidad) : base(nombre, nivel, clase, durabilidad)
        {
            this.capacidad = capacidad;

            this.objetos = new List<Objeto>();
            this.Consumible = false;
        }


        public void AgregarObjeto(Objeto obj)
        {
            if (IsFull())
            {
                Console.WriteLine("Mochila llena, no se pueden agregar más objetos, elimina algunos.");
                return;
            }

            // en caso de que no este llena la mochila
            objetos.Add(obj);
            Console.WriteLine($"Objeto {obj.Nombre} agregado");


            return;

        }
        public void EliminarObjeto(Objeto obj)
        {
            if (!objetos.Contains(obj)) // si no contiene al objeto
            {
                Console.WriteLine("El objeto no existe en el inventario");
                return;
            }

            if (IsEmpty())
            {
                Console.WriteLine("El inventario ya se encuentra vacio");
                return;
            }

            // en caso de que no este llena la mochila
            objetos.Add(obj);
            Console.WriteLine($"Objeto {obj.Nombre} agregado");


            return;

        }


        public bool IsFull()
        {
            if (objetos.Count < capacidad) // en caso de que aun quede algun espacio
                return false;

            return true; // si ya esta llena es true
        }
        public bool IsEmpty()
        {
            if (objetos.Count != 0)
                return false;

            return true; // si es igual a 0 es true
        }


        public void MostrarInventario()
        {
            Console.WriteLine($"{"Inventario",40}");

            foreach(Objeto obj in objetos)
            {
                obj.GetInformacion(null, false);
            }

            if (IsEmpty())
            {
                Console.WriteLine("\nInventario Vacio\n");
            }
        }

        public new void Mejorar(int puntosMejora)
        {
            base.Mejorar(puntosMejora);

            this.capacidad+=1;
            
            Console.WriteLine($"Capacidad (+1) -> {this.Capacidad}");

        }
        public new void GetInformacion()
        {
            // informacion adicional
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("Capacidad", this.Capacidad.ToString());
            base.GetInformacion(info, false);
        }


        public List<Objeto> Objetos { get => objetos; set => objetos = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public double Durabilidad { 
            get => Durabilidad;
            set
            {
                Durabilidad = double.MaxValue;
            } 
        }
    }
}
