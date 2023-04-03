namespace TodoListService.Models;

public class TodoListItemDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}