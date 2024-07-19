using RentalManagement.Model.Enum;

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
        ConsoleUtils.WriteField("Type", "Car");
        base.DisplayInfo();
        ConsoleUtils.WriteField("Seats", this.Seats);
        ConsoleUtils.WriteField("Engine Type", this.EngineType);
        ConsoleUtils.WriteField("Transmission Type", this.TransmissionType);
        ConsoleUtils.WriteField("Convertible", this.Convertible);
    }
}
