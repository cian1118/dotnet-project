using Microsoft.EntityFrameworkCore;

namespace RazorPagesToDo.Data
{
    public class RazorPagesToDoContext : DbContext
    {
        public RazorPagesToDoContext (DbContextOptions<RazorPagesToDoContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesToDo.Models.ToDoTask> ToDoTask { get; set; } = default!;
    }
}
