using MediatR;
using Todo.API.Data.Repositories;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Domain.Commands.Responses;

namespace Todo.API.Domain.Handlers
{
    public class TodoGetHandler : IRequestHandler<TodoGetModel, TodoGetResponse>
    {
        private ITodoRepository _todoRepository;
        public TodoGetHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public Task<TodoGetResponse> Handle(TodoGetModel request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                var todos = _todoRepository.Get(request);
                return Task.FromResult(new TodoGetResponse { TodoList = todos });
            }

            var todo = _todoRepository.FindById(request.Id);
            return Task.FromResult(new TodoGetResponse { Todo = todo });
        }
    }
}
