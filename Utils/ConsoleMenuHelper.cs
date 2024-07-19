namespace RentalManagement.Utils;
public class MenuHelper
{
	private List<string> _menuItems;
	private string _menuTitle;

	public MenuHelper(string menuTitle, List<string> menuItems)
	{
		_menuTitle = menuTitle;
		_menuItems = menuItems;
	}

	public void DisplayMenu(bool mainMenu = false)
	{
		Console.Clear();
		ConsoleWriteUtils.WriteHeader(_menuTitle, '=', true);
		for (int i = 0; i < _menuItems.Count; i++)
		{
			Console.WriteLine($"{i + 1}. {_menuItems[i]}");
		}
		Console.WriteLine(string.Format("0. {0}", mainMenu ? "Exit" : "Return"));
	}

	public int GetMenuSelection()
	{
		int choice;
		while (true)
		{
			Console.Write("> Choose an option [0]: ");
			string? inputChoice = Console.ReadLine();
			bool parsingSuccess = int.TryParse(inputChoice?.Length > 0 
				? inputChoice : "0", out choice);

            if (parsingSuccess && choice >= 0 && choice <= _menuItems.Count)
			{
				return choice;
			}
			else
			{
				Console.WriteLine("Invalid choice. Please enter a number between 0 and " + _menuItems.Count);
			}
		}
	}

}
