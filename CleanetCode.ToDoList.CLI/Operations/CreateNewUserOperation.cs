using CleanetCode.ToDoList.CLI.Models;
using CleanetCode.ToDoList.CLI.Storages;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class CreateNewUserOperation : IOperation
    {
        public string Name => "Создать нового пользователя";

        public void Execute()
        {
            Console.Write("Введите ваш email: ");
            string email;
            bool userCreated;

            do
            {
                do
                {
                    email = Console.ReadLine();

                    if (!IsValidEmail(email))
                        Console.WriteLine("Введен некорректный email\nУкажите, пожалуйста, корректный адрес электронной почты:");

                } while (!IsValidEmail(email));


                User newUser = new User(email);

                userCreated = UserStorage.Create(newUser);

                if (!userCreated)
                    Console.WriteLine("Пользователь с таким email уже есть\nУкажите другой адрес электронной почты:");

            } while (!userCreated);

            Console.WriteLine("\nПользователь успешно создан\n");
        }

        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
                return false; 

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
    }
}
