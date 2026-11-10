using Todo.Application.Contracts;

namespace Todo.Application.Implementation;

public class PasswordHasher:IPasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyHashedPassword(string password, string PasswordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
    }
}