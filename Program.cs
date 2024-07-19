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
                    Console.WriteLine("Exiting...");
                    break;
            }
        } while (choice != 0);
    }

    public void SetUpAgencyInfo()
    {

    }

    public void DisplayManageFleetMenu()
    {
        List<string> menuItems = new List<string> {
            "List All",
            "Rent",
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
                    this.AddVehicle();
                    break;
                case 4:
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

    }
    
    public void AddVehicle()
    {
        Vehicle vehicle = null;
        ConsoleWriteUtils.WriteHeader("Add Vehicle", '=');
        VehicleType vehicleType = ConsoleReadUtils.ReadFromEnum<VehicleType>("Type");
        string manufacturer = ConsoleReadUtils.ReadLine("Manufacturer");
        string model = ConsoleReadUtils.ReadLine("Model");
        int year = ConsoleReadUtils.ReadInteger("Year", 1990, DateTime.Now.Year);
        int seats = ConsoleReadUtils.ReadInteger("Seats", 2, 7);
        int rentalPrice = ConsoleReadUtils.ReadInteger("Rental price", 40, 200);

        switch (vehicleType)
        {
            case VehicleType.Car:
                EngineType engineType = ConsoleReadUtils.ReadFromEnum<EngineType>("Engine");
                TransmissionType transmissionType = ConsoleReadUtils.ReadFromEnum<TransmissionType>("Transmission");
                bool convertible = ConsoleReadUtils.ReadBoolean("Convertible (y/n)");

                Car car = new Car(model, manufacturer, year, rentalPrice, seats,
                    engineType, transmissionType, convertible);

                vehicle = car;
                break;
            case VehicleType.Motorcycle: 
                break;
            case VehicleType.Truck:
                break;
        }
        this.rentalAgency.AddVehicle(vehicle);
        ConsoleWriteUtils.WriteLine("[Saved] Vehicle added successfully!");
        ConsoleReadUtils.AskPressingForAnyKey();
    }

    public void RemoveVehicle()
    {

    }
}