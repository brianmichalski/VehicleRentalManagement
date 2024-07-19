using RentalManagement.Model;
using RentalManagement.Model.Enum;

public class Program
{
    static void Main(String[] arg)
    {
        //TODO [14] Creating instances of Vehicle
        Vehicle v1 = new Car("Sienna", "Toyota", 2023, 120, 
            7, EngineType.Inline, TransmissionType.Automatic, false);

        //Vehicle v2 = new MotorCycle("Kawasaki", "Ninja", 2014);
        //Vehicle v3 = new Car("Ford", "Ranger", 2018);

        RentalAgency rentalAgency = new RentalAgency();
        rentalAgency.Name = "Kitchener Downtown Garage";
        rentalAgency.Address = "999 King Street, Kitchener ON";

        rentalAgency.DisplayFleet();
        ConsoleUtils.WriteBlankLines(2);

        rentalAgency.AddVehicle(v1);

        int totalVehicles = rentalAgency.CountTotalVehicles();
        int rentedVehicles = rentalAgency.CountRentedVehicles(); 

        ConsoleUtils.WriteHeader("Garage info", '=', true);
        ConsoleUtils.WriteField("Name", rentalAgency.Name);
        ConsoleUtils.WriteField("Address", rentalAgency.Address);
        ConsoleUtils.WriteHeader("Fleet summary", '-');
        ConsoleUtils.WriteField("Rented", rentedVehicles);
        ConsoleUtils.WriteField("Available", (totalVehicles - rentedVehicles));
        ConsoleUtils.WriteField("Total Size", totalVehicles);
        ConsoleUtils.WriteBlankLines(2);

        //garage.AddVehicle(v2);
        //garage.AddVehicle(v3);

        rentalAgency.DisplayFleet();
        ConsoleUtils.WriteBlankLines(2);

        rentalAgency.RemoveVehicle(v1);

        rentalAgency.DisplayFleet();
    }
}