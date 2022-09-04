using MediatR;
using Todo.API.Data.Repositories;
using Todo.API.Data;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Domain.Commands.Responses;
using AutoMapper;

namespace Todo.API.Domain.Handlers
{
    public class TodoDeleteHandler : IRequestHandler<TodoDeleteModel, TodoDeleteResponse>
    {
        private ITodoRepository _todoRepository;
        private readonly IUnitOfWork _uow;

        public TodoDeleteHandler(ITodoRepository todoRepository, IUnitOfWork uow)
        {
            _todoRepository = todoRepository;
            _uow = uow;
        }

        public Task<TodoDeleteResponse> Handle(TodoDeleteModel request, CancellationToken cancellationToken)
        {
            _todoRepository.Delete(request.Id);
            _uow.Commit();
            return Task.FromResult(new TodoDeleteResponse());
        }
    }
}
