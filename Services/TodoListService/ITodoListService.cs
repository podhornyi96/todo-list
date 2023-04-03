using TodoListService.Models;

namespace TodoListService.Services.TodoListService;

public interface ITodoListService
{
    Task<TodoListDto> GetById(int id);
}