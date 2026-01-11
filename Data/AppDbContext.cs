using Microsoft.EntityFrameworkCore;
using FlowTasks.Features.Tasks;

namespace FlowTasks.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
