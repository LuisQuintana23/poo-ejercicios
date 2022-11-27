namespace Practica7;

public abstract class Cuenta
{

    protected string tipo;
    private int numeroCuenta;
    protected double saldo;
    

    public Cuenta(int numeroCuenta)
    {
        this.numeroCuenta = numeroCuenta;
    }

    public static int GenerarNumeroCuenta(int min, int max)
    {
        // ayuda a generar numeros de cuenta a partir del tipo
        Random seed = new Random(10);
        return seed.Next(min, max); // toma los numeros de cuenta generado por cada tipo de cuenta: debito, credito, etc.
    }
    
    
    // GETTERS y SETTERS
    public int NumeroCuenta => numeroCuenta;
    public virtual double Saldo
    {
        get => saldo;
        set => saldo = value;
    }
    
    public string Tipo
    {
        /* TIPOS
            - debito
            - credito
            - prestamo
            - fondoInversion 
         */
        get => tipo;
        protected set => tipo = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    
    public abstract void RealizarDeposito(Cliente cliente, double cantidad);
    public abstract void RealizarRetiro(Cliente cliente, double cantidad);
    
    
}