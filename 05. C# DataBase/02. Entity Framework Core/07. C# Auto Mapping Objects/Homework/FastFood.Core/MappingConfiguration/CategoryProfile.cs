using AutoMapper;
using FastFood.Core.ViewModels.Categories;
using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Core.MappingConfiguration
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            this.CreateMap<CreateCategoryInputModel, Category>()
               .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

            this.CreateMap<Category, CategoryAllViewModel>();
        }
    }
}
