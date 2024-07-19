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
        public static string ReadLine(string prompt, bool mandatory = true)
        {
            while (true)
            {
                Console.Write("{0}: ", prompt);
                string? input = Console.ReadLine();
                if (input != null && (!mandatory || input.Trim() != ""))
                {
                    return input;
                }
                ConsoleWriteUtils.WriteLine("Invalid input. Provide a text.");
            }
        }
        public static T ReadFromEnum<T>(string prompt, out bool exit) where T : Enum
        {
            while (true)
            {
                Console.WriteLine("{0}: ", prompt);
                foreach (var value in Enum.GetValues(typeof(T)))
                {
                    ConsoleWriteUtils.WriteLine($"{(int)value+1}. {value}");
                }
                ConsoleWriteUtils.WriteLine("0. Return");

                Console.Write("Choose one option: ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    if (choice == 0)
                    {
                        exit = true;
                        return default;
                    }
                    exit = false;
                    return (T)(object)(choice-1);
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

                if (int.TryParse(input, out result))
                {
                    if (result == 0 || result >= minimumValue && result <= maximumValue)
                    {
                        return result;
                    }
                }

                Console.WriteLine("Invalid input. Value must be between {0} and {1}.", 
                    minimumValue, maximumValue);
            }
        }
        public static bool ReadBoolean(string prompt, out bool exit)
        {
            string[] yesOptions = { "y", "yes" };
            string[] noOptions = { "n", "no" };
            while (true)
            {
                Console.Write("{0}: ", prompt);
                string? input = Console.ReadLine()?.Trim()?.ToLower();
                if (input == null || input.Trim() == "")
                {
                    exit = true;
                    return default;
                }

                exit = false;
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
