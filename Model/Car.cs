using RentalManagement.Model.Enum;
using RentalManagement.Utils;

namespace RentalManagement.Model;
public class Car : Vehicle
{
	public int Seats { get; set; }
	public EngineType EngineType { get; set; }
    public TransmissionType TransmissionType { get; set; }
	public bool Convertible { get; set; }

	public Car(string model, string manufacturer, int year, double rentalPrice, 
        int seats, EngineType engineType, TransmissionType transmissionType, bool convertible)
        : base(model, manufacturer, year, rentalPrice)
    {
        this.Seats = seats;
        this.EngineType = engineType;
        this.TransmissionType = transmissionType;
        this.Convertible = convertible;
    }
    public override void DisplayInfo()
    {
        ConsoleWriteUtils.WriteField("Type", string.Format("Car (#{0})", this.Id));
        base.DisplayInfo();
        ConsoleWriteUtils.WriteField("Seats", this.Seats);
        ConsoleWriteUtils.WriteField("Engine Type", this.EngineType);
        ConsoleWriteUtils.WriteField("Transmission Type", this.TransmissionType);
        ConsoleWriteUtils.WriteField("Convertible", this.Convertible);
    }
}
