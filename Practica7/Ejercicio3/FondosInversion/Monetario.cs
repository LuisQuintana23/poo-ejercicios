namespace Practica7;
class Monetario : FondoInversion
{
    public Monetario(double monto) : base(monto)
    {
        // BAJO RIESGO
        // Riesgo debe ser menor a 1
        // rendimiento mayor a 1
        Riesgo = 0.8;
        Rendimiento = 1.5;
    }
}
