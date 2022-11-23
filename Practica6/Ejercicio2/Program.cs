namespace Ejercicio2;

class Program
{
    public static void Main(string[] args)
    {
        // Crear 5 productos (ya existentes)

        Producto p1 = new Producto("Alpura",
                                   "1234567890",
                                    28.00,
                                   "Lacteo",
                                   true,
                                   DateTime.Now.AddDays(2)); // se caduca en dos dias
        
        Producto p2 = new Producto("Barbie",
                                   "1283642748",
                                    300.00,
                                   "Juguete",
                                   false,
                                   DateTime.MinValue);
        
        Producto p3 = new Producto("Frijoles",
                                   "1487629809",
                                    14.00,
                                   "Legumbre",
                                   true,
                                   DateTime.Now.AddDays(5));
        
        Producto p4 = new Producto("Valentina",
                                   "2782129472",
                                    10.00,
                                   "Salsas",
                                   true,
                                   DateTime.Now.AddDays(1));
        
        Producto p5 = new Producto("Bicicleta",
                                   "8921736482",
                                    4000.00,
                                   "Vehiculo",
                                   false,
                                   DateTime.MinValue);

        Inventario inventario = new Inventario();
        
        //agregar productos al inventario
        inventario.stock.Add(1, p1);
        inventario.stock.Add(2, p2);
        inventario.stock.Add(3, p3);
        inventario.stock.Add(4, p4);
        inventario.stock.Add(5, p5);

        bool loop = true;
        int op = 0;
        
        inventario.VerificarFechas();
        
        while(loop)
        {

            Console.Clear(); // limpiar buffer de pantalla
            
            string notificacion = inventario.actualizados.Count != 0? (inventario.actualizados.Count + " producto(s) casi vencidos") : "Productos Actualizados";
            string productosVencer = inventario.getProductosCasiVencidos();
            
            Console.WriteLine($"\n{"Tiendita", 40} {Convert.ToChar(187), 10} {notificacion}");// texto centrado del menu principal
            Console.WriteLine($"{productosVencer}"); // productos proximos a vencer
            Console.Write("\t1. Ver productos" +
                              "\n\t2. Ingresar Producto" +
                              "\n\t3. Actualizar inventario" +
                              "\n\t4. Verificar fechas de caducidad" +
                              "\n\t9. Salir" + 
                              "\n\n:");

            try
            {
                op = int.Parse(Console.ReadLine());
                switch (op)
                {
                   case 1: // Ver productos
                       inventario.VerProductos();
                   break;
                   
                   case 2: // ingresar productos
                       Console.WriteLine($"\n{"Ingresar Producto", 20}");
                       Producto producto = inventario.IngresarProducto();
                       
                       // asigna como clave el siguiente id con el valor del producto
                       inventario.AgregarInventario( inventario.stock.Count+1, producto);
                   break; 
                   
                   case 3: // actualizar inventario
                       inventario.ActualizarInventario();
                   break;
                   
                   case 4: // verificar fechas de caducidad
                       inventario.VerificarFechas();
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
                Console.WriteLine(e.Message); // muestra solo el mensaje de la excepcion
            }
            
            
            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadLine();

        }
    }
}