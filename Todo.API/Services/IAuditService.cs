using TodoProject.Models;

namespace Todo.API.Services
{
    public interface IAuditService
    {
        Task Insert(AuditModel audit);
    }
}
