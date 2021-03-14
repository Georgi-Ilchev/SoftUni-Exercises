using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
            var context = new CarDealerContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            //Query 8.Import Suppliers
            //var supplierJson = File.ReadAllText("../../../Datasets/suppliers.json");
            //var result = ImportSuppliers(context, supplierJson);

            //Query 9. Import Parts
            //var partsJson = File.ReadAllText("../../../Datasets/parts.json");
            //var result = ImportParts(context, partsJson);

            //Query 10. Import Cars
            //var carJson = File.ReadAllText("../../../Datasets/cars.json");
            //var result = ImportCars(context, carJson);

            //Query 11. Import Customers
            //var customerJson = File.ReadAllText("../../../Datasets/customers.json");
            //var result = ImportCustomers(context, customerJson);

            //Query 12. Import Sales
            //var salesJson = File.ReadAllText("../../../Datasets/sales.json");
            //var result = ImportSales(context, salesJson);

            //Query 13. Export Ordered Customers
            //var result = GetOrderedCustomers(context);

            //Export Cars from Make Toyota
            //var result = GetCarsFromMakeToyota(context);

            //Query 14. Export Local Suppliers
            //var result = GetLocalSuppliers(context);

            //Query 15. Export Cars with Their List of Parts
            //var result = GetCarsWithTheirListOfParts(context);

            //Query 16. Export Total Sales by Customer
            //InitializeMapper();
            //string result = GetTotalSalesByCustomer(context);

            //Query 17. Export Sales with Applied Discount
            InitializeMapper();
            string result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);
        }

        //Query 17. Export Sales with Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                    .Select(s => new CustomerSaleDTO()
                    {
                        Car = new SaleCarDTO()
                        {
                            Make = s.Car.Make,
                            Model = s.Car.Model,
                            TravelledDistance = s.Car.TravelledDistance
                        },
                        CustomerName = s.Customer.Name,
                        Discount = s.Discount.ToString("f2"),
                        Price = s.Car.PartCars.Sum(pc => pc.Part.Price).ToString("f2"),
                        PriceWithDiscount = (s.Car.PartCars.Sum(pc => pc.Part.Price) -
                                             s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100).ToString("f2")

                    })
                    .Take(10)
                    .ToList();

            var result = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return result;
        }

        //Query 16. Export Total Sales by Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .ProjectTo<CustomerTotalSalesDTO>()
                .Where(c => c.BoughtCars >= 1)
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return result;
        }

        //Query 15. Export Cars with Their List of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance,
                    },
                    parts = c.PartCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price.ToString("f2"),
                    })
                    .ToList()
                })
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return result;
        }

        //Query 14. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var result = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return result;
        }

        //Export Cars from Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToList();

            var result = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return result;
        }

        //Query 13. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver,
                })
                .ToList();

            var result = JsonConvert.SerializeObject(customers, Formatting.Indented);
            return result;
        }

        //Query 12. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var sales = JsonConvert.DeserializeObject<IEnumerable<Sale>>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        //Query 11. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var customersDto = JsonConvert.DeserializeObject<IEnumerable<CustomersInputModel>>(inputJson);

            var customers = mapper.Map<IEnumerable<Customer>>(customersDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        //Query 10. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            InitializeMapper();
            List<Car> cars = new List<Car>();

            var carDtos = JsonConvert.DeserializeObject<IEnumerable<CarsInputModel>>(inputJson);

            foreach (var carDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                foreach (var partId in carDto.PartsId.Distinct())
                {
                    car.PartCars.Add(new PartCar()
                    {
                        Car = car,
                        PartId = partId
                    });
                }
                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        //Query 9. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            //var parts = JsonConvert.DeserializeObject<IEnumerable<PartsInputModel>>(inputJson);
            List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);
            var suppliers = context.Suppliers.Select(x => x.Id);

            parts = parts.Where(p => suppliers.Any(s => s == p.SupplierId)).ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}.";
        }

        //Query 8. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var dtoSuppliers = JsonConvert.DeserializeObject<IEnumerable<SupplierInputModel>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(dtoSuppliers);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }


        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}