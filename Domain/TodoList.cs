namespace TodoListService.Domain;

public class TodoList
{
    public int Id { get; set; }
    public int TodoListItemId { get; set; }
    public TodoListItem TodoListItem { get; set; }
}