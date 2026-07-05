#!

namespace Example
{
    public class Computer(string manu, string proc, int ram, int disk, double procSpd)
    {
        public string Manufacturer { get; set; } = manu;
        public string Processor { get; set; } = proc;
        public int RamSize { get; set; } = ram;
        public int DiskSize { get; set; } = disk;
        public double ProcessorSpeed { get; set; } = procSpd;

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


    public class NoteBook(string manu, string proc, int ram, int disk, double procSpd, double screen, double wei)
        : Computer(manu, proc, ram, disk, procSpd)
    {
        public double ScreenSize { get; set; } = screen;
        public double Weight { get; set; } = wei;
    }
}