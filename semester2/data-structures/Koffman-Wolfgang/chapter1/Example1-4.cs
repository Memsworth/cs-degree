#!


namespace Example
{
    public abstract class Food
    {
        public double Calories { get; set; }
        public abstract double PercentProtien();
        public abstract double PercentFat();
        public abstract double PercentCarbohydrates();
    }

    public abstract class Number
    {
        public abstract int IntValue();
        public abstract double DoubleValue();

        //must provide implementation
        public byte ByteValue() => (byte)1;
    }
}



namespace ExerciseOne
{
    public class Vegetable
    {
        public double VEG_FAT_CAL { get; private set; }
        public double VEG_PROTEIN_CAL { get; private set; }
        public double VEG_CARBO_CAL { get; private set; }

        public Vegetable(double fat, double pro, double carbo)
        {
            VEG_FAT_CAL = fat;
            VEG_PROTEIN_CAL = pro;
            VEG_CARBO_CAL = carbo;
        }


        public double GetFatPercentage()
        {
            double total = VEG_FAT_CAL + VEG_PROTEIN_CAL + VEG_CARBO_CAL;

            if (total == 0)
                return 0;

            return VEG_FAT_CAL / total;
        }
    }
}



namespace ExerciseTwo
{
    public abstract class Computer(string manu, string proc, int ram, int disk, double procSpd)
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

        public abstract decimal CostBenefit(double amount);

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

        public override decimal CostBenefit(double amount) => decimal.Zero;
    }
}
