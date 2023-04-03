using Microsoft.AspNetCore.Mvc;
using TodoListService.Models;
using TodoListService.Services.TodoListService;

namespace TodoListService.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : Controller
{
    private readonly ITodoListService _todoListService;
    
    public TodoListController(ITodoListService todoListService)
    {
        _todoListService = todoListService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoListDto>> GetById(int id)
    {
        return Ok(await _todoListService.GetById(id));
    }

    [HttpPost("{id}/todolistitem")]
    public async Task<ActionResult> AddListItem(CreateTodoListItemDto dto)
    {
        return Ok(await _todoListService.AddTodoListItem(dto));
    }
    
    [HttpDelete("{todoListId}/todolistitem/{id}")]
    public async Task<ActionResult> DeleteListItem(int todoListId, int id)
    {
        await _todoListService.DeleteTodoListItem(todoListId, id);
        
        return Ok();
    }
    
}