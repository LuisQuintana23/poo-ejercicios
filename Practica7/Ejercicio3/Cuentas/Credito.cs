namespace Practica7;

public class Credito : Cuenta
{
    
    private double limiteCredito;
    private double anualidad;
    private double interesRetiro;
    private double creditoTotal;



    public Credito(int numeroCuenta) : base(numeroCuenta)
    {
        Tipo = "credito";
        
        limiteCredito = 70_000;
        creditoTotal = limiteCredito;
        anualidad = 1_076;
        interesRetiro = 0.20; // interes de 20%
    }


    public static bool CumpleRequisitos(Cliente cliente)
    {
        if (!cliente.Cuentas.ContainsKey("debito")) // si cliente no tiene al menos 5,000 en tarjeta de debito, no cumple con los requisitos
        {
            // no se dispone del suficiente efectivo
            throw new RequisitosIncumplidosException(
                "Se requiere tener una cuenta de debito para abrir una de credito");
        }

        if (cliente.Cuentas.ContainsKey("credito")) // en caso de que ya tenga una cuenta de credito
        {
            // no se dispone del suficiente efectivo
            throw new RequisitosIncumplidosException(
                "Ya cuenta con una cuenta de credito, no es necesario abrir otra");
        }
        
        if (cliente.Cuentas["debito"].Saldo < 5000) // solo se puede abrir cuentas desde $ 5,000
        { throw new FondosInsuficientesException("Se requiere por lo menos $ 5,000 en una cuenta de debito para abrir una cuenta de credito");
        }

        
        return true;
    }
    
    
    public override void RealizarDeposito(Cliente cliente, double cantidad)
    {
        // en caso de que el usuario ingrese una cantidad mayor al pago del prestamo, solo se descuenta lo del prestamo
        if (cantidad > (Saldo * -1))
            cantidad = (Saldo * -1);
        
        cliente.Efectivo -= cantidad; // Quitar lo del deposito al efectivo del cliente
        this.Saldo += cantidad; // Agregar deposito al saldo de la cuenta

        if (this.Saldo == 0) // cuando ya se salda la deuda, se vuelve al credito anterior
            this.CreditoTotal = LimiteCredito;
        else
            this.creditoTotal += cantidad; // Agregar deposito al credito que puede utilizar


        Console.WriteLine($"\nTransacción Completada.\n" +

                          $"\n{"Monto Depositado: ",20} {cantidad,20}" +
                          $"\n{"Credito Actual: ",20} {this.CreditoTotal, 20}" +
                          $"\n{"Monto a Pagar: ",20} {this.Saldo * -1, 20}" + // se multiplica por -1 para que el usuario entienda que debe pagar una cantidad positiva
                          $"\n{"Efectivo: ",20} {cliente.Efectivo,20}");
    }

    public override void RealizarRetiro(Cliente cliente, double cantidad)
    {
        // valida que no sea una cantidad negativa y que el usuario cuente con los fondos necesarios
        if (cantidad < 0 || cantidad > this.creditoTotal)
        {
            // no se dispone del suficiente efectivo
            throw new FondosInsuficientesException(
                $"No cuenta con el credito suficiente, o la cantidad no es valida");
        }


        // En caso de que si exista continua

        this.Saldo -= cantidad + (cantidad * this.interesRetiro); // lo que debe mas el interes por retiro
        this.CreditoTotal -= cantidad; // Quitar lo retirado al credito que puede disponer

        cliente.Efectivo += cantidad; // Agregar lo retirado al efectivo del cliente

        Console.WriteLine($"\nTransacción Completada.\n" +

                          $"\n{"Monto Retirado: ",20} {cantidad,20}" +
                          $"\n{"Credito Actual: ",20} {this.CreditoTotal,20}" +
                          $"\n{"Monto a Pagar: ",20} {this.Saldo * -1,20}" +
                          $"\n{"Efectivo: ",20} {cliente.Efectivo,20}");
    }
    
    // GETTERS Y SETTERS
    public double LimiteCredito
    {
        get => limiteCredito;
        protected set => limiteCredito = value;
    }
    
    
    public double CreditoTotal
    {
        get => creditoTotal;
        protected set => creditoTotal = value;
    }


}