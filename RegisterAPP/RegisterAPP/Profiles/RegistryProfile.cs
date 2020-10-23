using AutoMapper;
using RegisterAPP.Dtos;
using RegisterAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAPP.Profiles
{
    public class RegistryProfile : Profile
    {
        public RegistryProfile()
        {
            //Map: Source -> Target
            CreateMap<Registry, DailyRegistryReadDto>();
            CreateMap<Registry, TermReportReadDto>();

            CreateMap<DailyRegistryCreateDto, Registry>();
        }

    }
}
