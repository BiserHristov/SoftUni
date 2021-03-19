using AutoMapper;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Linq;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategoryInputModel, Category>();
            this.CreateMap<CategoryProductInputModel, CategoryProduct>();

            this.CreateMap<Product, ProductInRangeOutputModel>()
                .ForMember(p => p.Buyer, x => x.MapFrom(s => s.Buyer.FirstName + " " + s.Buyer.LastName));

            this.CreateMap<Product, SoldProductOutputModel>();
            this.CreateMap<User, UserSoldProductsOutputModel>();

            this.CreateMap<Category, CategoriesByProductsCountOutputModel>()
                .ForMember(x => x.Count, y => y.MapFrom(z => z.CategoryProducts.Count))
                .ForMember(x => x.AveragePrice, y => y.MapFrom(z => z.CategoryProducts.Average(p => p.Product.Price)))
                .ForMember(x => x.TotalRevenue, y => y.MapFrom(z => z.CategoryProducts.Sum(p => p.Product.Price)));


            




        }
    }
}
