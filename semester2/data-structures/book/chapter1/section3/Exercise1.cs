//GO CHECK COMPUTE POWER LAST IN COMPUTER CLASS

Computer computer = new Computer("Acme", "Intel", 32, 2560, 4.7);
Notebook yourComputer = new Notebook("DellGate", "AMD", 8, 256, 3.4, 13.3, 2.94);
Notebook lTP1 = new Notebook("Intel", 16, 512, 4.6, 13.3, 3.18);


//System.Console.WriteLine(computer.ToString());
//System.Console.WriteLine(yourComputer.ToString());
//System.Console.WriteLine(lTP1.ToString());


Computer computer1 = new Computer("INTEL", 32, 256);
Computer computer2 = new Notebook("AMD", 32, 256);

System.Console.WriteLine(computer1.ToString());
System.Console.WriteLine(computer2.ToString());


public class Notebook : Computer
{
    public double ScreenSize { get; set; }
    public double Weight { get; set; }
    private const string DEFAULT_NB_MAN = "Powerbuy";

    private const double SCREEN_SIZE = 15.8;
    private const double WEIGHT = 6.2;



    public Notebook(string proc, int ram, int disk,
        double procSpeed, double screen, double wei) : this(DEFAULT_NB_MAN, proc, ram, disk, procSpeed, screen, wei)
    {

    }
    public Notebook(string proc, int ram, int disk) : base(proc, ram, disk)
    {
        ScreenSize = SCREEN_SIZE;
        Weight = WEIGHT;
    }

    public Notebook(string man, string proc, int ram, int disk,
                        double procSpeed, double screen, double wei)
                        : base(man, proc, ram, disk, procSpeed)

    {
        ScreenSize = screen;
        Weight = wei;
    }



    public override string ToString()
    {
        var result = base.ToString() +
        "\nScreen size: " + ScreenSize + " inches" +
        "\nWeight: " + Weight + " pounds";
        return result;
    }
}
public class Computer
{
    public string Manufacturer { get; set; }
    public string Processor { get; set; }
    public int RamSize { get; set; }
    public int DiskSize { get; set; }
    public double ProcessorSpeed { get; set; }

    private const string DEFAULT_NB_MAN = "MSI";
    private const double PROCESSOR_SPEED = 2.7;

    public Computer(string man, string processor, int ram,
     int disk, double procSpeed)
    {
        Manufacturer = man;
        Processor = processor;
        RamSize = ram;
        DiskSize = disk;
        ProcessorSpeed = procSpeed;
    }

    public Computer(string processor, int ram, int disk)
    {
        Manufacturer = DEFAULT_NB_MAN;
        Processor = processor;
        RamSize = ram;
        DiskSize = disk;
        ProcessorSpeed = PROCESSOR_SPEED;
    }


    public double ComputePower() { return RamSize * ProcessorSpeed; }
    public int GetRamSize() { return RamSize; }
    public double GetProcessorSpeed() { return ProcessorSpeed; }
    public int GetDiskSize() { return DiskSize; }


    public override string ToString()
    {
        var result = "Manufacturer: " + Manufacturer +
        "\nCPU: " + Processor +
        "\nRAM: " + RamSize + " gigabytes" +
        "\nDisk: " + DiskSize + " gigabytes" +
        "\nProcessor speed: " + ProcessorSpeed + " gigahertz";
        return result;
    }


    //See here: We are comparing to other computers (in this case, it can be either a computer or a notebook)
    public int ComparePower(Computer aComputer)
    {
        if (ComputePower() < aComputer.ComputePower())
            return -1;
        else if (ComputePower() == aComputer.ComputePower())
            return 0;
        else return 1;
    }
}