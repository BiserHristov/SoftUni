using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private static IMapper mapper;

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            string result = string.Empty;

            //var xmlSuppliers = File.ReadAllText("Datasets/suppliers.xml");
            //var xmlParts = File.ReadAllText("Datasets/parts.xml");
            //var xmlCars = File.ReadAllText("Datasets/cars.xml");
            //var xmlCustomers = File.ReadAllText("Datasets/customers.xml");
            //var xmlSales = File.ReadAllText("Datasets/sales.xml");


            //ImportSuppliers(db, xmlSuppliers);
            //ImportParts(db, xmlParts);
            //ImportCars(db, xmlCars);
            //ImportCustomers(db, xmlCustomers);
            //ImportSales(db, xmlSales);
            result = GetTotalSalesByCustomer(db);




            Console.WriteLine(result);

        }


        /*Task 18: Total Sales by Customer
         Get all customers that have bought at least 1 car and get their names, bought cars count and total spent money on cars. Order the result list by total spent money descending.
        Return the list of suppliers to XML in the format provided below.
        */

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            InitializeAutoMapper();

            var customers = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .ProjectTo<CustomerOutputModel>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.SpentMoney)
                .ToList();


            var xml = XmlConverter.Serialize(customers, "customers");

            return xml;

        }




        /*Таск 17: Cars with Their List of Parts
         Get all cars along with their list of parts. For the car get only make, model and travelled distance and for the parts get only name and price and sort all parts by price (descending). Sort all cars by travelled distance (descending) then by model (ascending). Select top 5 records.
         Return the list of suppliers to XML in the format provided below.
        */

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            InitializeAutoMapper();

            var cars = context.Cars
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<CarWithPartsOutputModel>(mapper.ConfigurationProvider)
                .ToList();

            var xml = XmlConverter.Serialize(cars, "cars");

            return xml;
        }



        /*Task 16: Local Suppliers
         Get all suppliers that do not import parts from abroad. Get their id, name and the number of parts they can offer to supply. 
         Return the list of suppliers to XML in the format provided below.
         */
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            InitializeAutoMapper();

            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<SupplierOutputModel>(mapper.ConfigurationProvider)
                .ToList();

            const string root = "suppliers";

            var xml = XmlConverter.Serialize(suppliers, root);

            return xml;
        }





        /*Task 15: Cars from make BMW
         * Get all cars from make BMW and order them by model alphabetically and by travelled distance descending.
        Return the list of suppliers to XML in the format provided below.
        */
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            InitializeAutoMapper();

            var BMWCars = context.Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ProjectTo<CarBMWOutputModel>(mapper.ConfigurationProvider)
                .ToList();

            const string root = "cars";
            var serializer = new XmlSerializer(typeof(List<CarBMWOutputModel>), new XmlRootAttribute(root));
            var stringWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(stringWriter, BMWCars, ns);

            return stringWriter.ToString().Trim();
        }



        /*Task 14: Cars With Distance
         Get all cars with distance more than 2,000,000. Order them by make, then by model alphabetically. Take top 10 records.
        Return the list of suppliers to XML in the format provided below.
        */
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            InitializeAutoMapper();

            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<CarOutputModel>(mapper.ConfigurationProvider)
                .ToList();

            const string root = "cars";
            var serializer = new XmlSerializer(typeof(List<CarOutputModel>), new XmlRootAttribute(root));
            var stringWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(stringWriter, cars, ns);

            return stringWriter.ToString().Trim();


        }



        /*Task 13: Import Sales
         Import the sales from the provided file sales.xml. If car doesn’t exists, skip whole entity.
         Your method should return string with message $"Successfully imported {sales.Count}";
        */

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            const string root = "Sales";
            var serializer = new XmlSerializer(typeof(List<SaleInputModel>), new XmlRootAttribute(root));
            var deserializedSales = serializer.Deserialize(new StringReader(inputXml)) as List<SaleInputModel>;

            var carIDs = context.Cars
               .Select(x => x.Id)
               .ToList();

            deserializedSales = deserializedSales
                .Where(c => carIDs.Contains(c.carId))
                .ToList();

            var sales = mapper.Map<List<Sale>>(deserializedSales);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }




        /*Task 12: Import Customers
         Import the customers from the provided file customers.xml.
         Your method should return string with message $"Successfully imported {customers.Count}";
         */

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            const string root = "Customers";
            var serializer = new XmlSerializer(typeof(List<CustomerInputModel>), new XmlRootAttribute(root));
            var deserializedCustomers = serializer.Deserialize(new StringReader(inputXml)) as List<CustomerInputModel>;

            var customers = mapper.Map<List<Customer>>(deserializedCustomers);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";

        }


        /*Task 11: Import Cars
         Import the cars from the provided file cars.xml. Select unique car part ids. If the part id doesn’t exists, skip the part record.
         Your method should return string with message $"Successfully imported {cars.Count}";
        */
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            const string root = "Cars";
            var serializer = new XmlSerializer(typeof(List<CarsInputModel>), new XmlRootAttribute(root));
            var deserializedCars = serializer.Deserialize(new StringReader(inputXml)) as List<CarsInputModel>;
            var partIDs = context.Parts
                .Select(p => p.Id)
                .ToList();

            deserializedCars = deserializedCars

               .Select(c => new CarsInputModel
               {
                   Make = c.Make,
                   Model = c.Model,
                   TraveledDistance = c.TraveledDistance,
                   PartCars = c.PartCars
                               .Select(p => p.Id)
                               .Distinct()
                               .Where(id => partIDs.Contains(id))
                               .Select(id => new PartCarInputModel
                               {
                                   Id = id
                               })
                               .ToList()

               })
               .ToList();

            var cars = mapper.Map<List<Car>>(deserializedCars);

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";

        }


        /*Task 10: Import Parts
         Import the parts from the provided file parts.xml. If the supplierId doesn’t exists, skip the record.
         Your method should return string with message $"Successfully imported {parts.Count}";
         */
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            const string root = "Parts";
            var serializer = new XmlSerializer(typeof(List<PartsInputModel>), new XmlRootAttribute(root));
            var deserializedParts = serializer.Deserialize(new StringReader(inputXml)) as List<PartsInputModel>;

            var suppliersIDs = context.Suppliers
                .Select(s => s.Id)
                .ToList();

            deserializedParts = deserializedParts
                .Where(p => suppliersIDs.Contains(p.SupplierId))
                .ToList();

            var parts = mapper.Map<List<Part>>(deserializedParts);

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";

        }



        /*Task 9: Import Suppliers
        Import the suppliers from the provided file suppliers.xml.
        Your method should return string with message $"Successfully imported {suppliers.Count}";
        */
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();

            const string root = "Suppliers";
            var serializer = new XmlSerializer(typeof(List<SuppliersInputModel>), new XmlRootAttribute(root));
            var deserializedSuppliers = (List<SuppliersInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var suppliers = mapper.Map<List<Supplier>>(deserializedSuppliers);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";

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
