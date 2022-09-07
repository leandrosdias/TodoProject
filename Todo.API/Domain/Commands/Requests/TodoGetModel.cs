using MediatR;
using Todo.API.Domain.Commands.Responses;

namespace Todo.API.Domain.Commands.Requests
{
    public class TodoGetModel : IRequest<TodoGetResponse>
    {
        public int? Id { get; set; }

        public TodoGetModel(int id)
        {
            Id = id;
        }

        public TodoGetModel()
        {
            Id = null;
        }
    }
}
