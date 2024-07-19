using RentalManagement.Model;
using RentalManagement.Model.Enum;
using RentalManagement.Utils;
using VehicleRentalManagement.Utils;

public class Program
{
    RentalAgency rentalAgency;

    public Program()
    {
        this.rentalAgency = new RentalAgency();
    }

    static void Main(String[] arg)
    {
        Program program = new Program();

        Vehicle v1 = new Car("Sienna", "Toyota", 2023, 120,
            7, EngineType.Inline, TransmissionType.Automatic, false);

        //Vehicle v2 = new MotorCycle("Kawasaki", "Ninja", 2014);
        //Vehicle v3 = new Car("Ford", "Ranger", 2018);
        program.rentalAgency.Name = "Kitchener Downtown Garage";
        program.rentalAgency.Address = "999 King Street, Kitchener ON";

        program.rentalAgency.AddVehicle(v1);

        program.DisplayMainMenu();
    }

    public void DisplayMainMenu()
    {
        List<string> menuItems = new List<string> {
            "Set up Agency Info",
            "Manage Fleet",
            "Reports"
        };
        MenuHelper menuHelper = new MenuHelper("Main Menu", menuItems);

        int choice;
        do
        {
            menuHelper.DisplayMenu(true);
            choice = menuHelper.GetMenuSelection();

            switch (choice)
            {
                case 1:
                    Console.WriteLine("You selected Option 1.");
                    this.SetUpAgencyInfo();
                    break;
                case 2:
                    Console.WriteLine("You selected Option 2.");
                    this.DisplayManageFleetMenu();
                    break;
                case 3:
                    Console.WriteLine("You selected Option 3.");
                    this.DisplayReportsMenu();
                    break;
                case 0:
                    bool confirmExit = ConsoleReadUtils.ReadBoolean("Exit the system (y/n)?", out confirmExit);
                    if (confirmExit)
                    {
                        Console.Clear();
                        Console.WriteLine("Exiting...");
                    } else
                    {
                        choice = -1;
                    }
                    break;
            }
        } while (choice != 0);
    }

    public void SetUpAgencyInfo()
    {
        Console.Clear();
        ConsoleWriteUtils.WriteHeader("Set up Agency Info", '=');

        string name = ConsoleReadUtils.ReadLine("Agency name", false);
        if ((name ?? "") == "") { return; }

        string address = this.rentalAgency.Address = ConsoleReadUtils.ReadLine("Agency address");
        if ((address ?? "") == "") { return; }

        this.rentalAgency.Name = name;
        this.rentalAgency.Address = address;

        ConsoleWriteUtils.WriteLine("[Saved] Agency info updated!");
        ConsoleReadUtils.AskPressingForAnyKey();
    }

    public void DisplayManageFleetMenu()
    {
        List<string> menuItems = new List<string> {
            "List All",
            "Rent",
            "Return",
            "Add",
            "Remove"
        };
        MenuHelper menuHelper = new MenuHelper("Manage Fleet", menuItems);

        int choice;
        do
        {
            menuHelper.DisplayMenu();
            choice = menuHelper.GetMenuSelection();

            switch (choice)
            {
                case 1:
                    this.ListVehicles();
                    break;
                case 2:
                    this.RentVehicle();
                    break;
                case 3:
                    this.ReturnVehicle();
                    break;
                case 4:
                    this.AddVehicle();
                    break;
                case 5:
                    this.RemoveVehicle();
                    break;
                case 0:
                    break;
            }
        } while (choice != 0);
    }

