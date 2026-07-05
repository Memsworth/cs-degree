#!
using Example;

var myComputer =
        new Computer("Acme", "Intel", 32, 2560, 4.7);

var yourComputer =
    new NoteBook("DellGate", "AMD", 8, 256,
                 3.4, 13.3, 2.94);

System.Console.WriteLine(myComputer);
System.Console.WriteLine(yourComputer);

var lTp1 = new NoteBook("Intel", 16, 512, 4.6, 13.3, 3.18);
var lTp2 = new NoteBook("MicroSys", "AMD", 8, 256, 3.9, 17, 5.4);

System.Console.WriteLine(lTp1);
System.Console.WriteLine(lTp2);


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

        /*public int ComparePower(Computer computer)
        {
            if(this. ComputePower() < computer.ComputePower())
                return -1;
            else if (this.ComputePower() == computer.ComputePower())
                return 0;
            return 1;
        }*/
    }


    public class NoteBook(string manu, string proc, int ram, int disk, double procSpd, double screen, double wei)
        : Computer(manu, proc, ram, disk, procSpd)
    {
        public double ScreenSize { get; private set; } = screen;
        public double Weight { get; private set; } = wei;

        public static string DEFAULT_NB_MAN { get; set; } = "IBM";


        public NoteBook(string proc, int ram, int disk, double procSpd, double screen, double wei)
            : this(DEFAULT_NB_MAN, proc, ram, disk, procSpd, screen, wei)
        {

        }

        public override string ToString()
        {
            var result = base.ToString() +
                "\nScreen size: " + ScreenSize + " inches" +
                "\nWeight: " + Weight + " pounds";
            return result;
        }
    }
}




/*********************************************************************************/


namespace Exercise
{
    public class Computer(string manu, string proc, int ram, int disk, double procSpd)
    {
        public string Manufacturer { get; set; } = manu;
        public string Processor { get; set; } = proc;
        public int RamSize { get; set; } = ram;
        public int DiskSize { get; set; } = disk;
        public double ProcessorSpeed { get; set; } = procSpd;
        
        private static string DefaultComputerManufacturer { get; set; } = "Intel";
        private static double DefaultComputerProcessorSpeed { get; set; } = 3.4;

        //this is here
        public Computer(string proc, int ram, int disk) : 
            this(DefaultComputerManufacturer, proc, ram, disk, DefaultComputerProcessorSpeed)
        {
            
        }

        public override string ToString()
        {
            var result = "Manufacturer: " + Manufacturer +
                            "\nCPU: " + Processor +
                            "\nRAM: " + RamSize + " gigabytes" +
                            "\nDisk: " + DiskSize + " gigabytes" +
                            "\nProcessor speed: " + ProcessorSpeed + " gigahertz";


            return result;
        }

        /*public int ComparePower(Computer computer)
        {
            if(this. ComputePower() < computer.ComputePower())
                return -1;
            else if (this.ComputePower() == computer.ComputePower())
                return 0;
            return 1;
        }*/
    }


    public class NoteBook(string manu, string proc, int ram, int disk, double procSpd, double screen, double wei)
        : Computer(manu, proc, ram, disk, procSpd)
    {
        public double ScreenSize { get; private set; } = screen;
        public double Weight { get; private set; } = wei;

        public static string DEFAULT_NB_MAN { get; set; } = "IBM";
        private static double DefaultNotebookProcessorSpeed { get; set; } = 3.4;
        private static double DefaultNotebookScreenSize { get; set; } = 13.3;
        private static double DefaultNotebookWeight { get; set; } = 3.18;


        public NoteBook(string proc, int ram, int disk, double procSpd, double screen, double wei)
            : this(DEFAULT_NB_MAN, proc, ram, disk, procSpd, screen, wei)
        {

        }

        //this here
        public NoteBook(string proc, int ram, int disk) 
            : this(DEFAULT_NB_MAN, proc, ram, disk, DefaultNotebookProcessorSpeed, 
                DefaultNotebookScreenSize, DefaultNotebookWeight)
        {
            
        }

        public override string ToString()
        {
            var result = base.ToString() +
                "\nScreen size: " + ScreenSize + " inches" +
                "\nWeight: " + Weight + " pounds";
            return result;
        }
    }
}