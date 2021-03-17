using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Input;
using CarDealer.DTO.Output;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //Query 9. Import Suppliers
            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var result = ImportSuppliers(context, suppliersXml);

            //Query 10. Import Parts
            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //ImportSuppliers(context, suppliersXml);
            //var result = ImportParts(context, partsXml);

            //Query 11. Import Cars
            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //ImportSuppliers(context, suppliersXml);
            //ImportParts(context, partsXml);
            //var result = ImportCars(context, carsXml);

            //Query 12. Import Customers
            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //ImportSuppliers(context, suppliersXml);
            //ImportParts(context, partsXml);
            //ImportCars(context, carsXml);
            //var result = ImportCustomers(context, customersXml);

            //Query 13. Import Sales
            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //var salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            //ImportSuppliers(context, suppliersXml);
            //ImportParts(context, partsXml);
            //ImportCars(context, carsXml);
            //ImportCustomers(context, customersXml);
            //var result = ImportSales(context, salesXml);

            //Query 14.Cars With Distance
            //var result = GetCarsWithDistance(context);
            //Console.WriteLine(result);

            //Query 15. Cars from make BMW
            //var result = GetCarsFromMakeBmw(context);
            //Console.WriteLine(result);

            //Query 16. Local Suppliers
            //var result = GetLocalSuppliers(context);
            //Console.WriteLine(result);

            //Query 17. Cars with Their List of Parts
            //var result = GetCarsWithTheirListOfParts(context);
            //Console.WriteLine(result);

            //Query 18. Total Sales by Customer
            //var result = GetTotalSalesByCustomer(context);
            //Console.WriteLine(result);

            //Query 19. Sales with Applied Discount
            var result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }
        //Query 19. Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string root = "sales";

            var sales = context.Sales
                .Select(s => new SalesDiscountOutputModel
                {
                    Car = new CarSaleOutputModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(x => x.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(x => x.Part.Price) -
                                        s.Car.PartCars.Sum(x => x.Part.Price) * s.Discount / 100
                })
                .ToList();

            var result = XmlConverter.Serialize(sales, root);

            return result;
        }

        //Query 18. Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string root = "customers";

            var customers = context.Customers
                .Where(x => x.Sales.Count > 0)
                .Select(x => new CustomerSalesOutputModel
                {
                    FullName = x.Name,
                    BoughtCarsCount = x.Sales.Count,
                    SpentMoney = x.Sales
                                  .Select(s => s.Car)
                                                    .SelectMany(c => c.PartCars)
                                                    .Sum(p => p.Part.Price)
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToList();

            var result = XmlConverter.Serialize(customers, root);
            return result;
        }

        //Query 17. Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string root = "cars";

            var cars = context.Cars
                .Select(c => new CarsAndPartsOutputModel
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new PartsOutputModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var result = XmlConverter.Serialize(cars, root);
            return result;
        }

        //Query 16. Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string root = "suppliers";

            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSuppliersOutputModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var result = XmlConverter.Serialize(suppliers, root);

            return result;
        }

        //Query 15. Cars from make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string root = "cars";

            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new BMWOutputModel
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            var result = XmlConverter.Serialize(cars, root);
            return result;
        }

        //Query 14. Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string root = "cars";

            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarOutputModel
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            //1
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarOutputModel[]), new XmlRootAttribute(root));

            //var textWriter = new StringWriter();

            //var nameSpaces = new XmlSerializerNamespaces();
            //nameSpaces.Add("", "");

            //xmlSerializer.Serialize(textWriter, cars, nameSpaces);

            //var result = textWriter.ToString();

            //2
            var result = XmlConverter.Serialize(cars, root);
            return result;
        }

        //Query 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            const string root = "Sales";

            var salesDto = XmlConverter.Deserializer<SalesInputModel>(inputXml, root);

            var carsId = context.Cars.Select(x => x.Id).ToList();

            var sales = salesDto
                .Where(x => carsId.Contains(x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount
                })
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        //Query 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeAutoMapper();
            const string root = "Customers";

            var customersDto = XmlConverter.Deserializer<CustomerInputModel>(inputXml, root);

            //without mapper
            //var customers = customersDto
            //    .Select(x => new Customer
            //    {
            //        Name = x.Name,
            //        BirthDate = x.BirthDate,
            //        IsYoungDriver = x.IsYoungDriver
            //    })
            //    .ToList();

            //with mapper
            var customers = mapper.Map<Customer[]>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            //.Count without mapper
            //.Length with mapper
            return $"Successfully imported {customers.Length}";
        }

        //Query 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string root = "Cars";

            var carsDto = XmlConverter.Deserializer<CarInputModel>(inputXml, root);

            var allParts = context.Parts.Select(x => x.Id).ToList();

            //1
            var cars = carsDto
                .Select(x => new Car
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance,
                    PartCars = x.CarPartsInputModel.Select(x => x.Id)
                                                   .Distinct()
                                                   .Intersect(allParts)
                                                   .Select(pc => new PartCar
                                                   {
                                                       PartId = pc
                                                   })
                                                   .ToList()
                })
                .ToList();

            //2
            //var cars = new List<Car>();


            //foreach (var currentCar in carsDto)
            //{
            //    var distinctedParts = currentCar.CarPartsInputModel.Select(x => x.Id).Distinct();
            //    var parts = distinctedParts.Intersect(allParts);

            //    var car = new Car
            //    {
            //        Make = currentCar.Make,
            //        Model = currentCar.Model,
            //        TravelledDistance = currentCar.TraveledDistance,

            //    };

            //    foreach (var part in parts)
            //    {
            //        var partCar = new PartCar
            //        {
            //            PartId = part
            //        };
            //        car.PartCars.Add(partCar);
            //    }

            //    cars.Add(car);
            //}

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //Query 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string root = "Parts";

            //1
            var partsDto2 = XmlConverter.Deserializer<PartInputModel>(inputXml, root);

            //2
            //var xmlSerializer = new XmlSerializer(typeof(PartInputModel[]), new XmlRootAttribute(root));

            //var textReader = new StringReader(inputXml);

            //var partsDto = xmlSerializer.Deserialize(textReader) as PartInputModel[];

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = partsDto2
                .Where(x => supplierIds.Contains(x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    SupplierId = x.SupplierId
                })
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        //Query 9. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string root = "Suppliers";

            var xmlSerializer = new XmlSerializer(typeof(SupplierInputModel[]), new XmlRootAttribute(root));

            var textRead = new StringReader(inputXml);

            var suppliersDto = xmlSerializer.Deserialize(textRead) as SupplierInputModel[];

            var suppliers = suppliersDto
                .Select(x => new Supplier
                {
                    Name = x.Name,
                    IsImporter = x.IsImporter
                })
                .ToList();

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