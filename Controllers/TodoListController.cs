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
    
}