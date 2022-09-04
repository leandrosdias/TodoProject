using AutoMapper;
using static Audit.API.Protos.InsertAuditRequest.Types;

namespace Audit.API.Profiles
{
    public class DataModificationProfile : Profile
    {
        public DataModificationProfile()
        {
            CreateMap<DataModificationProfile, DataModificationRequest>();
        }
    }
}
