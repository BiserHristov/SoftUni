namespace ChangeMe.Services
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
    }
}
