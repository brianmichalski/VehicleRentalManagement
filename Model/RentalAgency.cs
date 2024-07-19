namespace RentalManagement.Model;
public class RentalAgency
{
    public string Name { get; set; }
    public string Address { get; set; }
    public double TotalRevenue { get; set; }

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
    public int CountTotalVehicles()
    {
        return this.fleet.Count();
    }

    public int CountRentedVehicles() 
    {
        return this.fleet.Where(fleetItem => fleetItem.Value).Count();
    }

    public void DisplayFleet()
    {
        ConsoleUtils.WriteHeader("Fleet Report", '-', true);
        if ((this.fleet?.Count ?? 0) == 0)
        {
            ConsoleUtils.WriteLine("No vehicles in the fleet", '*');
            return;
        }
        foreach (var fleetItem in this.fleet)
        {
            Vehicle vehicle = fleetItem.Key;
            bool isVehicleRented = fleetItem.Value;

            vehicle.DisplayInfo();
            ConsoleUtils.WriteField("* Rent status", isVehicleRented ? "Rented" : "Available");
            ConsoleUtils.WriteDividingLine('-');
        }
    }
}
