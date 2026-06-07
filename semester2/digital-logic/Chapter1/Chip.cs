#!
#:property ExperimentalFileBasedProgramEnableTransitiveDirectives=true


System.Console.WriteLine("Hello world");

public interface IGate<T>
{
    public T Output();
}

public class NandGate : IGate<bool>
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

public class NotGate : IGate<bool>
{
    private readonly IGate<bool> outPutGate;
    public NotGate(Func<bool> a)
    {
        outPutGate = new NandGate(a, a);
    }
    public bool Output() => outPutGate.Output();
}

public class AndGate : IGate<bool>
{
    private readonly IGate<bool> outPutGate;
    public AndGate(Func<bool> a, Func<bool> b)
    {
        var nand = new NandGate(a, b);
        outPutGate = new NotGate(nand.Output);
    }
    public bool Output() => outPutGate.Output();
}


public class OrGate : IGate<bool>
{
    private readonly IGate<bool> outPutGate;
    public OrGate(Func<bool> a, Func<bool> b)
    {
        var nandA = new NandGate(a, a);
        var nandB = new NandGate(b, b);
        outPutGate = new NandGate(nandA.Output, nandB.Output);
    }
    public bool Output() => outPutGate.Output();
}


public class XorGate : IGate<bool>
{
    private readonly IGate<bool> outPutGate;
    public XorGate(Func<bool> a, Func<bool> b)
    {
        var firstTerm = new AndGate(a, new NotGate(b).Output);
        var secondTerm = new AndGate(new NotGate(a).Output, b);

        outPutGate = new OrGate(firstTerm.Output, secondTerm.Output);
    }

    public bool Output() => outPutGate.Output();
}

public class Multiplexer : IGate<bool>
{
    private readonly IGate<bool> outPutGate;
    public Multiplexer(Func<bool> a, Func<bool> b, Func<bool> sel)
    {
        var notSel = new NotGate(sel);
        var firstTerm = new AndGate(a, notSel.Output);
        var secondTerm = new AndGate(sel, b);

        outPutGate = new OrGate(firstTerm.Output, secondTerm.Output);
    }

    public bool Output() => outPutGate.Output();
}

public class Demultiplexer : IGate<(bool, bool)>
{
    private readonly IGate<bool> outPutGateA;
    private readonly IGate<bool> outPutGateB;

    public Demultiplexer(Func<bool> input, Func<bool> sel)
    {
        var notSel = new NotGate(sel);
        outPutGateA = new AndGate(input, notSel.Output);
        outPutGateB = new AndGate(input, sel);
    }

    public (bool, bool) Output()
        => (outPutGateA.Output(), outPutGateB.Output());
}


public class Not16BitGate : IGate<bool[]>
{
    private readonly Func<bool>[] outPutGate;

    public Not16BitGate(Func<bool>[] inputs)
    {
        outPutGate = new Func<bool>[16];
        for (int i = 0; i < outPutGate.Length; i++)
        {
            var notGate = new NotGate(inputs[i]);
            outPutGate[i] = notGate.Output;
        }
    }

    public bool[] Output()
    {
        var items = new bool[16];
        for (int i = 0; i < items.Length; i++)
            items[i] = outPutGate[i]();
        return items;
    }
}


public class And16BitGate : IGate<bool[]>
{
    private readonly Func<bool>[] outPutGate;

    public And16BitGate(Func<bool>[] a, Func<bool>[] b)
    {
        outPutGate = new Func<bool>[16];

        for (int i = 0; i < outPutGate.Length; i++)
        {
            var andGate = new AndGate(a[i], b[i]);
            outPutGate[i] = andGate.Output;
        }
    }

    public bool[] Output()
    {
        var items = new bool[16];

        for (int i = 0; i < items.Length; i++)
            items[i] = outPutGate[i]();


        return items;
    }
}


public class Or16BitGate : IGate<bool[]>
{
    private readonly Func<bool>[] outPutGate;

    public Or16BitGate(Func<bool>[] a, Func<bool>[] b)
    {
        outPutGate = new Func<bool>[16];

        for (int i = 0; i < outPutGate.Length; i++)
        {
            var andGate = new OrGate(a[i], b[i]);
            outPutGate[i] = andGate.Output;
        }
    }

    public bool[] Output()
    {
        var items = new bool[16];

        for (int i = 0; i < items.Length; i++)
            items[i] = outPutGate[i]();

        return items;
    }
}



public class Multiplexer16BitGate : IGate<bool[]>
{
    private readonly Func<bool>[] outPutGate;

    public Multiplexer16BitGate(Func<bool>[] a, Func<bool>[] b, Func<bool> sel)
    {
        outPutGate = new Func<bool>[16];
        for (int i = 0; i < outPutGate.Length; i++)
        {
            var multi = new Multiplexer(a[i], b[i], sel);
            outPutGate[i] = multi.Output;
        }
    }

    public bool[] Output()
    {
        var items = new bool[16];

        for (int i = 0; i < items.Length; i++)
            items[i] = outPutGate[i]();

        return items;
    }
}



public class MultiOr8BitGate : IGate<bool>
{
    private readonly Func<bool>[] Inputs;

    public MultiOr8BitGate(Func<bool>[] inputs)
    {
        Inputs = inputs;
    }

    public bool Output()
    {
        bool result = false;
        for (int i = 0; i < Inputs.Length; i++)
            result = new OrGate(() => result, Inputs[i]).Output();

        return result;
    }
}



public class Multi4WayMultiplexer16BitGate : IGate<bool[]>
{

