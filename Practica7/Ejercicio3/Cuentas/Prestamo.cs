namespace Practica7;

public class Prestamo : Cuenta
{
    private double intereses;
    private double prestado;
    private int cuotas; // los pagos se deben realizar en n cuotas
    private double pagoMinimo; //pago minimo para cubrir la cuota
    private int cuotasRestantes;
    private bool retirado;

    public Prestamo(int numeroCuenta, double prestado, int cuotas) : base(numeroCuenta) { 

        Tipo = "prestamo";

        this.Cuotas=cuotas;
        this.Prestado=prestado;
        this.Intereses = 0.40; // interes de 40%
        this.retirado=false; // se crea el prestamo pero el usuario puede retirar cuando quiera
        // la deuda termia cuanto el saldo esta en 0
        Saldo = (prestado + (prestado * Intereses)) * -1; // -1 para que al momento de depositar se sume por lo tanto se acerque el pago de la deuda mas a 0 (deuda saldada)
        PagoMinimo = (Saldo * -1)/Cuotas; // -1 para que se vuelva positivo el pago que debe cubrir
        CuotasRestantes = cuotas;

    }


    public static bool CumpleRequisitos(Cliente cliente)
    {
        if (!cliente.Cuentas.ContainsKey("debito")) // si cliente no tiene al menos 5,000 en tarjeta de debito, no cumple con los requisitos
        {
            // no se dispone del suficiente efectivo
            throw new RequisitosIncumplidosException(
                "Se requiere tener una cuenta de debito para abrir un prestamo");
        }

        if (cliente.Cuentas.ContainsKey("prestamo")) // en caso de que ya tenga una cuenta de credito
        {
            // no se dispone del suficiente efectivo
            throw new RequisitosIncumplidosException(
                "Ya cuenta con una cuenta de prestamo");
        }
        
        if (cliente.Cuentas["debito"].Saldo < 25000) // solo se puede abrir cuentas desde $ 25,000
        { throw new FondosInsuficientesException("Se requiere por lo menos $ 25,000 en una cuenta de debito para abrir una cuenta de prestamo");
        }

        return true;
    }

    public override void RealizarDeposito(Cliente cliente, double cantidad)
    {

        // valida que no sea una cantidad negativa y que el usuario cuente con los fondos necesarios
        if (cantidad < 0 || cantidad < PagoMinimo)
        {
            // no se dispone del suficiente efectivo
            throw new FondosInsuficientesException(
                $"No cuenta con el efectivo suficiente para cubrir la cuota minima, o la cantidad no es valida");
        }

        // en caso de que el usuario ingrese una cantidad mayor al pago del prestamo, solo se descuenta lo del prestamo
        if (cantidad > (Saldo * -1))
            cantidad = (Saldo * -1);

        // En caso de que si exista continua
        cliente.Efectivo -= cantidad; // Quitar lo del deposito al efectivo del cliente

        this.Saldo += cantidad; // Agregar deposito al saldo de la cuenta, como es negtivo y se suma, entonces la deuda baja

        this.CuotasRestantes--; // se resta una cuota a pagar


        Console.WriteLine($"\nTransacción Completada.\n" +

                          $"\n{"Monto Depositado: ",20} {cantidad,20}" +
                          $"\n{"Monto a pagar: ",20} {this.Saldo * -1, 20}" +
                          $"\n{"Cuotas Restantes",20} {this.CuotasRestantes, 20}" +
                          $"\n{"Efectivo: ",20} {cliente.Efectivo,20}");
    }


    // solo se podra hacer una vez
    public override void RealizarRetiro(Cliente cliente, double cantidad)
    {
        if (retirado) { // si ya se retiro lo prestado ya no se vuelve a retirar
            Console.WriteLine("Ya se ha retirado todo lo prestado");
            return; // corta la ejecucion
        }

        // En caso de que se el primer retiro
        cliente.Efectivo += Prestado; // Agregar lo retirado al efectivo del cliente
        retirado = true;

        Console.WriteLine($"\nTransacción Completada.\n" +

                          $"\n{"Monto Retirado: ",20} {cantidad, 20}" +
                          $"\n{"Monto a pagar: ",20} {this.Saldo * -1, 20}" +
                          $"\n{"Cuotas Restantes",20} {this.CuotasRestantes, 20}" +
                          $"\n{"Efectivo: ",20} {cliente.Efectivo, 20}");

    }
    
    // GETTERS Y SETTERS
    
    public int Cuotas { get => cuotas; protected set => cuotas = value; }
    public double Prestado { get => prestado; protected set => prestado = value; }
    public double Intereses { get => intereses; set => intereses = value; }
    public double PagoMinimo { get => pagoMinimo; set => pagoMinimo = value; }
    public int CuotasRestantes { get => cuotasRestantes; set => cuotasRestantes = value; }
}