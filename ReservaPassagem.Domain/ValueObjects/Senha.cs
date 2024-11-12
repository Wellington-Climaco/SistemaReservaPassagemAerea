using System.Security.Cryptography;

namespace ReservaPassagem.Domain.ValueObjects;

public class Senha
{
    public Senha(string password)
    {
        Hash = HashPassword(password);
    }

    protected Senha()
    {
        
    }
    public string Hash { get; set; }
    
    private string HashPassword(string password,short saltSize = 16,
        short keySize = 32,int iterations = 10000,char splitChar = '.')
    {
        if (string.IsNullOrEmpty(password))
            throw new Exception("Senha não pode ser vázia");

        password += "Cm20]N5?4pb9%R+k8[L";


        using var algorithm = new Rfc2898DeriveBytes(
            password,
            saltSize,
            iterations,
            HashAlgorithmName.SHA256);
        var key = Convert.ToBase64String(algorithm.GetBytes(keySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return $"{iterations}{splitChar}{salt}{splitChar}{key}";
    }

    public bool VerifyPassword(string hash, string password,short keySize = 32,
        int iterations = 10000, char splitChar = '.')
    {   
        password += "Cm20]N5?4pb9%R+k8[L";

        var parts = hash.Split(splitChar, 3);
        if (parts.Length != 3)
            return false;

        var hashIterations = Convert.ToInt32(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        if (hashIterations != iterations)
            return false;

        using var algorithm = new Rfc2898DeriveBytes(
            password,
            salt,
            iterations,
            HashAlgorithmName.SHA256);
        var keyToCheck = algorithm.GetBytes(keySize);

        return keyToCheck.SequenceEqual(key);
    }
}