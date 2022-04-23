using CleanetCode.TodoList.CLI;

namespace CleanetCode.ToDoList.CLI
{
	public class Application
	{
		private readonly Menu _menu;

		public Application(Menu menu)
		{
			_menu = menu;
		}

		public void Run()
		{
			bool userQuit = false;

			Console.WriteLine("Добро пожаловать.\n");

			while (!userQuit)
			{
				if (UserSession.CurrentUser != null)
					Console.WriteLine($"Текущий пользователь: {UserSession.CurrentUser.Email}");

				List<string> operationNames = new List<string>();
				operationNames.Add("q - выйти из программы");
				operationNames.AddRange(_menu.GetOperationNames());


				Console.WriteLine(string.Join("\n", operationNames));
				Console.Write("\nВведите номер операции: ");

				string? userInput = Console.ReadLine();
				if (userInput != null && userInput.Trim().ToLower() == "q")
				{
					userQuit = true;
				} 
				else
                {
					bool isNumber = int.TryParse(userInput, out int operationNumber);
					if (!isNumber || !_menu.Enter(operationNumber))
						Console.WriteLine("\nУкажите корректный номер операции!\n");
				}
			}

			Console.WriteLine("\nВсего хорошего. До свидания.\n");
		}
	}
}