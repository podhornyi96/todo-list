namespace TodoListService.Models;

public class TodoListDto
{
    public int Id { get; set; }
    public IEnumerable<TodoListItemDto> TodoListItems { get; set; }
}