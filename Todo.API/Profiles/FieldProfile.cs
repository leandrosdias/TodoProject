using AutoMapper;
using TodoProject.Models;
using static Audit.API.Protos.InsertAuditRequest.Types;

namespace Todo.API.Profiles
{
    public class FieldProfile : Profile
    {
        public FieldProfile()
        {
            CreateMap<Field, FieldRequest>().ReverseMap();
        }
    }
}
