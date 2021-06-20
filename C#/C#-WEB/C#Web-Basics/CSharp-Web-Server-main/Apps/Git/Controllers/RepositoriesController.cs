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
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(GitDbContext data, IValidator validator, IRepositoryService repositoryService)
        {
            this.data = data;
            this.validator = validator;
            this.repositoryService = repositoryService;
        }

        [Authorize]
        public HttpResponse Create()
        {
            //var repositoryIsPublic = this.data.Repositories
            //                                   .Any(r => r.Id == this.User.Id && r.IsPublic);

            //if (!repositoryIsPublic)
            //{
            //    return Unauthorized();
            //}

            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Create(CreateRepositoryFormModel model)
        {
            var modelErrors = this.validator.ValidateRepository(model);
            var userId = this.User.Id;

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 3 || model.Name.Length > 10)
            {
                return this.Error("Repository name must be between 3 and 10 characters!");
            }

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            repositoryService.CreateRepository(model, userId);

            return Redirect("/Repositories/All");
        }


        [Authorize]
        public HttpResponse All()
        {
            var repositories = this.data.Repositories
                                        .Where(r => r.IsPublic)
                                        .Select(r => new RepositoryViewModel
                                        {
                                            Id = r.Id,
                                            Name = r.Name,
                                            Owner = r.Owner.Username,
                                            CreatedOn = r.CreatedOn.ToString(),
                                            Commits = r.Commits.Count()
                                        })
                                        .ToList();

            return View(repositories);
        }
    }
}
