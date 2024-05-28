using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesToDo.Models;

namespace RazorPagesToDo.Pages_ToDoTasks
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesToDo.Data.RazorPagesToDoContext _context;

        public IndexModel(RazorPagesToDo.Data.RazorPagesToDoContext context)
        {
            _context = context;
        }

        public IList<ToDoTask> ToDoTask { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ToDoTask = await _context.ToDoTask.ToListAsync();
        }
    }
}
