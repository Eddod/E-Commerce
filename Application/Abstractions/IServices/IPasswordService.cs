namespace Application.Abstractions.Services;

public interface IPasswordService
{
    public string HashPassword(string password);
    public bool VerifyPassword(string password, string hashedPassword);
    public byte[] GenerateSalt();
    public byte[] HashPassword(string password, byte[] salt);
    public bool SlowEquals(byte[]a, byte[]b);

}
