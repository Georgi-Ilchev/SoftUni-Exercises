using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var usersJson = File.ReadAllText("../../../Datasets/users.json");
            //var productJson = File.ReadAllText("../../../Datasets/products.json");
            //var categoryJson = File.ReadAllText("../../../Datasets/categories.json");
            //var categoryProductJson = File.ReadAllText("../../../Datasets/categories-products.json");

            //3
            //ImportUsers(context, usersJson);
            //var result = ImportProducts(context, productJson);

            //4
            //ImportUsers(context, usersJson);
            //ImportProducts(context, productJson);
            //var result = ImportCategories(context, categoryJson);

            //5
            //ImportUsers(context, usersJson);
            //ImportProducts(context, productJson);
            //ImportCategories(context, categoryJson);
            //var result = ImportCategoryProducts(context, categoryProductJson);
            //Console.WriteLine(result);


            //05. Export Products In Range
            //var result = GetProductsInRange(context);

            //06. Export Sold Products
            //var result = GetSoldProducts(context);

            //07. Export Categories By Products Count
            //var result = GetCategoriesByProductsCount(context);

            //08. Export Users and Products
            var result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //var users = context.Users
            //    .ToList() //tolist for judge!
            //    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            //    .Select(u => new
            //    {
            //        firstName = u.FirstName,
            //        lastName = u.LastName,
            //        age = u.Age,
            //        soldProducts = new
            //        {
            //            count = u.ProductsSold.Count(p => p.Buyer != null),
            //            products = u.ProductsSold.Where(p => p.Buyer != null).Select(p => new
            //            {
            //                name = p.Name,
            //                price = p.Price
            //            })
            //            .ToArray()
            //        },
            //    })
            //    .OrderByDescending(u => u.soldProducts.count)
            //    .ToArray();

            //var resultObj = new
            //{
            //    usersCount = users.Length,
            //    users = users,
            //};

            //var jsonSerializerSettings = new JsonSerializerSettings()
            //{
            //    NullValueHandling = NullValueHandling.Ignore,
            //    Formatting = Formatting.Indented,

            //};

            //var result = JsonConvert.SerializeObject(users, jsonSerializerSettings);

            //return result;

            var users = context.Users
                .ToList()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold.Count(p => p.Buyer != null),
                        products = u.ProductsSold.Where(p => p.Buyer != null)
                                .Select(p => new
                                {
                                    name = p.Name,
                                    price = p.Price,
                                })
                                .ToArray()
                    },
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToArray();

            var result = new
            {
                usersCount = users.Length,
                users = users,
            };

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
            };

            var json = JsonConvert.SerializeObject(result, settings);

            return json;

        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Where(x => x != null && x.CategoryProducts.Count > 0)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Count == 0 ? 0.ToString("F2") :
                                        (c.CategoryProducts.Sum(p => p.Product.Price) / c.CategoryProducts.Count).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("F2"),
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result;
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold.Where(p => p.BuyerId != null).Select(b => new
                    {
                        name = b.Name,
                        price = b.Price,
                        buyerFirstName = b.Buyer.FirstName,
                        buyerLastName = b.Buyer.LastName
                    })
                    .ToList()
                })
                .OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToList();

            var result = JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .OrderBy(x => x.price)
                .ToList();

            var result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        //Query 5. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializaAutoMapper();

            var dtoCategoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoryProductInputModel>>(inputJson);

            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);

            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        //Query 4. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializaAutoMapper();

            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson)
                .Where(x => x.Name != null)
                .ToList();

            var categories = mapper.Map<IEnumerable<Category>>(dtoCategories);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        //Query 3. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializaAutoMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count()}";
        }

        //Query 2. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializaAutoMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }

        private static void InitializaAutoMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}