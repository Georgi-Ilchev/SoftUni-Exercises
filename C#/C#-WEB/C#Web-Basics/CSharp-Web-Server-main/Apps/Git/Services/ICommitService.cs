namespace Git.Services
{
    using Git.Models.Commits;
    using System.Collections.Generic;
    public interface ICommitService
    {
        public void CreateCommit(string description, string userId, string repositoryId);

        public bool DeleteCommit(string id, string userId);

        IEnumerable<CommitViewModel> GetAllCommits(string userId);
    }
}
