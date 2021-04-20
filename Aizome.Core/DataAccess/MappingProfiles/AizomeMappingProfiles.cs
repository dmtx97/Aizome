using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizome.Core.DataAccess.DTO;
using Aizome.Core.DataAccess.Entities;
using AutoMapper;

namespace Aizome.Core.DataAccess.MappingProfiles
{
    public class AizomeMappingProfiles : Profile
    {
        public AizomeMappingProfiles()
        {
            CreateMap<Timeline, TimelineDTO>();
            CreateMap<TimelineCreateDTO, Timeline>();
        }
    }
}
