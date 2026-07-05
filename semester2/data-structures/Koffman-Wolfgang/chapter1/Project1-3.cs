#!

public abstract class Computer
{
    public decimal BasePrice { get; set; }
    public double ProcessorSpeed { get; set; }
    public int MemoryGB { get; set; }
    public int StorageGB { get; set; }
    public bool WirelessNetwork { get; set; }
    public bool DVDDrive { get; set; }

    protected Computer(decimal basePrice, double processorSpeed,
        int memoryGB, int storageGB,
        bool wirelessNetwork, bool dvdDrive)
    {
        BasePrice = basePrice;
        ProcessorSpeed = processorSpeed;
        MemoryGB = memoryGB;
        StorageGB = storageGB;
        WirelessNetwork = wirelessNetwork;
        DVDDrive = dvdDrive;
    }

    public decimal CalculateMemoryPrice()
    {
        return MemoryGB * 25m;
    }

    public decimal CalculateStoragePrice()
    {
        return StorageGB * 0.10m;
    }

    public decimal CalculateProcessorPrice()
    {
        return (decimal)ProcessorSpeed * 100m;
    }

    public decimal CalculateWirelessPrice()
    {
        return WirelessNetwork ? 40m : 0m;
    }

    public decimal CalculateDVDPrice()
    {
        return DVDDrive ? 50m : 0m;
    }

    public abstract decimal CalculateShippingCost();

    public abstract decimal CalculatePrice();

    public override string ToString()
    {
        return $"Base Price: {BasePrice:C}\n" +
               $"Processor Speed: {ProcessorSpeed} GHz\n" +
               $"Memory: {MemoryGB} GB\n" +
               $"Storage: {StorageGB} GB\n" +
               $"Wireless Network: {(WirelessNetwork ? "Yes" : "No")}\n" +
               $"DVD Drive: {(DVDDrive ? "Yes" : "No")}";
    }
}






public class Desktop : Computer
{
    private static decimal DefaultBasePrice { get; set; } = 100m;
    public Desktop(decimal basePrice, double processorSpeed,
        int memoryGB, int storageGB,
        bool wirelessNetwork, bool dvdDrive)
        : base(basePrice, processorSpeed, memoryGB,
               storageGB, wirelessNetwork, dvdDrive)
    {
    }


    public Desktop(double processorSpeed,
        int memoryGB, int storageGB,
        bool wirelessNetwork, bool dvdDrive)
        : base(DefaultBasePrice, processorSpeed, memoryGB,
               storageGB, wirelessNetwork, dvdDrive)
    {
    }

    public override decimal CalculateShippingCost()
    {
        return 40m;
    }

    public override decimal CalculatePrice()
    {
        return BasePrice +
               CalculateProcessorPrice() +
               CalculateMemoryPrice() +
               CalculateStoragePrice() +
               CalculateWirelessPrice() +
               CalculateDVDPrice() +
               CalculateShippingCost();
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nShipping Cost: {CalculateShippingCost():C}" +
               $"\nTotal Price: {CalculatePrice():C}";
    }
}



public class Notebook : Computer
{
    public double ScreenSize { get; set; }
    public bool TouchScreen { get; set; }

    private static decimal DefaultBasePrice { get; set; } = 100m;

    public Notebook(decimal basePrice, double processorSpeed,
        int memoryGB, int storageGB,
        bool wirelessNetwork, bool dvdDrive,
        double screenSize, bool touchScreen)
        : base(basePrice, processorSpeed, memoryGB,
               storageGB, wirelessNetwork, dvdDrive)
    {
        ScreenSize = screenSize;
        TouchScreen = touchScreen;
    }


    public Notebook(double processorSpeed,
    int memoryGB, int storageGB,
    double screenSize, bool touchScreen)
    : base(DefaultBasePrice, processorSpeed, memoryGB,
           storageGB, true, true)
    {
        ScreenSize = screenSize;
        TouchScreen = touchScreen;
    }

    public decimal CalculateScreenPrice()
    {
        return (decimal)ScreenSize * 20m;
    }

    public decimal CalculateTouchScreenPrice()
    {
        return TouchScreen ? 100m : 0m;
    }

    public override decimal CalculateShippingCost()
    {
        return 20m;
    }

    public override decimal CalculatePrice()
    {
        return BasePrice +
               CalculateProcessorPrice() +
               CalculateMemoryPrice() +
               CalculateStoragePrice() +
               CalculateWirelessPrice() +
               CalculateDVDPrice() +
               CalculateScreenPrice() +
               CalculateTouchScreenPrice() +
               CalculateShippingCost();
    }

    public override string ToString()
    {
        return base.ToString() +
               $"\nScreen Size: {ScreenSize}\"" +
               $"\nTouch Screen: {(TouchScreen ? "Yes" : "No")}" +
               $"\nShipping Cost: {CalculateShippingCost():C}" +
               $"\nTotal Price: {CalculatePrice():C}";
    }
}