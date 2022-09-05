using Audit.API.Protos;
using AutoMapper;
using TodoProject.Models;

namespace Todo.API.Services
{
    public class AuditService : IAuditService
    {
        private readonly AuditProtoService.AuditProtoServiceClient _auditClient;
        private readonly IMapper _mapper;

        public AuditService(AuditProtoService.AuditProtoServiceClient auditClient, IMapper mapper
            )
        {
            _auditClient = auditClient;
            _mapper = mapper;
        }

        public async Task<bool> Insert(AuditModel audit)
        {
            try
            {

                var insertRequest = _mapper.Map<InsertAuditRequest>(audit);
                return (await _auditClient.InsertAuditAsync(insertRequest)).Result;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
