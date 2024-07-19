using RentalManagement.Model.Enum;

namespace RentalManagement.Model;
public class Truck : Vehicle
{
	public int Capacity { get; set; }

    public TruckType TruckType { get; set; }

	public bool FourWheelDrive { get; set; }

	public Truck(string model, string manufacturer, int year, double rentalPrice,
        int capacity, TruckType truckType, bool fourWheelDrive) 
		: base(model, manufacturer, year, rentalPrice)
	{
        this.Capacity = capacity;
		this.TruckType = truckType;
		this.FourWheelDrive = fourWheelDrive;
    }
    public override void DisplayInfo()
    {
        ConsoleUtils.WriteField("Type", "Truck");
        base.DisplayInfo();
        ConsoleUtils.WriteField("Capacity", this.Capacity);
        ConsoleUtils.WriteField("Truck Type", this.TruckType);
        ConsoleUtils.WriteField("Four Wheel Drive", this.FourWheelDrive);
    }
}
