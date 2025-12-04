using System.Security.Cryptography;

namespace Athr.Application.Abstractions.Behaviors
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;                     // 128-bit salt
        private const int KeySize = 32;                     // 256-bit hash
        private const int Iterations = 100_000;                // your fixed iteration count
        private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

        /// <summary>
        /// Returns "{hashHex}${saltHex}"
        /// </summary>
        public static string HashPassword(string password)
        {
            var salt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                Iterations,
                HashAlgorithm,
                KeySize
            );

            return $"{Convert.ToHexString(hash)}${Convert.ToHexString(salt)}";
        }
        /// <summary>
        /// Verifies the password against "{hashHex}${saltHex}".
        /// Throws if the stored format is invalid or truncated.
        /// </summary>
        public static bool VerifyHashedPassword(string password, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(storedHash))
                throw new ArgumentException("Stored password hash is empty.");

            // Split into exactly 2 parts
            var parts = storedHash.Split('$');
            if (parts.Length != 2)
                return false;

            var hashHex = parts[0];
            var saltHex = parts[1];

            // Validate lengths
            if (hashHex.Length != KeySize * 2)
                return false;

            // Convert back to bytes
            var storedHashBytes = Convert.FromHexString(hashHex);
            var saltBytes = Convert.FromHexString(saltHex);

            // Derive new hash
            var newHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                saltBytes,
                Iterations,
                HashAlgorithmName.SHA256,
                KeySize
            );

            // Constant-time compare
            return CryptographicOperations.FixedTimeEquals(newHash, storedHashBytes);
        }
    }

}
