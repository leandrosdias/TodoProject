using MediatR;
using Todo.API.Domain.Commands.Responses;

namespace Todo.API.Domain.Commands.Requests
{
    public class TodoDeleteModel : IRequest<TodoDeleteResponse>
    {
        public int Id { get; set; }
        public TodoDeleteModel(int id)
        {
            Id = id;
        }
    }
}
