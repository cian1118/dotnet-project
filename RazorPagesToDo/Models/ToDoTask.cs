using System.ComponentModel.DataAnnotations;

namespace RazorPagesToDo.Models;

public class ToDoTask
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; }
    public string? Notes { get; set; }
}