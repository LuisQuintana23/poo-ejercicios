namespace Practica7;

class RentaVariable : FondoInversion
{
    public RentaVariable(double monto) : base(monto)
    {
        // ALTO RIESGO
        // Riesgo debe ser menor a 1
        // rendimiento mayor a 1
        Riesgo = 0.1;
        Rendimiento = 2.0;
    }
}
