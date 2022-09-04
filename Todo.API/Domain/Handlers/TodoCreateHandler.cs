using AutoMapper;
using MediatR;
using Todo.API.Data;
using Todo.API.Data.Repositories;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Domain.Commands.Responses;
using Todo.API.Models;

namespace Todo.API.Domain.Handlers
{
    public class TodoCreateHandler : IRequestHandler<TodoCreateModel, TodoCreateResponse>
    {
        private ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        public TodoCreateHandler(ITodoRepository todoRepository, IMapper mapper, IUnitOfWork uow)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
            _uow = uow;
        }

        public Task<TodoCreateResponse> Handle(TodoCreateModel request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<TodoModel>(request);
            _todoRepository.Save(todo);
            _uow.Commit();
            return Task.FromResult(new TodoCreateResponse { Todo = todo });
        }
    }
}
