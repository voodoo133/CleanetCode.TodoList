using CleanetCode.TodoList.CLI;
using CleanetCode.ToDoList.CLI.Models;
using CleanetCode.ToDoList.CLI.Storages;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class LoginUserOperation : IOperation
    {
        public string Name => "Залогиниться в системе";

        public void Execute()
        {
            Console.Write("Введите ваш email: ");
            string email = Console.ReadLine();
            User user = UserStorage.Get(email);

            if (user != null)
            {
                UserSession.CurrentUser = user;
                Console.WriteLine("\nВы успешно вошли\n");
            }
            else
            {
                Console.WriteLine($"\nПользователь с адресом {email} не найден\n"); 
            }
        }
    }
}
