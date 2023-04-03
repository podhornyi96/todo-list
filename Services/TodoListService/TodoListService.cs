using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using TodoListService.Common.Redis;
using TodoListService.Domain;
using TodoListService.Models;
using TodoListService.Persistence;

namespace TodoListService.Services.TodoListService;

public class TodoListService : ITodoListService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDistributedCache _cache;
    
    public TodoListService(ApplicationDbContext context, IMapper mapper, IDistributedCache cache)
    {
        _context = context;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<TodoListDto> GetById(int id)
    {
        var data = await _cache.GetAsync($"{RedisCacheKeys.TodoList}:{id.ToString()}");
        
        if (data != null)
            return RedisHelper.Deserialize<TodoListDto>(data);
        
        var dbData = await _context.TodoLists
            .Include(x => x.TodoListItems)
            .FirstOrDefaultAsync(x => x.Id == id);

        var result = _mapper.Map<TodoListDto>(dbData);
        
        data = RedisHelper.Serialize(result);
        
        await _cache.SetAsync($"{RedisCacheKeys.TodoList}:{id.ToString()}", data);

        return result;
    }

    public async Task<int> AddTodoListItem(CreateTodoListItemDto dto)
    {
        var result = _mapper.Map<TodoListItem>(dto);

        await _context.TodoListItems.AddAsync(result);

        await _context.SaveChangesAsync();
        
        await _cache.RemoveAsync($"{RedisCacheKeys.TodoList}:{dto.TodoListId.ToString()}");

        return result.Id;
    }

    public async Task DeleteTodoListItem(int todoListId, int id)
    {
        var entity = await _context.TodoListItems.FindAsync(id);
        
        if (entity == null)
            return;
        
        _context.TodoListItems.Remove(entity);

        await _context.SaveChangesAsync();
        
        await _cache.RemoveAsync($"{RedisCacheKeys.TodoList}:{todoListId}");
    }
    
}