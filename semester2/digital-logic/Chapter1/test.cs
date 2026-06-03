#!
#:property ExperimentalFileBasedProgramEnableTransitiveDirectives=true
#:include Chip.cs


for (int i = 0; i < 2; i++)
{

    for (int j = 0; j < 2; j++)
    {
        //var and = new AndGate(i == 1, j == 1);
        //var or = new OrGate(and.Result(), j == 1);
        var notA = new NotGate(i == 1);
        var notB = new NotGate(j == 1);
        System.Console.WriteLine($"{i}\t{j}\t{notA.Result()}\t{notB.Result()}");
    }
}