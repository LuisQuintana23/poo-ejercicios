namespace Practica7;

public abstract class Empleado
{
    private string nombre;
    private string apellido;
    private int numeroTrabajador;
    protected double comision; // el porcentaje que se llevara el empleado
    private double comisiones; // total de ingresos por comision

    public Empleado(string nombre, string apellido, int numeroTrabajador)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.numeroTrabajador = numeroTrabajador;
    }

    public double ObtenerComision(double monto)
    {
        // parte se refiere a la parte generada por el monto
        double parte = monto * comision;
        Comisiones += parte;

        Console.WriteLine($"\nComision: + $ {parte:N4}");

        return parte;
    }

    public static void GetComisionesTotales(List<Empleado> empleados)
    {
        double comisionesCajeros = 0;
        double comisionesEjecutivos = 0;

        foreach(Empleado empleado in empleados) {
            // identificar cajeros - tienen numero de trabajador a partirdel 100,000,000
            if (empleado.numeroTrabajador < 200_000)
                comisionesCajeros += empleado.comisiones;

            // identificar ejecutivos - tienen numero de trabajador a partirdel 200,000,000
            else if (empleado.numeroTrabajador >= 200_000)
                comisionesEjecutivos += empleado.comisiones;
        }


        Console.WriteLine($"{"Comisiones\n", 25}");
        Console.WriteLine($"{"Cajeros: ", 15} {comisionesCajeros, 15:N5}");
        Console.WriteLine($"{"Ejecutivos: ", 15} {comisionesEjecutivos, 15:N5}");
        Console.WriteLine($"\n{"Totales: ", 15} {comisionesEjecutivos + comisionesCajeros, 15:N5}");

    }

    public abstract void AtenderCliente(Cliente cliente);
    
    public string Nombre
    {
        // Getter y setter
        get => nombre; // get se mantiene publico (acceso a todas las clases)
        protected set => nombre = value ?? throw new ArgumentNullException(nameof(value)); // set es protegido (acceso a empleado y derivados)
    }

    public string Apellido
    {
        // Getter y setter
        get => apellido; // get se mantiene publico (acceso a todas las clases)
        protected set => apellido = value ?? throw new ArgumentNullException(nameof(value)); // set es protegido (acceso a empleado y derivados)
    }
    public double Comisiones { get => comisiones; set => comisiones = value; }

    


}