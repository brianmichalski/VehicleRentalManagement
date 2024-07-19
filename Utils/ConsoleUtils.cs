using System.Reflection.PortableExecutable;

public static class ConsoleUtils
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
        if (fillingSymbol != '\0')
        {
            Console.WriteLine("{0} {1}",
                line.ToUpper().Substring(0, (line.Length > CONSOLE_WIDTH) ? CONSOLE_WIDTH : line.Length),
                new string(fillingSymbol, CONSOLE_WIDTH - line.Length - 1));
        } else { 
            Console.WriteLine(line.ToUpper().Substring(0, CONSOLE_WIDTH));
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