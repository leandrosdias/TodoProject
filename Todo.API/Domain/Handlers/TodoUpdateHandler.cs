using AutoMapper;
using MediatR;
using Todo.API.Data.Repositories;
using Todo.API.Data;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Domain.Commands.Responses;
using Todo.API.Models;
using Todo.API.Services;
using TodoProject.Models;

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
            todo = _todoRepository.Update(todo);
            SendAudit(todo.Id);
            _uow.Commit();
            return Task.FromResult(new TodoUpdateResponse { Todo = todo });
        }

        private void SendAudit(int id)
        {
            var audit = new AuditModel
            {
                User = Guid.NewGuid().ToString(),
                Entity = id,
                Operation = "Update",
            };

            _auditService.Insert(audit);
        }
    }
}
