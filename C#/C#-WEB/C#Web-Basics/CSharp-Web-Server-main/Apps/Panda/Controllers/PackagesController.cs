﻿using MyWebServer.Controllers;
using MyWebServer.Http;
using Panda.Data;
using Panda.Data.Enums;
using Panda.Data.Models;
using Panda.Services;
using Panda.ViewModels.Package;
using Panda.ViewModels.User;
using System;
using System.Linq;

namespace Panda.Controllers
{
    public class PackagesController : Controller
    {
        private readonly PandaDbContext data;
        private readonly IValidator validator;
        private readonly IReceiptsService receiptsService;

        public PackagesController(PandaDbContext data, IValidator validator, IReceiptsService receiptsService)
        {
            this.data = data;
            this.validator = validator;
            this.receiptsService = receiptsService;
        }

        [Authorize]
        public HttpResponse Create()
        {
            var viewModel = this.data.Users
                                      .Select(u => new GetAllUsersViewModel()
                                      {
                                          Username = u.Username
                                      })
                                      .ToList();

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreatePackageInputModel model, string recipient)
        {
            //TODO

            var modelErrors = this.validator.ValidatePackage(model);

            if (modelErrors.Any())
            {
                //return Error(modelErrors);
                return this.Redirect("/Packages/Create");
            }

            var recipientId = this.data
                .Users
                .FirstOrDefault(r => r.Username == model.RecipientName)
                ?.Id;

            var package = new Package()
            {
                Description = model.Description,
                Weight = model.Weight,
                Status = PackageStatus.Pending,
                ShippingAddress = model.ShippingAddress,
                EstimatedDeliveryDate = DateTime.UtcNow,
                RecipientId = recipientId
            };


            this.data.Packages.Add(package);
            this.data.SaveChanges();

            return Redirect("/");
        }

        [Authorize]
        public HttpResponse Pending()
        {
            var viewModel = this.data.Packages
                                      .Where(p => p.Status == PackageStatus.Pending)
                                      .Select(p => new PackageViewModel()
                                      {
                                          Id = p.Id,
                                          Description = p.Description,
                                          Weight = p.Weight,
                                          ShippingAddress = p.ShippingAddress,
                                          RecipientName = p.Recipient.Username
                                      })
                                      .ToList();

            return this.View(viewModel);
        }

        [Authorize]
        public HttpResponse Delivered()
        {
            var viewModel = this.data.Packages
                                      .Where(p => p.Status == PackageStatus.Delivered)
                                      .Select(p => new PackageViewModel()
                                      {
                                          Id = p.Id,
                                          Description = p.Description,
                                          Weight = p.Weight,
                                          ShippingAddress = p.ShippingAddress,
                                          RecipientName = p.Recipient.Username
                                      })
                                      .ToList();

            return this.View(viewModel);
        }

        [Authorize]
        public HttpResponse Deliver(string id)
        {
            var package = this.data.Packages
                                     .FirstOrDefault(p => p.Id == id);

            package.Status = PackageStatus.Delivered;

            this.receiptsService.Create(package.Id, package.RecipientId);

            this.data.SaveChanges();

            return Redirect("Packages/Pending");
        }
    }
}
