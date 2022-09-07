using Audit.API.Protos;
using AutoMapper;
using TodoProject.Models;

namespace Todo.API.Profiles
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditModel, InsertAuditRequest>().ReverseMap();
        }
    }
}
