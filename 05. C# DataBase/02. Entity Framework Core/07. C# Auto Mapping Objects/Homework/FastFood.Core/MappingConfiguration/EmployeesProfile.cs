using AutoMapper;
using FastFood.Core.ViewModels.Employees;
using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Core.MappingConfiguration
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));
        }
    }
}
