using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoListService.Models;
using TodoListService.Persistence;

namespace TodoListService.Services.TodoListService;

public class TodoListService : ITodoListService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public TodoListService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<TodoListDto> GetById(int id)
    {
        var dbData = await _context.TodoLists
            .Include(x => x.TodoListItems)
            .FirstOrDefaultAsync(x => x.Id == id);

        var result = _mapper.Map<TodoListDto>(dbData);

        return result;
    }
    
}