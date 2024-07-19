namespace RentalManagement.Utils;

public static class ConsoleWriteUtils
{
    public static int CONSOLE_WIDTH = 80;
    public static int FIELD_LABEL_WIDTH = 18;

    public static void WriteDividingLine(char symbol)
    {
        Console.WriteLine(new string(symbol, CONSOLE_WIDTH));
    }

    public static void WriteHeader(string header, char lineSymbol, bool displayDateTime = false)
    {
        WriteDividingLine(lineSymbol);
        if (displayDateTime)
        {
            Console.WriteLine("{0}{1}{2}",
                header.ToUpper(),
                new string(' ', CONSOLE_WIDTH - header.Length - DateTime.Now.ToString().Length),
                DateTime.Now);
        }
        else
        {
            Console.WriteLine(header.ToUpper());
        }
        WriteDividingLine(lineSymbol);
    }
    public static void WriteLine(string line, char fillingSymbol = '\0')
    {
        string outputLine = line.ToUpper().Substring(0, (line.Length > CONSOLE_WIDTH) ? CONSOLE_WIDTH : line.Length);
        if (fillingSymbol != '\0')
        {
            Console.WriteLine("{0} {1}",
                outputLine,
                new string(fillingSymbol, CONSOLE_WIDTH - line.Length - 1));
        } else { 
            Console.WriteLine(outputLine);
        }
    }

    public static void WriteField(string fieldLabel, object fieldValue)
    {
        Console.WriteLine("{0}{1}: {2}",
            fieldLabel.ToUpper(),
            new string(' ', FIELD_LABEL_WIDTH - fieldLabel.Length),
            fieldValue);
    }
    public static void WriteBlankLines(int lineCount)
    {
        Console.WriteLine(new string('\n', lineCount));
    }
}