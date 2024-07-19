namespace RentalManagement.Model;
public abstract class Vehicle
{
    public int Id { get; set;  }
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public double RentalPrice { get; set; }

    public Vehicle(string model, string manufacturer, int year, double rentalPrice)
	{
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Year = year;
        this.RentalPrice = rentalPrice;
	}
    public virtual void DisplayInfo()
    {
        ConsoleUtils.WriteField("Model", this.Model);
        ConsoleUtils.WriteField("Make", this.Manufacturer);
        ConsoleUtils.WriteField("Year", this.Year);
        ConsoleUtils.WriteField("Rental Price", this.RentalPrice);
    }

    public override bool Equals(object? obj)
    {
        if (this?.Id == null || obj == null 
            || !obj.GetType().IsAssignableFrom(typeof(Vehicle))) {
            return false;
        }

        return ((Vehicle) obj)?.Id == this?.Id;
    }

    public override int GetHashCode()
    {
        return this?.Id ?? 0;
    }
}
