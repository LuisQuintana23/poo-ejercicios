namespace Practica7;

public class Debito : Cuenta
{
    public Debito(int numeroCuenta, double saldo) : base(numeroCuenta)
    {
        if (saldo < 1000) // solo se puede abrir cuentas desde $ 1,000
        {
            throw new FondosInsuficientesException("Se requiere por lo menos $ 1,000 para abrir una cuenta de debito");
        }
        
        Saldo = saldo;
        Tipo = "debito";
    }


    public static bool CumpleRequisitos(Cliente cliente)
    {
        
        if (cliente.Cuentas.ContainsKey("debito")) // en caso de que ya tenga una cuenta de debito
        {
            // no se dispone del suficiente efectivo
            throw new RequisitosIncumplidosException(
                "Ya cuenta con una cuenta de debito, no es necesario abrir otra");
        }

        if (cliente.Efectivo < 1000)
        {
            // no se dispone del suficiente efectivo
            throw new RequisitosIncumplidosException(
                "Se requiere por lo menos $1,000 para abrir una cuenta");
        }

        return true;
    }
    
    public override void RealizarDeposito(Cliente cliente, double cantidad)
    {
        // En caso de que si exista continua
        
        cliente.Efectivo -= cantidad; // Quitar lo del deposito al efectivo del cliente
        cliente.Cuentas[tipo].Saldo += cantidad; // Agregar deposito al saldo de la cuenta
        
        Console.WriteLine($"\nTransacción Completada.\n" +
                          
                          $"\n{"Monto Depositado: ", 20} {cantidad, 20}" +
                          $"\n{"Saldo Actual: ", 20} {cliente.Cuentas[tipo].Saldo, 20}" +
                          $"\n{"Efectivo: ", 20} {cliente.Efectivo, 20}");
    }

    public override void RealizarRetiro(Cliente cliente, double cantidad)
    {

        // valida que no sea una cantidad negativa y que el usuario cuente con los fondos necesarios
        if (cantidad < 0 || cantidad > this.Saldo) 
        { 
            // no se dispone del suficiente efectivo
            throw new FondosInsuficientesException(
                $"Debito no cuenta con el saldo suficiente, o la cantidad no es valida");
        }

        // En caso de que si exista continua
        
        cliente.Cuentas["debito"].Saldo -= cantidad; // Quitar lo retirado al saldo de la cuenta
        cliente.Efectivo += cantidad; // Agregar lo retirado al efectivo del cliente
        
        Console.WriteLine($"\nTransacción Completada.\n" +
                          
                          $"\n{"Monto Retirado: ", 20} {cantidad, 20}" +
                          $"\n{"Saldo Actual: ", 20} {cliente.Cuentas[tipo].Saldo, 20}" +
                          $"\n{"Efectivo: ", 20} {cliente.Efectivo,20}");
        
    } 
    
}