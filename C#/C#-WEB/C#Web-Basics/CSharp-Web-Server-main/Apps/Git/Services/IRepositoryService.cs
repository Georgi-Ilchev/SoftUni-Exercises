using Git.Models.Repositories;
namespace Git.Services
{
    using System.Collections.Generic;
    public interface IRepositoryService
    {
        void CreateRepository(CreateRepositoryFormModel registration, string userId);

        IEnumerable<RepositoryViewModel> GetAllRepository();

        public bool IsPublic(string repositoryType);

        string GetRepositoryName(string id);
    }
}
