using TodoProject.Models;

namespace Todo.API.Services
{
    public interface IAuditService
    {
        Task<bool> Insert(AuditModel audit);
    }
}
