using Audit.API.Protos;
using AutoMapper;
using Microsoft.Extensions.Logging;
using TodoProject.Models;

namespace Todo.API.Services
{
    public class AuditService : IAuditService
    {
        private readonly AuditProtoService.AuditProtoServiceClient _auditClient;
        private readonly IMapper _mapper;
        private ILogger<AuditService> _logger;

        public AuditService(AuditProtoService.AuditProtoServiceClient auditClient, IMapper mapper, ILogger<AuditService> logger)
        {
            _auditClient = auditClient;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Insert(AuditModel audit)
        {
            try
            {
                var insertRequest = _mapper.Map<InsertAuditRequest>(audit);

                var success = (await _auditClient.InsertAuditAsync(insertRequest)).Result;
                if (!success)
                {
                    _logger.LogInformation("Erro ao chamar AuditRequest");
                }
            }
            catch (Exception e)
            {
                _logger.LogInformation("Exception ao chamar AuditRequest");
                _logger.LogInformation("Message: " + e.Message);
                _logger.LogInformation("Trace: " + e.StackTrace);
            }
        }
    }
}
