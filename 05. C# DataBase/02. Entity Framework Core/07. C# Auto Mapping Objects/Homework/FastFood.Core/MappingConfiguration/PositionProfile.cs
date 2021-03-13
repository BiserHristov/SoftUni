using AutoMapper;
using FastFood.Core.ViewModels.Positions;
using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Core.MappingConfiguration
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));
        }
    }
}
