namespace Git.Controllers
{
    using Git.Models.Commits;
    using Git.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;
        private readonly IRepositoryService repositoryService;

        public CommitsController(ICommitService commitService, IRepositoryService repositoryService)
        {
            this.commitService = commitService;
            this.repositoryService = repositoryService;
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repositoryName = this.repositoryService.GetRepositoryName(id);

            var model = new CreateCommitViewModel
            {
                Id = id,
                Name = repositoryName
            };

            return this.View(model);
        }

        [Authorize]
        public HttpResponse All()
        {
            string userId = this.GetUserId();
            var model = this.commitService.GetAllCommits(userId);
            return View(model);
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var userId = this.User.Id;
            if (!this.commitService.DeleteCommit(id, userId))
            {
                return this.Error("You dont have access to remove this repository!");
            }

            //this.commitService.DeleteCommit(userId);
            return Redirect("/Commits/All");

        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(string description, string id, string repoId)
        {
            if (string.IsNullOrWhiteSpace(description) || description.Length < 5)
            {
                return this.Error($"Description must have at least 5 characters");
            }
            //GetUserId
            var userId = this.User.Id;
            this.commitService.CreateCommit(description, id, userId);

            return Redirect("/Repositories/All");
        }

    }
}
