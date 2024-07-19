using RentalManagement.Model.Enum;
using RentalManagement.Utils;

namespace RentalManagement.Model;
public class Motorcycle : Vehicle
{
    public int EngineCapacity { get; set; }
    public FuelType FuelType { get; set; }  
    public bool HasFairing { get; set; }

    public Motorcycle(string model, string manufacturer, int year, double rentalPrice, 
        int engineCapacity, FuelType fuelType, bool hasFairing)
        : base(model, manufacturer, year, rentalPrice)
    {
        this.EngineCapacity = engineCapacity;
        this.FuelType = fuelType;
        this.HasFairing = hasFairing;
    }
    public override void DisplayInfo()
    {
        ConsoleWriteUtils.WriteField("Type", string.Format("Motorcycle (#{0})", this.Id));
        base.DisplayInfo();
        ConsoleWriteUtils.WriteField("Engine Capacity", this.EngineCapacity);
        ConsoleWriteUtils.WriteField("Fuel Type", this.FuelType);
        ConsoleWriteUtils.WriteField("Has Fairing", this.HasFairing);
    }
}
