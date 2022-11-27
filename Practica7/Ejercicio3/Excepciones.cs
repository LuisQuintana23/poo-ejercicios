namespace Practica7;

[Serializable]
public class FondosInsuficientesException : Exception
{
    public string Name { get; }

    public FondosInsuficientesException() { }

    public FondosInsuficientesException(string message)
        : base(message) { }

    public FondosInsuficientesException(string message, Exception inner)
        : base(message, inner) { }

    public FondosInsuficientesException(string message, string studentName)
        : this(message)
    {
        Name = studentName;
    }
}
public class NingunaCuentaException : Exception
{
    public string Name { get; }

    public NingunaCuentaException() { }

    public NingunaCuentaException(string message)
        : base(message) { }

    public NingunaCuentaException(string message, Exception inner)
        : base(message, inner) { }

    public NingunaCuentaException(string message, string studentName)
        : this(message)
    {
        Name = studentName;
    }
}
public class CuentaNoEncontrada : Exception
{
    public string Name { get; }

    public CuentaNoEncontrada() { }

    public CuentaNoEncontrada(string message)
        : base(message) { }

    public CuentaNoEncontrada(string message, Exception inner)
        : base(message, inner) { }

    public CuentaNoEncontrada(string message, string studentName)
        : this(message)
    {
        Name = studentName;
    }
}

public class RequisitosIncumplidosException : Exception
{
    public string Name { get; }

    public RequisitosIncumplidosException() { }

    public RequisitosIncumplidosException(string message)
        : base(message) { }

    public RequisitosIncumplidosException(string message, Exception inner)
        : base(message, inner) { }

    public RequisitosIncumplidosException(string message, string studentName)
        : this(message)
    {
        Name = studentName;
    }
}
