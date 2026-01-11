using System.ComponentModel.DataAnnotations;

namespace FlowTasks.Features.Tasks;

public class CreateTaskRequest
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DateTime? DueDate { get; set; }
}
