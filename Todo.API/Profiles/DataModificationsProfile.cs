using AutoMapper;
using TodoProject.Models;
using static Audit.API.Protos.InsertAuditRequest.Types;

namespace Todo.API.Profiles
{
    public class DataModificationsProfile : Profile
    {
        public DataModificationsProfile()
        {
            CreateMap<DataModification, DataModificationRequest>().ReverseMap();
        }
    }
}
