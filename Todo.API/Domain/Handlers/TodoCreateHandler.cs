using AutoMapper;
using MediatR;
using Todo.API.Data;
using Todo.API.Data.Repositories;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Domain.Commands.Responses;
using Todo.API.Mappers;
using Todo.API.Models;
using Todo.API.Services;
using TodoProject.Models;

namespace Todo.API.Domain.Handlers
{
    public class TodoCreateHandler : IRequestHandler<TodoCreateModel, TodoCreateResponse>
    {
        private ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IAuditService _auditService;

        public TodoCreateHandler(ITodoRepository todoRepository, IMapper mapper, IUnitOfWork uow, IAuditService auditService)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
            _uow = uow;
            _auditService = auditService;
        }

        public Task<TodoCreateResponse> Handle(TodoCreateModel request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<TodoModel>(request);
            _todoRepository.Save(todo);
            _uow.Commit();
            _auditService.Insert(AuditMapper.GetAuditModel(todo, "Create"));
            return Task.FromResult(new TodoCreateResponse { Todo = todo });
        }

    }
}
