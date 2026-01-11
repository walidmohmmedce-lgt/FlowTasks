using Microsoft.AspNetCore.Mvc;
using FlowTasks.Features.Tasks;
using FlowTasks.Data;
using Microsoft.EntityFrameworkCore;


namespace FlowTasks.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Tasks
    [HttpGet]
public async Task<IActionResult> GetAll()
{
    var tasks = await _context.Tasks.ToListAsync();
    return Ok(tasks);
}


    // GET: api/Tasks/{id}
    [HttpGet("{id}")]
public async Task<IActionResult> GetById(Guid id)
{
    var task = await _context.Tasks
        .FirstOrDefaultAsync(t => t.Id == id);

    if (task is null)
        return NotFound();

    return Ok(task);
}

    // POST: api/Tasks
    [HttpPost]
public async Task<IActionResult> Create(CreateTaskRequest request)
{
    var task = new TaskItem
    {
        Id = Guid.NewGuid(),
        Title = request.Title,
        Description = request.Description,
        DueDate = request.DueDate,
        Status = "Pending"
    };

    await _context.Tasks.AddAsync(task);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
}

    // PUT: api/Tasks/{id}
    [HttpPut("{id}")]
public async Task<IActionResult> Update(Guid id, UpdateTaskRequest request)
{
    var task = await _context.Tasks
        .FirstOrDefaultAsync(t => t.Id == id);

    if (task is null)
        return NotFound();

    task.Title = request.Title;
    task.Description = request.Description;
    task.Status = request.Status;
    task.DueDate = request.DueDate;

    await _context.SaveChangesAsync();

    return Ok(task);
}


    // DELETE: api/Tasks/{id}
    [HttpDelete("{id}")]
public async Task<IActionResult> Delete(Guid id)
{
    var task = await _context.Tasks
        .FirstOrDefaultAsync(t => t.Id == id);

    if (task is null)
        return NotFound();

    _context.Tasks.Remove(task);
    await _context.SaveChangesAsync();

    return NoContent();
}

}
