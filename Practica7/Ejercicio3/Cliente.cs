namespace Practica7;

public class Cliente
{

    
    private string nombre;
    private string apellido;
    private int numeroCuenta;
    private double efectivo; // independiente al dinero en cuentas

    private Dictionary<string, Cuenta> cuentas; // puede tener multiples cuentas
    // string - debito, credito, fondoinversion o prestamo


    public Cliente(string nombre, string apellido, double efectivo)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.efectivo = efectivo;
        
        this.cuentas = new Dictionary<string, Cuenta>();
    }


    public void MostrarDatos()
    {
        Console.WriteLine($"Nombre:{Nombre, 22}" +
                          $"\nApellido:{Apellido, 20}" +
                          $"\nEfectivo:{Efectivo, 20}"); // se mostrara para pruebas

        // Mostrar cuentas
        Console.WriteLine($"\n{"Tipo", 10} {"Numero de cuenta", 25} {"Saldo", 20}");
        foreach(Cuenta cuenta in this.Cuentas.Values){
            Console.WriteLine($"{Utilidades.Capitalize(cuenta.Tipo), 10} {cuenta.NumeroCuenta, 25} {cuenta.Saldo, 20}");
        }
    }
    
    public string Nombre
    {
        // Getter y setter
        get => nombre; // get se mantiene publico (acceso a todas las clases)
        protected set => nombre = value ?? throw new ArgumentNullException(nameof(value)); // set es protegido (acceso a empleado y derivados)
    }

    protected string Apellido
    {
        // Getter y setter
        get => apellido; // get se mantiene publico (acceso a todas las clases)
        private set => apellido = value ?? throw new ArgumentNullException(nameof(value)); // set es protegido (acceso a empleado y derivados)
    }
    
    public int NumeroCuenta
    {
        get => numeroCuenta;
        protected set => numeroCuenta = value;
    }
    
    public Dictionary<string, Cuenta> Cuentas
    {
        get => cuentas;
        set => cuentas = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public double Efectivo
    {
        get => efectivo;
        set => efectivo = value;
    }
    

}