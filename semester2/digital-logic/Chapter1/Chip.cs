#!
#:property ExperimentalFileBasedProgramEnableTransitiveDirectives=true

public interface IGate
{
    public bool Result();
}

public class NandGate : IGate
{
    public bool A { get; }
    public bool B { get; }

    public NandGate(bool a, bool b)
    {
        A = a;
        B = b;
    }
    public bool Result() => !(A && B);
}

public class NotGate : IGate
{
    public NandGate Not { get; }
    public NotGate(bool A)
    {
        Not = new NandGate(A, A);
    }
    public bool Result() => Not.Result();
}

public class AndGate : IGate
{
}


public class OrGate : IGate
{
}