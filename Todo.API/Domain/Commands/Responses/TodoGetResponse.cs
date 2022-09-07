using Todo.API.Models;

namespace Todo.API.Domain.Commands.Responses
{
    public class TodoGetResponse
    {
        public IEnumerable<TodoModel> TodoList { get; set; }
        public TodoModel Todo { get; set; }
    }
}
