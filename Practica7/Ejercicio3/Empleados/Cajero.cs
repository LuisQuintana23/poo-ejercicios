namespace Practica7;

public class Cajero : Empleado
{
    private int numVentanilla;
    private const int spaceTipoCuenta = 5;
    private const int spaceNumeroCuenta = 50;
    
    public Cajero(string nombre, string apellido, int numeroTrabajador, int numVentanilla) : base(nombre, apellido, numeroTrabajador)
    {
        this.numVentanilla = numVentanilla;
        comision = (0.0001/100); // 0.0001%
    }


    public override void AtenderCliente(Cliente cliente)
    {
        Console.WriteLine($"{"Atendiendo a ",5} {cliente.Nombre} {"Ventanilla: ", 15} {this.numVentanilla}");
        // verificar exitencia de cuenta

        if (cliente.Cuentas.Count == 0) // si el usuario no tiene una cuenta
        {
            throw new NingunaCuentaException("Aun no existe alguna cuenta, un ejecutivo puede abrir una");
        }
        
        Console.WriteLine("Ingrese la accion a realizar");
        Console.Write("\n\t1. Realizar Deposito" +
                          "\n\t2. Realizar Retiro\n" +
                          "\n: ");
        
        int op = int.Parse(Console.ReadLine());
        string opTipo;

        switch (op)
        {
            case 1: // raalizar deposito
                Console.WriteLine("\n¿A que cuenta desea realizar el deposito?\n");

                // Mostrar cuentas
                Console.WriteLine($"\n{"Tipo", 10} {"Numero de cuenta", 25}");
                foreach (var (tipoCuenta, cuenta) in cliente.Cuentas) {
                    Console.WriteLine($"{Utilidades.Capitalize(cuenta.Tipo), 10} {cuenta.NumeroCuenta, 25}");
                }

                Console.Write("\nSeleccione el tipo de cuenta: ");
                opTipo = Console.ReadLine();
                opTipo = opTipo.ToLower();

                // si el tipo de cuenta no existe se levanta el error
                if (!cliente.Cuentas.ContainsKey(opTipo))
                    throw new CuentaNoEncontrada($"No existe una cuenta de tipo {opTipo}");


                // si existe la cuenta continua

                Console.Write("\nCantidad a depositar: ");
                double deposito = Double.Parse(Console.ReadLine());
                // valida que no sea una cantidad negativa y que el usuario cuente con los fondos necesarios
                if (deposito < 0 || deposito > cliente.Efectivo)
                {
                    // no se dispone del suficiente efectivo
                    throw new FondosInsuficientesException(
                        "No cuenta con fondos suficientes, o la cantidad no es valida");
                }


                // en caso de que si exista continua y realiza el deposito
                cliente.Cuentas[opTipo].RealizarDeposito(
                    cliente: cliente,
                    cantidad: deposito
                    );

                // en caso de liquidar el prestamo se elimina de las cuentas del usuario para que pueda solicitar otro
                if (opTipo == "prestamo" && cliente.Cuentas[opTipo].Saldo == 0 )
                {
                    cliente.Cuentas.Remove(opTipo); // quita el prestamo del usuario
                    Console.WriteLine("\nSu prestamo ha sido pagado, puede solicitar otro");
                }

                this.ObtenerComision(deposito);
                break;

            case 2: // realizar retiro

                double retiro = 0;

                // en caso de que si se cumpla con los fondos
                Console.WriteLine("\n¿A que cuenta desea realizar el retiro?");

                // Mostrar cuentas
                Console.WriteLine($"\n{"Tipo", 10} {"Numero de cuenta", 25}");
                foreach (var (tipoCuenta, cuenta) in cliente.Cuentas) {
                    Console.WriteLine($"{Utilidades.Capitalize(cuenta.Tipo), 10} {cuenta.NumeroCuenta, 25}");
                }

                Console.Write("\nSeleccione el tipo de cuenta: ");

                opTipo = Console.ReadLine();
                opTipo = opTipo.ToLower();

                // si el tipo de cuenta no existe se levanta el error
                if (!cliente.Cuentas.ContainsKey(opTipo))
                    throw new CuentaNoEncontrada($"No existe una cuenta de tipo {opTipo}");

                // para el prestamo no se necesita colocar la cantidad ya que se le dara en una sola exhibicion

                if (opTipo != "prestamo") {
                    Console.Write("\nCantidad a retirar: ");
                    retiro = Double.Parse(Console.ReadLine());
                }

                
                // en caso de que si exista continua y realiza el deposito
                cliente.Cuentas[opTipo].RealizarRetiro(
                    cliente: cliente,
                    cantidad: retiro
                    );

                this.ObtenerComision(retiro);
                break;
            
            default:
                Console.WriteLine("\nOpcion no valida");
                break;
            
        }
            
    }


    
}