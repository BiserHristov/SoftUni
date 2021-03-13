using AutoMapper;
using FastFood.Core.ViewModels.Items;
using FastFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFood.Core.MappingConfiguration
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));
        }
    }
}
