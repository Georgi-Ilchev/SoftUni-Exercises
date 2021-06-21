namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Repositories;
    using Git.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class RepositoriesController : Controller
    {
        private readonly GitDbContext data;
        private readonly IValidator validator;

        public RepositoriesController(GitDbContext data, IValidator validator)
        {
            this.data = data;
            this.validator = validator;
        }

        [Authorize]
        public HttpResponse Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateRepositoryFormModel model)
        {
            var modelErrors = this.validator.ValidateRepository(model);

            //if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            //{
            //    return this.Error("Repository name must be between 3 and 10 characters!");
            //}

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var repository = new Repository
            {
                Name = model.Name,
                IsPublic = model.RepositoryType == "Public",
                OwnerId = this.User.Id
            };

            this.data.Repositories.Add(repository);
            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }


        [Authorize]
        public HttpResponse All()
        {
            //1
            //var repositories = this.data.Repositories
            //                            .Where(r => r.IsPublic)
            //                            .Select(r => new RepositoryViewModel
            //                            {
            //                                Id = r.Id,
            //                                Name = r.Name,
            //                                Owner = r.Owner.Username,
            //                                CreatedOn = r.CreatedOn.ToLocalTime().ToString("F"),
            //                                Commits = r.Commits.Count()
            //                            })
            //                            .ToList();

            //return View(repositories);

            //2
            var repositoriesQuery = this.data
               .Repositories
               .AsQueryable();

            if (this.User.IsAuthenticated)
            {
                repositoriesQuery = repositoriesQuery
                    .Where(r => r.IsPublic || r.OwnerId == this.User.Id);
            }
            else
            {
                repositoriesQuery = repositoriesQuery
                    .Where(r => r.IsPublic);
            }

            var repositores = repositoriesQuery
                .OrderByDescending(r => r.CreatedOn)
                .Select(r => new RepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToLocalTime().ToString("F"),
                    Commits = r.Commits.Count()
                })
                .ToList();

            return View(repositores);
        }
    }
}
