﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
//using Newtonsoft.Json;
//using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using ProductShop.Models.DataTransferObjects;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        // static ProductShopContext db;
        public static void Main(string[] args)
        {


            var db = new ProductShopContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            string result = string.Empty;

            //Task 2
            //string jsonString = File.ReadAllText(@"..\..\..\Datasets\users.json");
            //result = ImportUsers(db, jsonString);

            //Task 3
            //string usersJson = File.ReadAllText(@"..\..\..\Datasets\users.json");
            //ImportUsers(db, usersJson);
            //string productsJson = File.ReadAllText(@"..\..\..\Datasets\products.json");
            //result = ImportProducts(db, productsJson);

            //Task 4
            //string categoriesJson = File.ReadAllText(@"..\..\..\Datasets\categories.json");
            //result = ImportCategories(db, categoriesJson);

            //Task 5
            //string usersJson = File.ReadAllText(@"..\..\..\Datasets\users.json");
            //string productsJson = File.ReadAllText(@"..\..\..\Datasets\products.json");
            //string categoriesJson = File.ReadAllText(@"..\..\..\Datasets\categories.json");
            //string categoriesProductsJson = File.ReadAllText(@"..\..\..\Datasets\categories-products.json");

            //ImportUsers(db, usersJson);
            //ImportProducts(db, productsJson);
            //ImportCategories(db, categoriesJson);
            //result = ImportCategoryProducts(db, categoriesProductsJson);

            //Task 6
            string usersJson = File.ReadAllText(@"..\..\..\Datasets\users.json");
            string productsJson = File.ReadAllText(@"..\..\..\Datasets\products.json");
            string categoriesJson = File.ReadAllText(@"..\..\..\Datasets\categories.json");
            string categoriesProductsJson = File.ReadAllText(@"..\..\..\Datasets\categories-products.json");

            ImportUsers(db, usersJson);
            ImportProducts(db, productsJson);
            ImportCategories(db, categoriesJson);
            ImportCategoryProducts(db, categoriesProductsJson);

            result = GetProductsInRange(db);

            Console.WriteLine(result);

        }

        //Task 6
        public static string GetProductsInRange(ProductShopContext context)
        {
            InitializeautoMapper();

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ProductOutputModel>(mapper.ConfigurationProvider)
                .ToList();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);

            return jsonProducts;
        }



        //Task 5
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeautoMapper();

            var categoriestProductsDTO = JsonConvert.DeserializeObject<IEnumerable<CategoriesProductsInputModel>>(inputJson);
            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(categoriestProductsDTO);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }


        //Task 4
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeautoMapper();

            var categoriesDTO = JsonConvert
                .DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null).ToList();

            var categories = mapper.Map<IEnumerable<Category>>(categoriesDTO);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }


        //Task 3
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeautoMapper();

            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true,
            //    NumberHandling = JsonNumberHandling.AllowReadingFromString
            //};

            var productsDTO = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);
            var products = mapper.Map<IEnumerable<Product>>(productsDTO);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";



        }

        //Task 2
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeautoMapper();

            //var options = new JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true,
            //    NumberHandling = JsonNumberHandling.AllowReadingFromString
            //};
            //var usersDto = JsonSerializer.Deserialize<IEnumerable<UserInputModel>>(inputJson, options);

            //ANOTHER SOLUTION WITH USING JSON.NET
            var usersDto = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);
            var users = mapper.Map<IEnumerable<User>>(usersDto);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
        private static void InitializeautoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }


    }
}