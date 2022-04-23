using System.Text.Json;
using Task = CleanetCode.TodoList.CLI.Models.Task;

namespace CleanetCode.TodoList.CLI.Storages
{
	public class TaskStorage
	{
		private static readonly List<Task> _tasks = new List<Task>();
		private static readonly string _storageFile = "tasks.json";

        static TaskStorage()
        {
            if (File.Exists(_storageFile))
            {
                string json = File.ReadAllText(_storageFile);
                _tasks = JsonSerializer.Deserialize<List<Task>>(json);
            }
        }

        public static void Create(Task task)
        {
            _tasks.Add(task);
            UpdateStorageFile();

        }

        public static List<Task> GetAll(Guid userId)
        {
            return _tasks.Where(t => t.UserId == userId).ToList();
        }

        public static void UpdateTask(Task task)
        {
            Task storageTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (storageTask != null)
            {
                storageTask.Name = task.Name;
                storageTask.Description = task.Description;
                storageTask.IsCompleted = task.IsCompleted;
                storageTask.UpdatedDate = DateTime.Now;

                UpdateStorageFile();
            }
        }

        public static void DeleteTask(Task task)
        {
            Task storageTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (storageTask != null)
            {
                _tasks.Remove(task);

                UpdateStorageFile();
            }
        }

        private static void UpdateStorageFile()
        {
            File.WriteAllText(_storageFile, JsonSerializer.Serialize(_tasks));
        }
    }
}