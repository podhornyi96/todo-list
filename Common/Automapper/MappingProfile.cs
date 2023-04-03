using AutoMapper;
using TodoListService.Domain;
using TodoListService.Models;

namespace TodoListService.Common.Automapper;

public class MappingProfile : Profile
{
    public MappingProfile() {
        CreateMap<TodoList, TodoListDto>();
        CreateMap<TodoListItem, TodoListItemDto>();
    }
}