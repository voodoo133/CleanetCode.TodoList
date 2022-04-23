using CleanetCode.ToDoList.CLI.Operations;

namespace CleanetCode.ToDoList.CLI
{
	public class Menu
	{
		private IOperation[] _operations;

		public Menu(IOperation[] operations)
		{
			_operations = operations;
		}

		public string[] GetOperationNames()
		{
			List<string> operationNames = new List<string>();

			for (int i = 0; i < _operations.Length; i++)
			{
				IOperation operation = _operations[i];
				operationNames.Add($"{i + 1} - {operation.Name}");
			}

			return operationNames.ToArray();
		}

		public bool Enter(int operationNumber)
		{
			operationNumber--;
			if (operationNumber < 0 || operationNumber >= _operations.Length)
				return false;

			_operations[operationNumber].Execute();

			return true;
		}
	}
}