using CleanetCode.ToDoList.CLI.Models;
using System.Text.Json;

namespace CleanetCode.ToDoList.CLI.Storages
{
    public static class UserStorage
    {
        private static readonly Dictionary<string, User> _users = new Dictionary<string, User>();
        private static readonly string _storageFile = "users.json";

        static UserStorage()
        {
            if (File.Exists(_storageFile))
            {
                string json = File.ReadAllText(_storageFile);
                List<User> users = JsonSerializer.Deserialize<List<User>>(json);

                foreach (User user in users)
                    _users.Add(user.Email, user);
            }
        }

        public static User? Get(string email)
        {
            _users.TryGetValue(email, out User? user);

            return user;
        }

        public static bool Create(User user)
        {
            bool userAdded = _users.TryAdd(user.Email, user);

            if (userAdded)
                UpdateStorageFile();

            return userAdded;
        }

        private static void UpdateStorageFile()
        {
            File.WriteAllText(_storageFile, JsonSerializer.Serialize(_users.Values));
        }
    }
}
