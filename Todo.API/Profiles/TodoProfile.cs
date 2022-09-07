using AutoMapper;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Models;

namespace Todo.API.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoCreateModel, TodoModel>();
            CreateMap<TodoUpdateModel, TodoModel>();
        }
    }
}
