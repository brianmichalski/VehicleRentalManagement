using RentalManagement.Utils;

namespace VehicleRentalManagement.Utils
{
    public class ConsoleReadUtils
    {
        public static void AskPressingForAnyKey()
        {
            ConsoleWriteUtils.WriteBlankLines(1);
            ConsoleWriteUtils.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public static string ReadLine(string prompt)
        {
            while (true)
            {
                Console.Write("{0}: ", prompt);
                string? input = Console.ReadLine();
                if (input != null)
                {
                    return input;
                }
                ConsoleWriteUtils.WriteLine("Invalid input. Provide a text.");
            }
        }
        public static T ReadFromEnum<T>(string prompt) where T : Enum
        {
            while (true)
            {
                Console.WriteLine("{0}: ", prompt);
                foreach (var value in Enum.GetValues(typeof(T)))
                {
                    ConsoleWriteUtils.WriteLine($"{(int)value}. {value}");
                }

                Console.Write("Choose one option: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && Enum.IsDefined(typeof(T), choice))
                {
                    return (T)(object)choice;
                }

                ConsoleWriteUtils.WriteLine("Invalid input. Please try again.");
            }
        }

        public static int ReadInteger(string prompt, int minimumValue, int maximumValue)
        {
            int result;
            while (true)
            {
                Console.Write("{0}: ", prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out result) && result >= minimumValue && result <= maximumValue)
                {
                    return result;
                }

                Console.WriteLine("Invalid input. Value must be between {0} and {1}.", 
                    minimumValue, maximumValue);
            }
        }
        public static bool ReadBoolean(string prompt)
        {
            string[] yesOptions = { "y", "yes" };
            string[] noOptions = { "n", "no" };
            while (true)
            {
                Console.Write("{0}: ", prompt);
                string? input = Console.ReadLine()?.Trim()?.ToLower();

                if (yesOptions.Contains(input))
                {
                    return true;
                }
                else if (noOptions.Contains(input))
                {
                    return false;
                }

                Console.WriteLine("Invalid input. Please enter 'y' (or 'yes') or 'n' (or 'no').");
            }
        }
    }
}
