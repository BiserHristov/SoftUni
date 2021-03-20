using AutoMapper;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //Import
            this.CreateMap<SuppliersInputModel, Supplier>();
            this.CreateMap<PartsInputModel, Part>();
            this.CreateMap<CarsInputModel, Car>()
                .ForMember(x => x.TravelledDistance, y => y.MapFrom(s => s.TraveledDistance));
            this.CreateMap<PartCarInputModel, PartCar>()
                .ForMember(x => x.PartId, y => y.MapFrom(s => s.Id));
            this.CreateMap<CustomerInputModel, Customer>();
            this.CreateMap<SaleInputModel, Sale>();

            //Export
            this.CreateMap<Car, CarOutputModel>();
            this.CreateMap<Car, CarBMWOutputModel>();
            this.CreateMap<Supplier, SupplierOutputModel>()
                .ForMember(x => x.PartsCount, y => y.MapFrom(s => s.Parts.Count));

            this.CreateMap<PartCar, PartOutputModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Part.Name))
                .ForMember(x => x.Price, y => y.MapFrom(s => s.Part.Price));

            this.CreateMap<Car, CarWithPartsOutputModel>()
                .ForMember(x => x.Parts, y => y.MapFrom(s => s.PartCars.OrderByDescending(p => p.Part.Price)));

            this.CreateMap<Customer, CustomerOutputModel>()
                .ForMember(x => x.FullName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.BoughtCars, y => y.MapFrom(s => s.Sales.Count))
                .ForMember(x => x.SpentMoney, y => y.MapFrom(s => s.Sales.SelectMany(d => d.Car.PartCars.Select(pc => pc.Part.Price)).Sum()));







        }
    }
}
