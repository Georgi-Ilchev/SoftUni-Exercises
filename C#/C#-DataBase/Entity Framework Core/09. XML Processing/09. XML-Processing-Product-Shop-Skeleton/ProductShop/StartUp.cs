using CarDealer.XMLHelper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //Query 1. Import Users
            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var result = ImportUsers(context, usersXml);
            //Console.WriteLine(result);

            //Query 2. Import Products
            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //ImportUsers(context, usersXml);
            //var result = ImportProducts(context, productsXml);
            //Console.WriteLine(result);

            //Query 3. Import Categories
            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //ImportUsers(context, usersXml);
            //ImportProducts(context, productsXml);
            //var result = ImportCategories(context, categoriesXml);
            //Console.WriteLine(result);

            //Query 4. Import Categories and Products
            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //ImportUsers(context, usersXml);
            //ImportProducts(context, productsXml);
            //ImportCategories(context, categoriesXml);
            //var result = ImportCategoryProducts(context, categoriesProductsXml);
            //Console.WriteLine(result);

            //Query 5. Products In Range
            //var result = GetProductsInRange(context);
            //Console.WriteLine(result);

            //Query 6. Sold Products
            //var result = GetSoldProducts(context);
            //Console.WriteLine(result);

            //Query 7. Categories By Products Count
            //var result = GetCategoriesByProductsCount(context);
            //Console.WriteLine(result);

            //Query 8.Users and Products
            var result = GetUsersWithProducts(context);
            Console.WriteLine(result);
        }
        //Query 8. Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //1
            const string root = "Users";

            var users = new UserRootDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any(p => p.Buyer != null)),
                Users = context.Users
                .ToArray()
                .Where(u => u.ProductsSold.Count > 0)
                .OrderByDescending(u => u.ProductsSold.Count)
                .Take(10)
                .Select(u => new UserExportDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsDto()
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                        .ToArray()
                        .Where(p => p.Buyer != null)
                        .Select(p => new ExportProductSoldDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .ToArray()
            };
            var result = XmlConverter.Serialize(users, root);
            return result;

            //2
            //StringBuilder sb = new StringBuilder();
            //var namespaces = new XmlSerializerNamespaces();
            //namespaces.Add(String.Empty, String.Empty);

            //var users = new UserRootDto()
            //{
            //    Count = context.Users.Count(u => u.ProductsSold.Any(p => p.Buyer != null)),
            //    Users = context.Users
            //        .ToArray()
            //        .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            //        .OrderByDescending(u => u.ProductsSold.Count)
            //        .Take(10)
            //        .Select(u => new UserExportDto()
            //        {
            //            FirstName = u.FirstName,
            //            LastName = u.LastName,
            //            Age = u.Age,
            //            SoldProducts = new SoldProductsDto()
            //            {
            //                Count = u.ProductsSold.Count(ps => ps.Buyer != null),
            //                Products = u.ProductsSold
            //                    .ToArray()
            //                    .Where(ps => ps.Buyer != null)
            //                    .Select(ps => new ExportProductSoldDto()
            //                    {
            //                        Name = ps.Name,
            //                        Price = ps.Price
            //                    })
            //                    .OrderByDescending(p => p.Price)
            //                    .ToArray()
            //            }
            //        })

            //        .ToArray()
            //};

            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserRootDto), new XmlRootAttribute("Users"));

            //xmlSerializer.Serialize(new StringWriter(sb), users, namespaces);

            //return sb.ToString().Trim();
        }

        //Query 7. Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            const string root = "Categories";

            var categories = context.Categories
                .Select(c => new ExportCategoriesByProductsCount()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToList();

            var result = XmlConverter.Serialize(categories, root);
            return result;
        }

        //Query 6. Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string root = "Users";

            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportSoldProducts
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold.Select(x => new ExportUserSoldProducts
                    {
                        Name = x.Name,
                        Price = x.Price
                    }).ToArray()
                })
                .ToArray();

            var result = XmlConverter.Serialize(users, root);
            return result;
        }

        //Query 5. Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string root = "Products";

            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Take(10)
                .Select(x => new ExportProductsInRange()
                {
                    Name = x.Name,
                    Price = x.Price,
                    FullName = x.Buyer.FirstName + " " + x.Buyer.LastName,
                })
                .ToArray();

            //1
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportProductsInRange[]), new XmlRootAttribute(root));

            xmlSerializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().Trim();

            //2
            //var result = XmlConverter.Serialize(products, root);
            //return result;
        }

        //Query 4. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string root = "CategoryProducts";

            var categoryProductDtos = XmlConverter.Deserializer<CategoryAndProductInputModel>(inputXml, root);

            List<CategoryProduct> categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductDtos)
            {
                var categories = context.Categories.Any(c => c.Id == categoryProductDto.CategoryId);
                var products = context.Products.Any(p => p.Id == categoryProductDto.ProductId);

                if (categories && products)
                {
                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryProductDto.CategoryId,
                        ProductId = categoryProductDto.ProductId
                    };
                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //Query 3. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string root = "Categories";

            var categoriesDto = XmlConverter.Deserializer<CategoriesInputModel>(inputXml, root);

            var categories = categoriesDto
                .Where(x => x.Name != null)
                .Select(x => new Category
                {
                    Name = x.Name
                })
                .ToList();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }

        //Query 2. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string root = "Products";

            var productsDto = XmlConverter.Deserializer<ProductsInputModel>(inputXml, root);

            var products = productsDto
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToList();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }

        //Query 1. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string root = "Users";

            var usersDto = XmlConverter.Deserializer<UsersInputModel>(inputXml, root);

            var users = usersDto
                .Select(x => new User
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age
                }).ToList();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }
    }
}