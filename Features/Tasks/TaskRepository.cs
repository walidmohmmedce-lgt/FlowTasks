namespace FlowTasks.Features.Tasks;

public static class TaskRepository
{
    private static readonly List<TaskItem> _tasks = new();

    public static List<TaskItem> GetAll()
    {
        return _tasks;
    }

    public static void Add(TaskItem task)
    {
        _tasks.Add(task);
    }
}
