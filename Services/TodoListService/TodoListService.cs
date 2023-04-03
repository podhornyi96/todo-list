using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using TodoListService.Common.Redis;
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
    
}