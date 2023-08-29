using Application.Abstractions.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Persistance.Service;

internal class PasswordService : IPasswordService
{

    private const int SaltSize = 128 / 8; // 128 bits = 16 bytes
    private const int HashSize = 256 / 8; // 256 bits = 32 bytes
    private const int Iterations = 100000;

    public string HashPassword(string password)
    {
        byte[] salt = GenerateSalt();
        byte[] hash = HashPassword(password, salt);

        string saltBase64 = Convert.ToBase64String(salt);
        string hashBase64 = Convert.ToBase64String(hash);

        return $"{saltBase64}:{hashBase64}";
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        string[] parts = hashedPassword.Split(':');
        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] hash = Convert.FromBase64String(parts[1]);

        byte[] newHash = HashPassword(password, salt);
        return SlowEquals(hash, newHash);
    }

    public byte[] GenerateSalt()
    {
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
            return salt;
        }
    }

    public byte[] HashPassword(string password, byte[] salt)
    {
        return KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: Iterations,
            numBytesRequested: HashSize);
    }

    public bool SlowEquals(byte[] a, byte[] b)
    {
        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
        {
            diff |= (uint)(a[i] ^ b[i]);
        }
        return diff == 0;
    }
}
