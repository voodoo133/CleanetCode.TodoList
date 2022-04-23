namespace CleanetCode.ToDoList.CLI.Operations
{
    public interface IOperation
    {
        string Name { get; }
        void Execute();
    }
}
