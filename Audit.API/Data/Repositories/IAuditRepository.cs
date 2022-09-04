using Audit.API.Models;

namespace Audit.API.Data.Repositories
{
    public interface IAuditRepository
    {
        void Insert(AuditModel audit);
    }
}
