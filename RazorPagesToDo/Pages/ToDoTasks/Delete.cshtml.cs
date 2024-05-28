using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesToDo.Models;

namespace RazorPagesToDo.Pages_ToDoTasks
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesToDo.Data.RazorPagesToDoContext _context;

        public DeleteModel(RazorPagesToDo.Data.RazorPagesToDoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoTask ToDoTask { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todotask = await _context.ToDoTask.FirstOrDefaultAsync(m => m.Id == id);

            if (todotask == null)
            {
                return NotFound();
            }
            else
            {
                ToDoTask = todotask;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todotask = await _context.ToDoTask.FindAsync(id);
            if (todotask != null)
            {
                ToDoTask = todotask;
                _context.ToDoTask.Remove(ToDoTask);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
