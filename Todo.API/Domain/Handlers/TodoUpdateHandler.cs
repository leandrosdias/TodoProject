using AutoMapper;
using MediatR;
using Todo.API.Data.Repositories;
using Todo.API.Data;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Domain.Commands.Responses;
using Todo.API.Models;
using Todo.API.Services;
using TodoProject.Models;
using Todo.API.Mappers;

namespace Todo.API.Domain.Handlers
{
    public class TodoUpdateHandler : IRequestHandler<TodoUpdateModel, TodoUpdateResponse>
    {
        private ITodoRepository _todoRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IAuditService _auditService;
        public TodoUpdateHandler(ITodoRepository todoRepository, IMapper mapper, IUnitOfWork uow, IAuditService auditService)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
            _uow = uow;
            _auditService = auditService;
        }

        public Task<TodoUpdateResponse> Handle(TodoUpdateModel request, CancellationToken cancellationToken)
        {
            var todo = _mapper.Map<TodoModel>(request);
            var oldTodo = _todoRepository.FindById(request.Id);
            var audit = AuditMapper.GetAuditModel(todo, "Update", oldTodo);

            todo = _todoRepository.Update(todo);
            _auditService.Insert(audit);
            _uow.Commit();
            return Task.FromResult(new TodoUpdateResponse { Todo = todo });
        }

    }
}
