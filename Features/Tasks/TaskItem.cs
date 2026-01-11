namespace FlowTasks.Features.Tasks;

public class TaskItem
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Status { get; set; } = "Pending";

    public DateTime? DueDate { get; set; }
}
