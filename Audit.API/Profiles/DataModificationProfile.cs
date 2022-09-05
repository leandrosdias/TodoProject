﻿using AutoMapper;
using TodoProject.Models;
using static Audit.API.Protos.InsertAuditRequest.Types;

namespace Audit.API.Profiles
{
    public class DataModificationProfile : Profile
    {
        public DataModificationProfile()
        {
            CreateMap<DataModification, DataModificationRequest>().ReverseMap();
        }
    }
}
