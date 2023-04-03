using TodoListService.Models;

namespace TodoListService.Services.TodoListService;

public interface ITodoListService
{
    Task<TodoListDto> GetById(int id);
    Task<int> AddTodoListItem(CreateTodoListItemDto dto);
    Task DeleteTodoListItem(int todoListId, int id);
    Task UpdateTodoListItem(TodoListItemDto dto);
}