namespace Andreys.Services
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
    }
}
