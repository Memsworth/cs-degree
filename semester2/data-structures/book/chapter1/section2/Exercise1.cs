public class Notebook : Computer
{
    public double ScreenSize { get; set; }
    public double Weight { get; set; }

    public Notebook(string man, string proc, double ram, int disk,
                        double procSpeed, double screen, double wei)
                        : base(man, proc, ram, disk, procSpeed)
    {
        ScreenSize = screen;
        Weight = wei;
    }
}

public class Computer
{
    public string Manufacturer { get; set; }
    public string Processor { get; set; }
    public int RamSize { get; set; }
    public int DiskSize { get; set; }
    public double ProcessorSpeed { get; set; }
    public Computer(string man, string processor, int ram,
     int disk, double procSpeed)
    {
        Manufacturer = man;
        Processor = processor;
        RamSize = ram;
        DiskSize = disk;
        ProcessorSpeed = procSpeed;
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
}