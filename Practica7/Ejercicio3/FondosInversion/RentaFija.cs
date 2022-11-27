namespace Practica7;

class RentaFija : FondoInversion
{
    public RentaFija(double monto) : base(monto)
    {
        // MEDIANO RIESGO
        // Riesgo debe ser menor a 1
        // rendimiento mayor a 1
        Riesgo = 0.4;
        Rendimiento = 1.7;
    }
}
