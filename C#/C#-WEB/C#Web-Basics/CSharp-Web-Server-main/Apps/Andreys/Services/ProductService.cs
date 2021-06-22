using Andreys.Data;
using Andreys.Models.Products;
using System.Collections.Generic;
using System.Linq;

namespace Andreys.Services
{
    public class ProductService : IProductService
    {
        private readonly AndreysDbContext data;

        public ProductService(AndreysDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<DisplayAllProductsViewModel> DisplayAll()
        {
            var allProducts = this.data
                .Products
                .Select(p => new DisplayAllProductsViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price
                })
                .ToList();

            return allProducts;
        }
    }
}
