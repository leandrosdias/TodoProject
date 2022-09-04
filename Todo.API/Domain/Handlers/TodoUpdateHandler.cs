using AutoMapper;
using MediatR;
using Todo.API.Data.Repositories;
using Todo.API.Data;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Domain.Commands.Responses;
using Todo.API.Models;

namespace Todo.API.Domain.Handlers
{
    public class TodoUpdateHandler : IRequestHandler<TodoUpdateModel, TodoUpdateResponse>
    {
        private ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public TodoUpdateHandler(ITodoRepository todoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<TodoUpdateResponse> Handle(TodoUpdateModel request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<TodoModel>(request);
            todo = _todoRepository.Update(todo);
            _uow.Commit();
            return Task.FromResult(new TodoUpdateResponse { Todo = todo });
        }
    }
}
