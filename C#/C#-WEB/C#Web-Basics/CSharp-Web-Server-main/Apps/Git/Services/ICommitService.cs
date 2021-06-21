namespace Git.Services
{
    using Git.Models.Commits;
    using System.Collections.Generic;
    public interface ICommitService
    {
        public string CreateCommit(string description, string id, string userId, string repoId);

        public void RemoveCommit(string userId);

        string GetById(string id);

        IEnumerable<CommitViewModel> GetAll();
    }
}
