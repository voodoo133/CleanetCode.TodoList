using CleanetCode.ToDoList.CLI.Models;

namespace CleanetCode.TodoList.CLI
{
	public static class UserSession
	{
		public static User? CurrentUser { get; set; }
	}
}