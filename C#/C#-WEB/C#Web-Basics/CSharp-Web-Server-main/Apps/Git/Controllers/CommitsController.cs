namespace Git.Controllers
{
    using Git.Models.Commits;
    using Git.Services;
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    public class CommitsController : Controller
    {
        private readonly ICommitService commitService;

        public CommitsController(ICommitService commitService)
        {
            this.commitService = commitService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var model = this.commitService.GetAll();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(string description, string id, string repoId)
        {
            if (string.IsNullOrWhiteSpace(description) || description.Length < 5)
            {
                return this.Error("Invalid commit!");
            }

            var userId = this.User.Id;
            this.commitService.CreateCommit(description, id, userId, repoId);
            return this.Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repoName = this.commitService.GetById(id);

            var model = new CreateCommitViewModel
            {
                Id = id,
                Name = repoName
            };
            return this.View(model);
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var userId = this.User.Id;
            //if (userId != id)
            //{
            //    return this.Error("You dont have access to remove this repository!");
            //}
            this.commitService.RemoveCommit(userId);
            return this.Redirect("/Commits/All");
        }

    }
}
