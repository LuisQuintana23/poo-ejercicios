using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;

namespace Practica7;

public class Ejecutivo : Empleado
{
    private int numEjecutivo;
    
    public Ejecutivo(string nombre, string apellido, int numeroTrabajador, int numEjecutivo) : base(nombre, apellido, numeroTrabajador)
    {
        this.numEjecutivo = numEjecutivo;
        comision = (0.001/100); // 0.001%
    }

    public override void AtenderCliente(Cliente cliente)
    {
        // abrir cuenta
        Console.WriteLine($"Atendiendo a: {cliente.Nombre}");
        // Opcioens
        
        Console.Write("\n\t1. Abrir Cuenta" +
                      "\n\t2. Abrir Fondo De Inversion" +
                      "\n\n: ");
        
        int op = int.Parse(Console.ReadLine());

        switch (op)
        {
            case 1: // Abrir Cuenta
                AbrirCuenta(cliente);
                break;
            
            case 2: // Abrir Fondo de inversion
                AbrirFondo(cliente);
                
                break;
            
            default:
                Console.WriteLine("Opcion no valida");
                break;
        }
    }

    public void AbrirCuenta(Cliente cliente)
    {
        Console.WriteLine("\nSelecciona el tipo de cuenta a abrir");
        Console.Write("\n\tDebito" +
                      "\n\tCredito" +
                      "\n\tPrestamo" +
                      "\n\n: ");

        string opTipo = Console.ReadLine().ToLower();
        
        switch (opTipo)
        {
            case "debito":
                if (Debito.CumpleRequisitos(cliente)){
                    cliente.Efectivo -= 1000; // quitar lo del deposito al efectivo del cliente
                    Debito cuentaDebito = new Debito(
                        Cuenta.GenerarNumeroCuenta(1_000_000, 2_000_000),
                        1_000 // saldo minimo para abrir cuenta de debito
                        );
                    
                    cliente.Cuentas.Add(opTipo, cuentaDebito); // se agrega la cuenta a sus cuentas
                    
                    // MENSAJE DE CUENTA GENERADA
                    Console.WriteLine($"\nSe ha creado la cuenta exitosamente\n" +
                                      $"\n\tPropietario: {cliente.Nombre}" +
                                      $"\n\tNumero de cuenta: {cuentaDebito.NumeroCuenta}" +
                                      $"\n\tSaldo: {cuentaDebito.Saldo}");
                }

                // obtener comision por cuenta abierta
                this.ObtenerComision(1000);
                
                break;
            
            case "credito":
                
                if (Credito.CumpleRequisitos(cliente)){
                    Credito cuentaCredito = new Credito(
                        Cuenta.GenerarNumeroCuenta(2_000_000, 3_000_000)
                        );
                    
                    cliente.Cuentas.Add(opTipo, cuentaCredito); // se agrega la cuenta a sus cuentas
                    
                    // MENSAJE DE CUENTA GENERADA
                    Console.WriteLine($"\nSe ha creado la cuenta exitosamente\n" +
                                      $"\n\tPropietario: {cliente.Nombre}" +
                                      $"\n\tNumero de cuenta: {cuentaCredito.NumeroCuenta}" +
                                      $"\n\tCredito Disponible: {cuentaCredito.LimiteCredito}\n");
                } 

                this.ObtenerComision(5_000); // para abrir un credito se requiere de 5,000 en debito, es por ello que se lleva esa comision
                break;
            
            case "prestamo":
                int cuotas;
                double cantidadSolicitada = 0;

                if (Prestamo.CumpleRequisitos(cliente)){

                    Console.Write("\nIngrese la cantidad para el prestamo: ");
                    cantidadSolicitada = Double.Parse(Console.ReadLine());

                    if (cantidadSolicitada <= 0 || cantidadSolicitada > 1_000_000)
                    {
                        throw new FondosInsuficientesException(
                            "Cantidad invalida"
                            );
                    }

                    // dependiendo de la cantidad seran las cuotas a pagar
                    if (cantidadSolicitada < 10_000)
                        cuotas = 12;
                    else if(cantidadSolicitada < 50_000)
                        cuotas = 18;
                    else if(cantidadSolicitada < 250_000)
                        cuotas = 24;
                    else
                        cuotas = 30;

                    Prestamo cuentaPrestamo = new Prestamo(
                        Cuenta.GenerarNumeroCuenta(3_000_000, 4_000_000),
                        cantidadSolicitada,
                        cuotas
                        );

                    cliente.Cuentas.Add(opTipo, cuentaPrestamo); // se agrega la cuenta a sus cuentas
                    
                    // MENSAJE DE CUENTA GENERADA
                    Console.WriteLine($"\nSe ha creado la cuenta exitosamente\n" +
                                      $"\n\tPropietario: {cliente.Nombre}" +
                                      $"\n\tNumero de cuenta: {cuentaPrestamo.NumeroCuenta}" +
                                      $"\n\tCantidad a prestar: {cuentaPrestamo.Prestado}\n");
                } 

                this.ObtenerComision(cantidadSolicitada); // para abrir un prestamo se requiere de 25,000 en debito, es por ello que se lleva esa comision

                Console.WriteLine("\nPuede retirar su prestamo en la caja\n");

                break;
            
            default:
                Console.WriteLine("Opcion no valida");
                break;

        }


    }

    public void AbrirFondo(Cliente cliente)
    {
        if (FondoInversion.CumpleRequisitos(cliente))
            {
            Console.Write("\n¿Cuánto desea invertir?: ");
            
            double monto = Double.Parse(Console.ReadLine());

            if (monto < 0 || monto > cliente.Efectivo)
            {
                throw new FondosInsuficientesException(
                    "No cuentas con fondos suficientes para invertir"
                    );
            }

            Console.WriteLine("\nSeleccione el tipo de fondo a abrir");
            Console.Write("\n\t1. Monetario       (Bajo riesgo)" +
                          "\n\t2. Renta Fija      (Mediano riesgo)" +
                          "\n\t3. Renta Variable  (Bajo riesgo)" +
                          "\n: ");

            int tipo = int.Parse(Console.ReadLine());
            double montoFinal = 0;

            switch (tipo)
            {
                case 1:
                    cliente.Efectivo -= monto;
                    Monetario inversion1 = new Monetario(monto);

                    montoFinal = inversion1.Invertir();
                    cliente.Efectivo += montoFinal;

                    Console.WriteLine($"\n{"Monto Ingresado", 15} {monto, 20}");
                    Console.WriteLine($"{"Monto Final", 15} {montoFinal, 20:N2}");
                    break;

                case 2:
                    cliente.Efectivo -= monto;
                    RentaFija inversion2 = new RentaFija(monto);

                    montoFinal = inversion2.Invertir();
                    cliente.Efectivo += montoFinal;

                    Console.WriteLine($"\n{"Monto Ingresado", 15} {monto, 20}");
                    Console.WriteLine($"{"Monto Final", 15} {montoFinal, 20:N2}");
                    break;

                case 3:
                    cliente.Efectivo -= monto;
                    RentaVariable inversion3 = new RentaVariable(monto);

                    montoFinal = inversion3.Invertir();
                    cliente.Efectivo += montoFinal;

                    Console.WriteLine($"\n{"Monto Ingresado", 15} {monto, 20}");
                    Console.WriteLine($"{"Monto Final", 15} {montoFinal, 20:N2}");
                    break;

                default:
                    Console.WriteLine("Elección invalida");
                    break;

            }

            // si el la inversion genero ingresos se genera comision
            if (montoFinal > monto)
                this.ObtenerComision(montoFinal);
            else
                this.ObtenerComision(0);

        }
    }

}