namespace TodoListService.Domain;

public class TodoListItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int TodoListId { get; set; }
    public TodoList TodoList { get; set; }
}