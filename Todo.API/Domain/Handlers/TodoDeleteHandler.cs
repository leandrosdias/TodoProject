using MediatR;
using Todo.API.Data.Repositories;
using Todo.API.Data;
using Todo.API.Domain.Commands.Requests;
using Todo.API.Domain.Commands.Responses;
using AutoMapper;
using Todo.API.Services;
using Todo.API.Models;
using TodoProject.Models;
using Todo.API.Mappers;

namespace Todo.API.Domain.Handlers
{
    public class TodoDeleteHandler : IRequestHandler<TodoDeleteModel, TodoDeleteResponse>
    {
        private ITodoRepository _todoRepository;
        private readonly IUnitOfWork _uow;
        private readonly IAuditService _auditService;

        public TodoDeleteHandler(ITodoRepository todoRepository, IUnitOfWork uow, IAuditService auditService)
        {
            _todoRepository = todoRepository;
            _uow = uow;
            _auditService = auditService;
        }

        public Task<TodoDeleteResponse> Handle(TodoDeleteModel request, CancellationToken cancellationToken)
        {
            _todoRepository.Delete(request.Id);
            _auditService.Insert(AuditMapper.GetAuditModel(request.Id, "Delete"));
            _uow.Commit();
            return Task.FromResult(new TodoDeleteResponse());
        }

    }
}
