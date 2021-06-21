namespace Git.Services
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Commits;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CommitService : ICommitService
    {
        private readonly GitDbContext data;

        public CommitService(GitDbContext data)
        {
            this.data = data;
        }

        public void CreateCommit(string description, string userId, string repositoryId)
        {
            var commit = new Commit
            {
                CreatorId = userId,
                RepositoryId = repositoryId,
                CreatedOn = DateTime.UtcNow,
                Description = description
            };
            this.data.Commits.Add(commit);
            this.data.SaveChanges();
        }

        public bool DeleteCommit(string id, string userId)
        {
            var commit = this.data.Commits
                                  .FirstOrDefault(x => x.Id == id);

            if (commit.CreatorId != userId)
            {
                return false;
            }
            this.data.Commits.Remove(commit);
            this.data.SaveChanges();

            return true;
        }

        public IEnumerable<CommitViewModel> GetAllCommits(string userId)
        {
            var commits = this.data.Commits
                                   .Where(c => c.CreatorId == userId)
                                   .Select(c => new CommitViewModel()
                                   {
                                       Id = c.Id,
                                       Repository = c.Repository.Name,
                                       Description = c.Description,
                                       CreatedOn = c.CreatedOn.ToString("g")
                                   })
                                   .ToList();

            return commits;
        }
    }
}
