namespace Ejercicio2;

public class Producto
{
    public string nombre;
    public string codigoBarras;
    public double costo;
    public string tipo;
    public bool perecedero;
    public DateTime FechaCaducidad;
    
    public Producto(string nombre, string codigoBarras, double costo, string tipo, bool perecedero, DateTime fechaCaucidad)
    {
        this.nombre = nombre;
        this.codigoBarras = codigoBarras;
        this.costo = costo;
        this.tipo = tipo;
        this.perecedero = perecedero;
        this.FechaCaducidad = fechaCaucidad;
    }
    
    public void ActualizarCosto(int dias)
    {
        
        // Si queda un dia para que se caduque
        if (dias == 1)
        {
            this.costo /= 4;
        }
        // Si queda 2 dias para que se caduque
        else if(dias == 2)
        {
            this.costo /= 3;
        }
        // Si queda 3 dias para que se caduque
        else if (dias == 3)
        {
            this.costo /= 2;
        }
        
    }

}