    public void DisplayReportsMenu()
    {
        List<string> menuItems = new List<string> {
            "Fleet Status",
            "Fleet Details"
        };
        MenuHelper menuHelper = new MenuHelper("Reports", menuItems);

        int choice;
        do
        {
            menuHelper.DisplayMenu();
            choice = menuHelper.GetMenuSelection();

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    this.rentalAgency.DisplayInfo();
                    ConsoleReadUtils.AskPressingForAnyKey();
                    break;
                case 2:
                    Console.Clear();
                    this.rentalAgency.DisplayFleetDetails();
                    ConsoleReadUtils.AskPressingForAnyKey();
                    break;
                case 0:
                    break;
            }
        } while (choice != 0);
    }

    public void ListVehicles()
    {
        Console.Clear();
        this.rentalAgency.DisplayFleetList();
        ConsoleReadUtils.AskPressingForAnyKey();
    }

    public void RentVehicle()
    {
        List<string> menuItems = this.rentalAgency.VehiclesAvailable
            .Select(vehicle => string.Format("{0} {1} - {2} (#{3})", 
                vehicle.Manufacturer, 
                vehicle.Model, 
                vehicle.Year, 
                vehicle.Id))
            .ToList();

        if (menuItems.Count == 0)
        {
            Console.Clear();
            ConsoleWriteUtils.WriteLine("There are no cars available", '*');
            ConsoleReadUtils.AskPressingForAnyKey();
            return;
        }

        MenuHelper menuHelper = new MenuHelper("Rent Vehicle", menuItems);

        menuHelper.DisplayMenu();
        try
        {
            int choice = menuHelper.GetMenuSelection();
            if (choice > 0)
            {
                Vehicle vehicleChoice = this.rentalAgency.VehiclesAvailable[choice-1];
                this.rentalAgency.RentVehicle(vehicleChoice);
            }
        }
        catch (Exception ex)
        {
            ConsoleWriteUtils.WriteDividingLine('!');
            ConsoleWriteUtils.WriteLine(string.Format("ERROR: {0}", ex.Message));
            ConsoleReadUtils.AskPressingForAnyKey();
        }
    }

    public void ReturnVehicle()
    {
        List<string> menuItems = this.rentalAgency.VehiclesRented
            .Select(vehicle => string.Format("{0} {1} - {2} (#{3})",
                vehicle.Manufacturer,
                vehicle.Model,
                vehicle.Year,
                vehicle.Id))
            .ToList();

        if (menuItems.Count == 0)
        {
            Console.Clear();
            ConsoleWriteUtils.WriteLine("There are no cars rented", '*');
            ConsoleReadUtils.AskPressingForAnyKey();
            return; 
        }

        MenuHelper menuHelper = new MenuHelper("Return Vehicle", menuItems);
        menuHelper.DisplayMenu();
        try
        {
            int choice = menuHelper.GetMenuSelection();
            if (choice > 0)
            {
                Vehicle vehicleChoice = this.rentalAgency.VehiclesRented[choice - 1];
                this.rentalAgency.ReturnVehicle(vehicleChoice);
            }
        }
        catch (Exception ex)
        {
            ConsoleWriteUtils.WriteDividingLine('!');
            ConsoleWriteUtils.WriteLine(string.Format("ERROR: {0}", ex.Message));
            ConsoleReadUtils.AskPressingForAnyKey();
        }
    }

    public void AddVehicle()
    {
        Console.Clear();
        ConsoleWriteUtils.WriteHeader("Add Vehicle", '=');

        Vehicle vehicle = null;
        bool exit = false;

        VehicleType vehicleType = ConsoleReadUtils.ReadFromEnum<VehicleType>("Type", out exit);
        if (exit)
        {
            return;
        }
        string manufacturer = ConsoleReadUtils.ReadLine("Manufacturer");
        string model = ConsoleReadUtils.ReadLine("Model");
        int year = ConsoleReadUtils.ReadInteger("Year", 1990, DateTime.Now.Year);
        int seats = ConsoleReadUtils.ReadInteger("Seats", 2, 7);
        int rentalPrice = ConsoleReadUtils.ReadInteger("Rental price", 40, 200);

        switch (vehicleType)
        {
            case VehicleType.Car:
                EngineType engineType = ConsoleReadUtils.ReadFromEnum<EngineType>("Engine", out exit);
                if (exit) { return; }

                TransmissionType transmissionType = ConsoleReadUtils.ReadFromEnum<TransmissionType>("Transmission", out exit);
                if (exit) { return; }

                bool convertible = ConsoleReadUtils.ReadBoolean("Convertible (y/n)", out exit);
                if (exit) { return; }

                Car car = new Car(model, manufacturer, year, rentalPrice, seats,
                    engineType, transmissionType, convertible);

                vehicle = car;
                break;

            case VehicleType.Motorcycle:
                int engineCapacity = ConsoleReadUtils.ReadInteger("Engine capacity", 250, 1500);
                if (engineCapacity == 0) { return; }

                FuelType fuelType = ConsoleReadUtils.ReadFromEnum<FuelType>("Fuel type", out exit);
                if (exit) { return; }

                bool hasFairing = ConsoleReadUtils.ReadBoolean("Has fairing (y/n)", out exit);
                if (exit) { return; }

                Motorcycle motorcycle = new Motorcycle(model, manufacturer, year, rentalPrice, 
                    engineCapacity, fuelType, hasFairing);

                vehicle = motorcycle;
                break;

            case VehicleType.Truck:
                int capacity = ConsoleReadUtils.ReadInteger("Capacity (ton)", 1, 200);
                if (capacity == 0) { return; }

                TruckType truckType = ConsoleReadUtils.ReadFromEnum<TruckType>("Truck type", out exit);
                if (exit) { return; }

                bool fourWheelDrive = ConsoleReadUtils.ReadBoolean("4 wheel drive (y/n)", out exit);
                if (exit) { return; }

                Truck truck = new Truck(model, manufacturer, year, rentalPrice,
                    capacity, truckType, fourWheelDrive);

                vehicle = truck;
                break;
        }
        this.rentalAgency.AddVehicle(vehicle);

        ConsoleWriteUtils.WriteLine("[Saved] Vehicle added!");
        ConsoleReadUtils.AskPressingForAnyKey();
    }

    public void RemoveVehicle()
    {
        List<string> menuItems = this.rentalAgency.AllVehicles
            .Select(vehicle => string.Format("{0} {1} - {2} (#{3})",
                vehicle.Manufacturer,
                vehicle.Model,
                vehicle.Year,
                vehicle.Id))
            .ToList();

        if (menuItems.Count == 0)
        {
            Console.Clear();
            ConsoleWriteUtils.WriteLine("There are no cars registered", '*');
            ConsoleReadUtils.AskPressingForAnyKey();
            return;
        }

        MenuHelper menuHelper = new MenuHelper("Remove Vehicle", menuItems);

        menuHelper.DisplayMenu();
        try
        {
            int choice = menuHelper.GetMenuSelection();
            if (choice > 0)
            {
                Vehicle vehicleChoice = this.rentalAgency.AllVehicles[choice - 1];
                this.rentalAgency.RemoveVehicle(vehicleChoice);

                ConsoleWriteUtils.WriteLine("[Saved] Vehicle removed!");
                ConsoleReadUtils.AskPressingForAnyKey();
            }
        }
        catch (Exception ex)
        {
            ConsoleWriteUtils.WriteDividingLine('!');
            ConsoleWriteUtils.WriteLine(string.Format("ERROR: {0}", ex.Message));
            ConsoleReadUtils.AskPressingForAnyKey();
        }
    }
}