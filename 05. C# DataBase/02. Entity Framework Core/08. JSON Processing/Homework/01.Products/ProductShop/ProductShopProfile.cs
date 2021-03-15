using AutoMapper;
using ProductShop.Models;
using ProductShop.Models.DataTransferObjects;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<UserInputModel, User>();
            this.CreateMap<ProductInputModel, Product>();
            this.CreateMap<CategoryInputModel, Category>();
            this.CreateMap<CategoriesProductsInputModel, CategoryProduct>();
            this.CreateMap<Product, ProductOutputModel>()
                .ForMember(x => x.seller, y => y.MapFrom(s => s.Seller.FirstName + " " + s.Seller.LastName));

                
        }
    }
}
