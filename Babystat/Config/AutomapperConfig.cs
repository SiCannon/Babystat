using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Babystat.Data.Entity;
using Babystat.Models.BabyViewModels;

namespace Babystat.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() : base()
        {
            CreateMap<Baby, BabyIndexItemVm>();
        }
    }
}
