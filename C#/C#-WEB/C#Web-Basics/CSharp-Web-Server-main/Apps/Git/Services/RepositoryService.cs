namespace Git.Services
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class RepositoryService : IRepositoryService
    {
        private readonly GitDbContext data;

        public RepositoryService(GitDbContext data)
        {
            this.data = data;
        }

        public void CreateRepository(CreateRepositoryFormModel registration, string userId)
        {
            var isPublic = IsPublic(registration.RepositoryType);
            var repository = new Repository
            {
                Name = registration.Name,
                IsPublic = isPublic,
                CreatedOn = DateTime.UtcNow,
                OwnerId = userId,
            };
            this.data.Repositories.Add(repository);
            this.data.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAllRepository()
            => this.data.Repositories.Select(x => new RepositoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CreatedOn = x.CreatedOn.ToString("g"),
                Owner = x.Owner.Username,
                Commits = x.Commits.Count()
            })
            .ToList();

        public bool IsPublic(string repositoryType)
        {
            if (repositoryType == "Private")
            {
                return false;
            }

            return true;
        }
    }
}
