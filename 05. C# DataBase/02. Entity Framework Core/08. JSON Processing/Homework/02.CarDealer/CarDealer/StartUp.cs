using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            string result = string.Empty;

            //Task: 8
            //string jsonSuppliers = File.ReadAllText("Datasets/suppliers.json");
            //string jsonParts = File.ReadAllText("Datasets/parts.json");
            //string jsonCars = File.ReadAllText("Datasets/cars.json");
            //string jsonCustomer = File.ReadAllText("Datasets/customers.json");
            //string jsonSales = File.ReadAllText("Datasets/sales.json");

            //ImportSuppliers(db, jsonSuppliers);
            //ImportParts(db, jsonParts);
            //ImportCars(db, jsonCars);
            //ImportCustomers(db, jsonCustomer);
            //ImportSales(db, jsonSales);


            result = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(result);
        }
        //Task 18
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new
                {
                    car = new
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    Discount = s.Discount.ToString("F2"),
                    price = (s.Car.PartCars.Sum(pc => pc.Part.Price)).ToString("F2"),
                    priceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) * ((100 - s.Discount) / 100)).ToString("F2")

                })
                .Take(10)
                .ToList();


            var jsonSales = JsonConvert.SerializeObject(sales, Formatting.Indented);
            return jsonSales;
        }

        //Task 17
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new
                {
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToList();

            var jsoncustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return jsoncustomers;
        }


        //Task 16
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("F2")
                    }).ToList()
                })
               .ToList();

            var jsonCars = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return jsonCars;


        }

        //Task 15
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToList();


            var jsonSuppliers = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return jsonSuppliers;
        }

        //Task 14
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyotaCars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .ToList();

            var jsonToyotaCars = JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
            return jsonToyotaCars;

        }

        //Task 13 
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver
                })

                .ToList();

            var jsoncustomers = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return jsoncustomers;
        }

        //Task 12
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var salesDTO = JsonConvert.DeserializeObject<IEnumerable<SalesInputModel>>(inputJson);

            var sales = mapper.Map<IEnumerable<Sale>>(salesDTO);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";


        }



        //Task 11
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var customersDTO = JsonConvert.DeserializeObject<IEnumerable<CustomerInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDTO);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";



        }


        //Task 10
        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            var carsDTO = JsonConvert.DeserializeObject<IEnumerable<CarInputModel>>(inputJson);

            var cars = new List<Car>();

            foreach (var car in carsDTO)
            {
                var currentCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car.PartsId.Distinct())
                {
                    var partCar = new PartCar
                    {
                        PartId = partId
                    };

                    currentCar.PartCars.Add(partCar);
                }

                cars.Add(currentCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}."; ;

        }


        //Task 9

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();
            var supplierIds = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            var partsDTO = JsonConvert.DeserializeObject<IEnumerable<PartInputModel>>(inputJson)
                .Where(x => supplierIds.Contains(x.SupplierId))
                .ToList();

            var parts = mapper.Map<IEnumerable<Part>>(partsDTO);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}."; ;
        }

        //Task 8
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeAutoMapper();

            var suppliersDTO = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(suppliersDTO);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}."; ;
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}