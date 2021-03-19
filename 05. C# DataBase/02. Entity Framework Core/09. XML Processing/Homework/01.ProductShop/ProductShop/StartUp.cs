using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop
{

    public class StartUp
    {
        public static IMapper mapper;
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();

            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
            string result = string.Empty;

            //var xmlUsers = File.ReadAllText("Datasets/users.xml");
            //var xmlProducts = File.ReadAllText("Datasets/products.xml");
            //var xmlcategories = File.ReadAllText("Datasets/categories.xml");
            //var xmlcategoriesProducts = File.ReadAllText("Datasets/categories-products.xml");

            //ImportUsers(db, xmlUsers);
            //ImportProducts(db, xmlProducts);
            //ImportCategories(db, xmlcategories);
            //ImportCategoryProducts(db, xmlcategoriesProducts);

            //Task 5
            //result = GetProductsInRange(db);

            //Task 6
            //result = GetSoldProducts(db);

            //Task 7
            //result = GetCategoriesByProductsCount(db);

            //Task 8
            result = GetUsersWithProducts(db);

            Console.WriteLine(result);
        }

        /*Task 8: Users and Products
         Select users who have at least 1 sold product. Order them by the number of sold products (from highest to lowest). Select only their first and last name,
         age, count of sold products and for each product - name and price sorted by price (descending). Take top 10 records.
        Follow the format below to better understand how to structure your data. 
        Return the list of suppliers to XML in the format provided below.
        */

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string root = "Users";

            var users = new UserRootDTO
            {
                Count = context.Users.Count(u => u.ProductsSold.Count >= 1),
                Users = context.Users
                .ToList() // or else InMemoryException in Softuni Judge!
                .Where(u => u.ProductsSold.Count >= 1)
                .Select(u => new UserOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new UserAndProductsSoldProductsOutputModel
                    {
                        Count = u.ProductsSold.Count(),
                        Products = u.ProductsSold
                        .Select(pp => new ProductsOutputModel
                        {
                            Name = pp.Name,
                            Price = pp.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToList()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .Take(10)
                .ToList()
            };



            var serializer = new XmlSerializer(typeof(UserRootDTO), new XmlRootAttribute(root));
            var stringWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(stringWriter, users, ns);

            return stringWriter.ToString().Trim();
        }





        /*Task 7: Categories By Products Count
         Get all categories. For each category select its name, the number of products, the average price of those products and the total revenue 
        (total price sum) of those products (regardless if they have a buyer or not). Order them by the number of products (descending) then by total revenue.
         Return the list of suppliers to XML in the format provided below.
        */

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            InitializeAutoMapper();
            const string root = "Categories";

            var categories = context.Categories
                .ProjectTo<CategoriesByProductsCountOutputModel>(mapper.ConfigurationProvider)
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<CategoriesByProductsCountOutputModel>), new XmlRootAttribute(root));
            var stringWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(stringWriter, categories, ns);

            return stringWriter.ToString().Trim();
        }

        /*Task 6: Sold Products
         Get all users who have at least 1 sold item. Order them by last name, then by first name. 
        Select the person's first and last name. For each of the sold products, select the product's name and price. 
        Take top 5 records. 
            Return the list of suppliers to XML in the format provided below.
        */

        public static string GetSoldProducts(ProductShopContext context)
        {
            InitializeAutoMapper();
            const string root = "Users";

            var users = context.Users
                .Where(u => u.ProductsSold.Count >= 1)
                .ProjectTo<UserSoldProductsOutputModel>(mapper.ConfigurationProvider)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<UserSoldProductsOutputModel>), new XmlRootAttribute(root));
            var stringWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(stringWriter, users, ns);

            return stringWriter.ToString().Trim();
        }


        /*Task 5: Products In Range
        Get all products in a specified price range between 500 and 1000 (inclusive). Order them by price (from lowest to highest). Select only the product name, price and the full name of the buyer. Take top 10 records.
         Return the list of suppliers to XML in the format provided below.
         */
        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeAutoMapper();
            const string root = "Products";

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ProductInRangeOutputModel>(mapper.ConfigurationProvider)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ProductInRangeOutputModel>), new XmlRootAttribute(root));
            var stringWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(stringWriter, products, ns);


            return stringWriter.ToString();
        }



        //Task 4: Import Categories and Products
        /*Import the categories and products ids from the provided file categories-products.xml. If provided category or product id, doesn’t exists, skip the whole entry!
          Your method should return string with message $"Successfully imported {CategoryProducts.Count}";
           */

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            const string root = "CategoryProducts";
            var serializer = new XmlSerializer(typeof(List<CategoryProductInputModel>), new XmlRootAttribute(root));
            var deserializedCategoriesProducts = (List<CategoryProductInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var categoriesId = context.Categories
                .Select(c => c.Id)
                .ToList();

            var productsId = context.Products
                .Select(x => x.Id)
                .ToList();

            var categoriesProducts = mapper.Map<List<CategoryProduct>>(deserializedCategoriesProducts)
                .Where(c => categoriesId.Contains(c.CategoryId) &&
                            productsId.Contains(c.ProductId))
                .ToList();

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count}";

        }


        //Task 3: Import Categories
        /*
        Import the categories from the provided file categories.xml. 
        Some of the names will be null, so you don’t have to add them in the database. Just skip the record and continue.
        Your method should return string with message $"Successfully imported {Categories.Count}";
         */

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            const string root = "Categories";
            var serializer = new XmlSerializer(typeof(List<CategoryInputModel>), new XmlRootAttribute(root));
            var deserializedCategories = (List<CategoryInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var categories = mapper.Map<List<Category>>(deserializedCategories)
                .Where(c => c.Name != null)
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";

        }


        //Task 2: Import Products
        /*
        Import the products from the provided file products.xml.
        Your method should return string with message $"Successfully imported {Products.Count}";
        */
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            const string root = "Products";
            var serializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute(root));
            var deserializedProducts = serializer.Deserialize(new StringReader(inputXml)) as ProductInputModel[];

            var products = mapper.Map<Product[]>(deserializedProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }



        //Task 1: Import Users
        /*
         Import the users from the provided file users.xml.
         Your method should return string with message $"Successfully imported {Users.Count}";
        */
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();


            const string root = "Users";
            var serializer = new XmlSerializer(typeof(List<UserInputModel>), new XmlRootAttribute(root));
            var deserializedUsers = (List<UserInputModel>)serializer.Deserialize(new StringReader(inputXml));

            var users = mapper.Map<List<User>>(deserializedUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";

        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}