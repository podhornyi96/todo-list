namespace TodoListService.Models;

public class CreateTodoListItemDto
{
    public int TodoListId { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}