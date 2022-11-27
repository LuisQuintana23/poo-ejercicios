
using Practica7;

class Program
{
    public static void Main(string[] args)
    {
        // creacion de nuevo cajero

        Cajero cajero1 = new Cajero(
            "Pancho",
            "Lopez",
            123_789,
            2
            );

        // Creacion de nuevo ejecutivo
        
        Cliente cliente1 = new Cliente(
            "Luis",
            "Quintana",
            25_000.00
            );
        
        // nueva cuenta de debito para cliente 1
        Ejecutivo ejecutivo1 = new Ejecutivo(
            "Juan",
            "Perez",
            237_890,
            3
            );
        
        bool loop = true;
        int op = 0;
        
        while(loop)
        {

            Console.Clear(); // limpiar buffer de pantalla
            
            Console.WriteLine($"\n{"BBRF", 40}");// texto centrado del menu principal
            Console.Write("\n\t1. Ejecutivo" +
                          "\n\t2. Cajero" +
                          "\n\t3. Mostrar Comisiones" +
                          "\n\t4. Datos de usuario" +
                          "\n\t9. Salir" + 
                          "\n\n: ");

            try
            {
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                   case 1: // Ejecutivo
                       Console.Clear(); // limpiar buffer de pantalla
                       ejecutivo1.AtenderCliente(cliente1);
                   break;
                   
                   case 2: // Cajero
                       Console.Clear(); // limpiar buffer de pantalla
                       cajero1.AtenderCliente(cliente1);
                   break; 
                   
                   case 3: // Mostrar comisiones
                       Console.Clear(); // limpiar buffer de pantalla
                       List<Empleado> empleados = new List<Empleado>();

                       empleados.Add(cajero1);
                       empleados.Add(ejecutivo1);

                       Empleado.GetComisionesTotales(empleados);
                        
                   break;

                   case 4: // Mostrar datos usuario
                       Console.Clear(); // limpiar buffer de pantalla
                       cliente1.MostrarDatos();
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
                //Console.WriteLine($"\tError\n\n{e}\n");

                Console.WriteLine($"\nAdvertencia: {e.Message}\n");
            }


            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadLine();

        }

    }
}
