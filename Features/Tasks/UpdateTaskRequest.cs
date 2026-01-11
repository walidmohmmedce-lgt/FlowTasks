using System.ComponentModel.DataAnnotations;

namespace FlowTasks.Features.Tasks;

public class UpdateTaskRequest
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Status { get; set; } = "Pending";

    public DateTime? DueDate { get; set; }
}
