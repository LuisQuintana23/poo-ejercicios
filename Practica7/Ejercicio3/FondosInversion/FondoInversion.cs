namespace Practica7;

public class FondoInversion
{
    // entre mayor riesgo mayor rendimiento
    private double monto;
    private double riesgo;
    private double tasa;
    private double rendimiento;

    public FondoInversion(double monto)
    {
        this.monto = monto;
    }

    public static bool CumpleRequisitos(Cliente cliente)
    {
        if (!cliente.Cuentas.ContainsKey("debito")) // si cliente no tiene al menos 5,000 en tarjeta de debito, no cumple con los requisitos
        {
            // no se dispone del suficiente efectivo
            throw new RequisitosIncumplidosException(
                "Se requiere tener una cuenta de debito para abrir un fondo de inversión");
        }

        
        if (cliente.Cuentas["debito"].Saldo < 50000) // solo se puede abrir fondos desde $ 25,000
        { throw new FondosInsuficientesException("Se requiere por lo menos $ 50,000 en una cuenta de debito para abrir un fondo de inversión");
        }

        
        return true;
    }

    public double Invertir()
    {
        double montoFinal = Monto;
        Random seed = new Random();

        double multiplicador = (seed.NextDouble()*(Rendimiento - Riesgo)) + Riesgo;
        multiplicador = (Math.Truncate(multiplicador * 10000) / 10000); // limita a 4 decimales el multiplicador

        montoFinal *= multiplicador;

        return montoFinal;
    }


    public double Monto { get => monto; set => monto = value; }
    public double Riesgo { get => riesgo; set => riesgo = value; }
    public double Tasa { get => tasa; set => tasa = value; }
    public double Rendimiento { get => rendimiento; set => rendimiento = value; }
}