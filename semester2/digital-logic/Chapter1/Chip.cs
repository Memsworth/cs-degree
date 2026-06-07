#!
#:property ExperimentalFileBasedProgramEnableTransitiveDirectives=true

public interface IGate
{
    public bool Output();
}

public interface IGateTwoOutputs : IGate
{
    public bool SecondOut();
}

public class NandGate : IGate
{
    private readonly Func<bool> A;
    private readonly Func<bool> B;

    public NandGate(Func<bool> a, Func<bool> b)
    {
        A = a;
        B = b;
    }
    public bool Output() => !(A() && B());
}

public class NotGate : IGate
{
    private readonly IGate outPutGate;
    public NotGate(Func<bool> a)
    {
        outPutGate = new NandGate(a, a);
    }
    public bool Output() => outPutGate.Output();
}

public class AndGate : IGate
{
    private readonly IGate outPutGate;
    public AndGate(Func<bool> a, Func<bool> b)
    {
        var nand = new NandGate(a, b);
        outPutGate = new NotGate(nand.Output);
    }
    public bool Output() => outPutGate.Output();
}


public class OrGate : IGate
{
    private readonly IGate outPutGate;
    public OrGate(Func<bool> a, Func<bool> b)
    {
        var nandA = new NandGate(a, a);
        var nandB = new NandGate(b, b);
        outPutGate = new NandGate(nandA.Output, nandB.Output);
    }
    public bool Output() => outPutGate.Output();
}


public class XorGate : IGate
{
    private readonly IGate outPutGate;
    public XorGate(Func<bool> a, Func<bool> b)
    {
        var firstTerm = new AndGate(a, new NotGate(b).Output);
        var secondTerm = new AndGate(new NotGate(a).Output, b);

        outPutGate = new OrGate(firstTerm.Output, secondTerm.Output);
    }

    public bool Output() => outPutGate.Output();
}

public class Multiplexer : IGate
{
    private readonly IGate outPutGate;
    public Multiplexer(Func<bool> a, Func<bool> b, Func<bool> sel)
    {
        var notSel = new NotGate(sel);
        var firstTerm = new AndGate(a, notSel.Output);
        var secondTerm = new AndGate(sel, b);

        outPutGate = new OrGate(firstTerm.Output, secondTerm.Output);
    }

    public bool Output() => outPutGate.Output();
}

public class Demultiplexer
{
    private readonly IGate outPutGateA;
    private readonly IGate outPutGateB;

    public Demultiplexer(Func<bool> input, Func<bool> sel)
    {
        var notSel = new NotGate(sel);
        outPutGateA = new AndGate(input, notSel.Output);
        outPutGateB = new AndGate(input, sel);
    }

    public (bool outputA, bool outputB) Output()
    {
        return (outPutGateA.Output(), outPutGateB.Output());
    }
}





/*-------------------------------------------------------------------*/


//MULTIBIT STUFF


public interface IMultiGate
{
    public bool[] Outputs();
}

public class MultiNot : IMultiGate
{
    private readonly Func<bool[]> A;
    private readonly Func<bool[]> B;

    public MultiNot(Func<bool[]> input)
    {

    }
    public bool Output() => !(A() && B());

    public bool[] Outputs()
    {
        throw new NotImplementedException();
    }
}