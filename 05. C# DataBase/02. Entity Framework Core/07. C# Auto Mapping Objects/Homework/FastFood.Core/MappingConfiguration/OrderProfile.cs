namespace FastFood.Core.MappingConfiguration
{
    using AutoMapper;
    using FastFood.Models;
    using ViewModels.Positions;
    using ViewModels.Categories;
    using FastFood.Core.ViewModels.Employees;
    using FastFood.Core.ViewModels.Items;
    using FastFood.Core.ViewModels.Orders;
    using System.Linq;
    using System;
    using FastFood.Models.Enums;

    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            //Positions
            //this.CreateMap<CreatePositionInputModel, Position>()
            //    .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            //this.CreateMap<Position, PositionsAllViewModel>()
            //    .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Categories
            //this.CreateMap<CreateCategoryInputModel, Category>()
            //   .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));


            //this.CreateMap<Category, CategoryAllViewModel>();

            //Employees
            //this.CreateMap<Position, RegisterEmployeeViewModel>()
            //    .ForMember(x => x.PositionId, y => y.MapFrom(s => s.Id));

            //this.CreateMap<RegisterEmployeeInputModel, Employee>();

            //this.CreateMap<Employee, EmployeesAllViewModel>()
            //    .ForMember(x => x.Position, y => y.MapFrom(s => s.Position.Name));

            //Items
            //this.CreateMap<Category, CreateItemViewModel>()
            //    .ForMember(x => x.CategoryId, y => y.MapFrom(s => s.Id));

            //this.CreateMap<CreateItemInputModel, Item>();

            //this.CreateMap<Item, ItemsAllViewModels>()
            //    .ForMember(x => x.Category, y => y.MapFrom(s => s.Category.Name));

            //Orders
            this.CreateMap<CreateOrderInputModel, Order>()
            .ForMember(x => x.DateTime, y => y.MapFrom(s => DateTime.UtcNow))
            .ForMember(x => x.Type, y => y.MapFrom(s => OrderType.ForHere));

            this.CreateMap<CreateOrderInputModel, OrderItem>();


            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.Employee, y => y.MapFrom(s => s.Employee.Name))
                .ForMember(x => x.OrderId, y => y.MapFrom(s => s.Id))
                .ForMember(x => x.DateTime, y => y.MapFrom(s => s.DateTime.ToString("dd-MM-yyyy")));
        }
    }
}
