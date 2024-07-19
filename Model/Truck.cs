using RentalManagement.Model.Enum;
using RentalManagement.Utils;

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
        ConsoleWriteUtils.WriteField("Type", string.Format("Truck (#{0})", this.Id));
        base.DisplayInfo();
        ConsoleWriteUtils.WriteField("Capacity", this.Capacity);
        ConsoleWriteUtils.WriteField("Truck Type", this.TruckType);
        ConsoleWriteUtils.WriteField("Four Wheel Drive", this.FourWheelDrive);
    }
}
