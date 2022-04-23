namespace CleanetCode.ToDoList.CLI.Models
{
    public class User
    {
        public Guid Id { get; }
        public string Email { get; init; }

        public User(string email)
        {
            Id = Guid.NewGuid();
            Email = email;
        }
    }
}
