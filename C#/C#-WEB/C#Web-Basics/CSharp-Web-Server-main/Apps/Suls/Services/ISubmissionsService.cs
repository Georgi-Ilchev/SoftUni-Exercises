namespace Suls.Services
{
    public interface ISubmissionsService
    {
        public void Create(string problemId, string code, string userId);
    }
}
