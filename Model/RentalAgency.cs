using RentalManagement.Utils;

namespace RentalManagement.Model;
public class RentalAgency
{
    public string Name { get; set; }
    public string Address { get; set; }
    public double TotalRevenue { get; set; }
    public List<Vehicle> AllVehicles
    {
        get => this.fleet
            .Select(v => v.Key)
            .ToList();
    }
    public List<Vehicle> VehiclesAvailable { 
        get => this.fleet
            .Where(v => !v.Value)
            .Select(v => v.Key)
            .ToList();
    }
    public List<Vehicle> VehiclesRented
    {
        get => this.fleet
            .Where(v => v.Value)
            .Select(v => v.Key)
            .ToList();
    }

    // The bool value in the Dictionary indicates whether the vehicle is rented or not
    Dictionary<Vehicle, bool> fleet;

    public RentalAgency()
	{
		this.fleet = new Dictionary<Vehicle, bool>();
	}

	public void AddVehicle(Vehicle vehicle)
	{
        vehicle.Id = this.fleet.Count + 1;
        this.fleet.Add(vehicle, false);
	}

	public void RemoveVehicle(Vehicle vehicle)
	{
        this.CheckVehicle(vehicle);
        if (this.fleet[vehicle])
        {
            throw new InvalidOperationException("A car can not be removed when in rented status");
        }
		this.fleet.Remove(vehicle);
    }
    private void CheckVehicle(Vehicle vehicle)
    {
        if (vehicle == null)
        {
            throw new ArgumentNullException();
        }
        if (!this.fleet.ContainsKey(vehicle))
        {
            throw new ArgumentException("Vehicle not registered in the fleet");
        }
    }

    public void RentVehicle(Vehicle vehicle)
	{
        this.CheckVehicle(vehicle);

		bool isVehicleRented = this.fleet[vehicle];
		if (isVehicleRented)
        {
            throw new InvalidOperationException("Vehicle already rented");
        }

		// Set the vehicle as rented
		this.fleet[vehicle] = true;
		this.TotalRevenue += vehicle.RentalPrice;
    }

    public void ReturnVehicle(Vehicle vehicle)
    {
        this.CheckVehicle(vehicle);

        bool isVehicleRented = this.fleet[vehicle];
        if (!isVehicleRented)
        {
            throw new InvalidOperationException("Vehicle is not rented");
        }

        // Set the vehicle as not rented
        this.fleet[vehicle] = false;
    }

    public void DisplayInfo()
    {
        int countVehiclesAvailable = this.VehiclesAvailable.Count;
        int countVehiclesRented = this.VehiclesRented.Count;

        ConsoleWriteUtils.WriteHeader("Agency info", '=', true);
        ConsoleWriteUtils.WriteField("Name", this.Name);
        ConsoleWriteUtils.WriteField("Address", this.Address);

        ConsoleWriteUtils.WriteHeader("Financial status", '-');
        ConsoleWriteUtils.WriteField("Total revenue", this.TotalRevenue);

        ConsoleWriteUtils.WriteHeader("Fleet summary", '-');
        ConsoleWriteUtils.WriteField("Rented", countVehiclesAvailable);
        ConsoleWriteUtils.WriteField("Available",countVehiclesRented);
        ConsoleWriteUtils.WriteField("Total", countVehiclesAvailable + countVehiclesRented);
    }

    public void DisplayFleetDetails()
    {
        ConsoleWriteUtils.WriteHeader("Fleet Details", '-', true);
        if ((this.fleet?.Count ?? 0) == 0)
        {
            ConsoleWriteUtils.WriteLine("No vehicles in the fleet", '*');
            return;
        }
        foreach (var fleetItem in this.fleet)
        {
            Vehicle vehicle = fleetItem.Key;
            bool isVehicleRented = fleetItem.Value;

            vehicle.DisplayInfo();
            ConsoleWriteUtils.WriteField("* Rent status", isVehicleRented ? "Rented" : "Available");
            ConsoleWriteUtils.WriteDividingLine('-');
        }
    }

    public void DisplayFleetList()
    {
        ConsoleWriteUtils.WriteHeader("Fleet List", '-', true);
        if ((this.fleet?.Count ?? 0) == 0)
        {
            ConsoleWriteUtils.WriteLine("No vehicles in the fleet", '*');
            return;
        }
        foreach (var fleetItem in this.fleet)
        {
            Vehicle vehicle = fleetItem.Key;
            ConsoleWriteUtils.WriteLine(string.Format("#{0} - {1} {2} ({3}) {4}", 
                vehicle.Id,
                vehicle.Manufacturer,
                vehicle.Model,
                vehicle.Year,
                fleetItem.Value ? "* Rented" : ""));

            ConsoleWriteUtils.WriteDividingLine('-');
        }
    }
}