    private readonly Func<bool>[] outPutGate;

    public Multi4WayMultiplexer16BitGate(Func<bool>[] a, Func<bool>[] b,
                                         Func<bool>[] c, Func<bool>[] d, bool[] sel)
    {
        outPutGate = new Func<bool>[4];

        if (sel[0] == false && sel[1] == false)
            outPutGate = SetInputs(a);
        else if (sel[0] == false && sel[1] == true)
            outPutGate = SetInputs(b);
        else if (sel[0] == true && sel[1] == false)
            outPutGate = SetInputs(c);
        else
            outPutGate = SetInputs(d);

    }

    public bool[] Output()
    {
        var items = new bool[16];

        for (int i = 0; i < items.Length; i++)
            items[i] = outPutGate[i]();

        return items;
    }

    private Func<bool>[] SetInputs(Func<bool>[] inputs)
    {
        var items = new Func<bool>[16];

        for (int i = 0; i < items.Length; i++)
            items[i] = inputs[i];

        return items;
    }
}





public class Multi8WayMultiplexer16BitGate : IGate<bool[]>
{

    private readonly Func<bool>[] outPutGate;

    public Multi8WayMultiplexer16BitGate(Func<bool>[] a, Func<bool>[] b,
                                         Func<bool>[] c, Func<bool>[] d,
                                         Func<bool>[] e, Func<bool>[] f,
                                         Func<bool>[] g, Func<bool>[] h,
                                         bool[] sel)
    {
        outPutGate = new Func<bool>[8];

        //000
        if (sel[0] == false && sel[1] == false && sel[2] == false)
            outPutGate = SetInputs(a);

        //001
        else if (sel[0] == false && sel[1] == false && sel[2] == true)
            outPutGate = SetInputs(b);

        //010
        else if (sel[0] == false && sel[1] == true && sel[2] == false)
            outPutGate = SetInputs(c);

        //011
        else if (sel[0] == false && sel[1] == true && sel[2] == true)
            outPutGate = SetInputs(d);

        //100
        else if (sel[0] == true && sel[1] == false && sel[2] == false)
            outPutGate = SetInputs(e);

        //101
        else if (sel[0] == true && sel[1] == false && sel[2] == true)
            outPutGate = SetInputs(f);

        //110
        else if (sel[0] == true && sel[1] == true && sel[2] == false)
            outPutGate = SetInputs(g);

        //111
        else
            outPutGate = SetInputs(h);
    }


    public bool[] Output()
    {
        var items = new bool[16];

        for (int i = 0; i < items.Length; i++)
            items[i] = outPutGate[i]();

        return items;
    }


    private Func<bool>[] SetInputs(Func<bool>[] inputs)
    {
        var items = new Func<bool>[16];

        for (int i = 0; i < items.Length; i++)
            items[i] = inputs[i];

        return items;
    }
}



public class Multi4WayDeMultiplexerGate(bool[] Sel, Func<bool> Input) : IGate<(bool, bool, bool, bool)>
{
    public (bool, bool, bool, bool) Output()
    {
        if (Sel[0] == false && Sel[1] == false)
            return SetInputs(1);

        else if (Sel[0] == false && Sel[1] == true)
            return SetInputs(2);

        else if (Sel[0] == true && Sel[1] == false)
            return SetInputs(3);

        else
            return SetInputs(4);
    }


    private (bool, bool, bool, bool) SetInputs(int position) => position switch
    {
        1 => (Input(), false, false, false),
        2 => (false, Input(), false, false),
        3 => (false, false, Input(), false),
        _ => (false, false, false, Input())
    };
}




public class Multi8WayDeMultiplexerGate : IGate<(bool, bool, bool, bool, bool, bool, bool, bool)>
{
    private readonly bool[] Sel;
    private readonly Func<bool> Input;

    public Multi8WayDeMultiplexerGate(Func<bool> input, bool[] sel)
    {
        Sel = sel;
        Input = input;
    }


    public (bool, bool, bool, bool, bool, bool, bool, bool) Output()
    {
        if (Sel[0] == false && Sel[1] == false && Sel[2] == false)
            return SetInputs(1);

        //001
        else if (Sel[0] == false && Sel[1] == false && Sel[2] == true)
            return SetInputs(2);

        //010
        else if (Sel[0] == false && Sel[1] == true && Sel[1] == false)
            return SetInputs(3);

        //011
        else if (Sel[0] == false && Sel[1] == true && Sel[1] == true)
            return SetInputs(4);

        //100
        else if (Sel[0] == true && Sel[1] == false && Sel[1] == false)
            return SetInputs(5);

        //101
        else if (Sel[0] == true && Sel[1] == false && Sel[1] == true)
            return SetInputs(6);

        //110
        else if (Sel[0] == true && Sel[1] == true && Sel[1] == false)
            return SetInputs(7);
        //111
        else
            return SetInputs(8);
    }



    private (bool, bool, bool, bool, bool, bool, bool, bool) SetInputs(int position) => position switch
    {
        1 => (Input(), false, false, false, false, false, false, false),
        2 => (false, Input(), false, false, false, false, false, false),
        3 => (false, false, Input(), false, false, false, false, false),
        4 => (false, false, false, Input(), false, false, false, false),
        5 => (false, false, false, false, Input(), false, false, false),
        6 => (false, false, false, false, false, Input(), false, false),
        7 => (false, false, false, false, false, false, Input(), false),
        _ => (false, false, false, false, false, false, false, Input())
    };

}



