using Audit.API.Data.Repositories;
using Audit.API.Protos;
using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using TodoProject.Models;

namespace Audit.API.Services
{
    public class AuditService : AuditProtoService.AuditProtoServiceBase
    {
        public IAuditRepository _auditRepository { get; set; }
        public IMapper _mapper { get; set; }
        public AuditService(IAuditRepository auditRepository, IMapper mapper)
        {
            _auditRepository = auditRepository ?? throw new ArgumentNullException(nameof(auditRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public override Task<InsertResponse> InsertAudit(InsertAuditRequest request, ServerCallContext context)
        {
            var audit = _mapper.Map<AuditModel>(request);
            _auditRepository.Insert(audit);

            return Task.FromResult(new InsertResponse { Result = true });
        }
    }
}
