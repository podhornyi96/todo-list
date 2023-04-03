namespace TodoListService.Domain;

public class TodoList
{
    public int Id { get; set; }
    public IEnumerable<TodoListItem> TodoListItems { get; set; }
}