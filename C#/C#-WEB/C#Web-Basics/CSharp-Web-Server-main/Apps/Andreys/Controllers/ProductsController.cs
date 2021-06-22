using Andreys.Data;
using Andreys.Data.Enums;
using Andreys.Data.Models;
using Andreys.Models.Products;
using Andreys.Services;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AndreysDbContext data;
        private readonly IValidator validator;

        public ProductsController(AndreysDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddProductFormModel model)
        {
            var modelErrors = this.validator.ValidateProduct(model);

            if (modelErrors.Any())
            {
                //return Error(modelErrors);
                return Redirect("/Products/Add");
            }

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Category = Enum.Parse<Category>(model.Category),
                Gender = Enum.Parse<Gender>(model.Gender)

            };
            this.data.Products.Add(product);
            this.data.SaveChanges();

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Details(int id)
        {
            if (!IsProductExisting(id))
            {
                return this.Error("Product is not existing.");
            }

            var viewModel = this.data.Products
                                   .Where(p => p.Id == id)
                                   .Select(p => new DisplayProductDetailViewModel
                                   {
                                       Id = p.Id,
                                       Name = p.Name,
                                       Gender = p.Gender,
                                       Category = p.Category,
                                       Description = p.Description,
                                       ImageUrl = p.ImageUrl,
                                       Price = p.Price
                                   })
                                   .FirstOrDefault();

            return this.View(viewModel);
        }

        [Authorize]
        public HttpResponse Delete(int id)
        {
            if (!IsProductExisting(id))
            {
                return this.Error("Product is not existing.");
            }

            var product = this.data.Products
                                   .FirstOrDefault(p => p.Id == id);

            this.data.Remove(product);
            this.data.SaveChanges();

            return Redirect("/");
        }

        public bool IsProductExisting(int id)
        => this.data.Products.Any(p => p.Id == id);
    }
}
