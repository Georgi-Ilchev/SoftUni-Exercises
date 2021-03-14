using AutoMapper;
using CarDealer.DTO;
using CarDealer.Models;
using System.Linq;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<SupplierInputModel, Supplier>();
            this.CreateMap<PartsInputModel, Part>();
            this.CreateMap<CarsInputModel, Car>();
            this.CreateMap<CustomersInputModel, Customer>();

            this.CreateMap<Customer, CustomerTotalSalesDTO>()
                .ForMember(x => x.FullName, y => y.MapFrom(s => s.Name))
                .ForMember(x => x.BoughtCars, y => y.MapFrom(s => s.Sales.Count))
                .ForMember(x => x.SpentMoney, y => y.MapFrom(s => s.Sales
                                                                   .Select(c => c.Car
                                                                                 .PartCars
                                                                                 .Select(pc => pc.Part)
                                                                                 .Sum(pc => pc.Price))
                                                                   .Sum()));

            this.CreateMap<Car, CarsDTO>();
        }
    }
}
