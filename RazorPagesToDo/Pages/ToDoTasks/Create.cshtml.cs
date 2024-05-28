using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesToDo.Models;

namespace RazorPagesToDo.Pages_ToDoTasks
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesToDo.Data.RazorPagesToDoContext _context;

        public CreateModel(RazorPagesToDo.Data.RazorPagesToDoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDoTask ToDoTask { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDoTask.Add(ToDoTask);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
