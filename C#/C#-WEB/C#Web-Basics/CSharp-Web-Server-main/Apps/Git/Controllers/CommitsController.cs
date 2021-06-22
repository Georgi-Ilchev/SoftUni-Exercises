namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Commits;
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    using System.Linq;

    public class CommitsController : Controller
    {
        private readonly GitDbContext data;

        public CommitsController(GitDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var commits = this.data.Commits
                                   .Where(c => c.CreatorId == this.User.Id)
                                   .OrderByDescending(c => c.CreatedOn)
                                   .Select(c => new CommitListingViewModel
                                   {
                                       Id = c.Id,
                                       Description = c.Description,
                                       CreatedOn = c.CreatedOn.ToLocalTime().ToString("F"),
                                       Repository = c.Repository.Name
                                   })
                                   .ToList();

            return View(commits);
        }

        [Authorize]
        public HttpResponse Create(string id)
        {
            var repository = this.data.Repositories
                                    .Where(r => r.Id == id)
                                    .Select(r => new CommitViewModel
                                    {
                                        Id = r.Id,
                                        Name = r.Name
                                    })
                                    .FirstOrDefault();
            if (repository == null)
            {
                return BadRequest();
            }

            return this.View(repository);
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Create(CreateCommitViewModel model)
        {
            if (!this.data.Repositories.Any(r => r.Id == model.Id))
            {
                return NotFound();
            }

            if (model.Description.Length < 5)
            {
                return Error($"Commit description have be at least 5 characters.");
            }

            var commit = new Commit
            {
                Description = model.Description,
                RepositoryId = model.Id,
                CreatorId = this.User.Id
            };
            this.data.Commits.Add(commit);
            this.data.SaveChanges();

            return this.Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Delete(string id)
        {
            var commit = this.data.Commits.Find(id);

            if (commit == null || commit.CreatorId != this.User.Id)
            {
                return BadRequest();
            }

            this.data.Commits.Remove(commit);
            this.data.SaveChanges();

            return this.Redirect("/Commits/All");
        }

    }
}
