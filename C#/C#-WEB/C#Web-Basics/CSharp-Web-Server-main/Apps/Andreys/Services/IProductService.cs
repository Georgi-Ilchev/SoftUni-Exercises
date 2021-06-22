using Andreys.Models.Products;
using System.Collections.Generic;

namespace Andreys.Services
{
    public interface IProductService
    {
        IEnumerable<DisplayAllProductsViewModel> DisplayAll();
    }
}
