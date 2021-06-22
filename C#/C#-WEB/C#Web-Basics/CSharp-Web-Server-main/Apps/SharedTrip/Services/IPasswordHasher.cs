namespace SharedTrip.Services
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
    }
}
