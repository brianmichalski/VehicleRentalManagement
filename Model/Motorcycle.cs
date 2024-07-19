using RentalManagement.Model.Enum;

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
        ConsoleUtils.WriteField("Type", "Motorcycle");
        base.DisplayInfo();
        ConsoleUtils.WriteField("Engine Capacity", this.EngineCapacity);
        ConsoleUtils.WriteField("Fuel Type", this.FuelType);
        ConsoleUtils.WriteField("Has Fairing", this.HasFairing);
    }
}
