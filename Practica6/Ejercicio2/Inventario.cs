namespace Ejercicio2;


public class Inventario
{
    public Dictionary<int, Producto> stock;

    public List<int> actualizados;


    public Inventario()
    {
        this.stock = new Dictionary<int, Producto>();
        this.actualizados = new List<int>();
    }

    public void VerProductos()
    {
        int id = 1;
        // Numeros de espacios para la vista en tabla, basta con modificarlos para
        // que tambien se modifique el valor de los titulos y los valores
        // los valores deben ser constantes para que los acepte el formato
        const int spaceId = 1;
        const int spaceNombre = 15;
        const int spaceCodigoBarras = 18;
        const int spaceCosto = 10;
        const int spaceTipo = 15;
        const int spacePerecedero = 12;
        const int spaceCaducidad = 20;
        
        Console.WriteLine($"\n{"Id", spaceId} {"Nombre", spaceNombre} {"Codigo de Barras", spaceCodigoBarras} {"Costo", spaceCosto} {"Tipo", spaceTipo} {"Perecedero", spacePerecedero} {"Fecha Caducidad", spaceCaducidad}");
        foreach (var (idItem, item) in stock)// itera los libros prestados
        {
            Console.WriteLine($"{idItem, spaceId} {item.nombre, spaceNombre} {item.codigoBarras, spaceCodigoBarras} {item.costo, spaceCosto:N2} {item.tipo, spaceTipo} {item.perecedero, spacePerecedero} {item.FechaCaducidad, spaceCaducidad}");
            id++;

        }
    }

    public void ActualizarInventario()
    {
        //Mostrar productos
        VerProductos();
        Console.Write("\nIngresa el id del producto a modificar: ");
        int id = int.Parse(Console.ReadLine());
       
        //Crear producto 'nuevo'
        Producto productoModificado = IngresarProducto();
        // Agregar al stock
        AgregarInventario(id, productoModificado);
        
    }

    public void AgregarInventario(int id, Producto producto)
    {

        stock.Remove(id); // retira el anterior producto (en caso de que exista) e ingresa el nuevo
        stock.Add(id, producto); // ingresa el producto modificado en el indice del viejo
        
        VerificarFechas();
    } 
    
    public void VerificarFechas()
    {
        foreach (var (id, item) in stock) // verifica cada producto
        {
            
            DateTime hoy = DateTime.Today;
            int dias = (item.FechaCaducidad - hoy).Days;

            bool loopCaducado = true;

            // no ingresa si es no perecedero
            while (loopCaducado && dias <= 0 && item.perecedero)
            {
                // si dias es negativo o igual a 0 , es que ya caduco y se debe actualizar el inventario
                Console.WriteLine($"Por favor, actualice el producto caducado con el id {id}");
                try
                {
                    /* si no se coloca este try, el usuario puede colocar un dato mal y no actualizar el producto
                       por lo que lo regresara al menu
                    */
                    
                    ActualizarInventario();
                }
                catch (FormatException) // en caso de no colocar bien el dato ya sea en el costo o en el numero de digitos del codigo de barras
                {
                    Console.WriteLine("Ingrese los datos correctamente");
                    Console.WriteLine("\nPulse cualquier tecla para continuar...");
                    Console.ReadLine();
                    continue; // no ejecutara la siguientes instrucciones y repetira el ciclo
                }
                
                // se debe trabajar con this.stock[id] ya que item no estaria actualizado aun
                // y stock[id] ya lo estari
                dias = (this.stock[id].FechaCaducidad - hoy).Days;

                if (dias > 0) // se rompe el bucle en caso de que ya se tenga una nueva fecha mayor a 0 dias a caducar
                {
                    loopCaducado = false;
                }
                
            }

            // si es 0 es su ultimo dia
            
            /* en dado caso de que un producto que faltaban 3 dias o menos para
            caducarse y se actualizo su fecha a una con mayor numero de dias
            restantes, es necesario quitar su id de los actualizados
            */
            
            if (dias > 3) actualizados.Remove(id);
            
             // si el id no ha sido actualizado y es perecedero y dias es menor o igual a 3
            if (!actualizados.Contains(id) && item.perecedero && dias <= 3){
                item.ActualizarCosto(dias); // actualizara el costo en funcion de los dias que le falten
                actualizados.Add(id); //Agregar id a actualizados     
            }
            
        }
        
    }

    
    public Producto IngresarProducto()
    {
        Console.Write("\nNombre: ");
        string nombre = Capitalize(Console.ReadLine());
        
        Console.Write("Codigo de Barras: ");
        string codigoBarras = Console.ReadLine();

        if (codigoBarras.Length != 10)
        {
            throw new FormatException("El código de barras debe ser de 10 dígitos");
        }
        
        Console.Write("Costo: ");
        double costo = Double.Parse(Console.ReadLine());
        
        Console.Write("Tipo: ");
        string tipo = Capitalize(Console.ReadLine());
        
        Console.Write("Perecedero?[si/no]: ");
        string perecederoStr = Console.ReadLine();
        
        bool perecedero = false; // coloca por defecto no perecedero hasta que pase la validacion del string perecederoStr

        DateTime fechaCaducidad = DateTime.MinValue;
        
        if (perecederoStr.ToLower().Equals("si"))
        {
            perecedero = true;
            
            // solicita fecha de caducidad
            Console.Write("\nFecha de caducidad");
            Console.Write("\nAño: ");
            int año = int.Parse(Console.ReadLine());
            Console.Write("Mes: ");
            int mes = int.Parse(Console.ReadLine());
            Console.Write("Dia: ");
            int dia = int.Parse(Console.ReadLine());
            
            fechaCaducidad = new DateTime(año, mes, dia);
        }
        
        

        
        Producto producto = new Producto(nombre,
                                        codigoBarras,
                                        costo,
                                        tipo,
                                        perecedero,
                                        fechaCaducidad);


        return producto;
    }

    public string getProductosCasiVencidos()
    {
        string notificacion = "";
        
        foreach (var (id, item) in this.stock)
        {
            DateTime hoy = DateTime.Today;
            int dias = (item.FechaCaducidad - hoy).Days;

            if (dias <= 3 && item.perecedero)
                // si se caduca en 3 dias o menos y ademas si es perecedero, entonces...
            {
                notificacion = notificacion + $"{Convert.ToChar(183) + $" {id}", 54}. {item.nombre} {dias} dia(s)\n";
            }
            
        } 


        return notificacion;
    }
    
    public static string Capitalize(string word) // la primera letra la convierte a mayuscula, lo demas a minuscula
    {
        return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
    }

}