using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace APITest.Helper
{
    public class Crypto
    {
        private static string GenerateHashString(HashAlgorithm algo, string text)
        {
            // Compute hash from text parameter
            algo.ComputeHash(Encoding.UTF8.GetBytes(text));

            // Get has value in array of bytes
            var result = algo.Hash;

            // Return as hexadecimal string
            return string.Join(
                string.Empty,
                result.Select(x => x.ToString("x2")));
        }

        public string MD5(string text)
        {
            var result = default(string);

            using (var algo = new MD5CryptoServiceProvider())
            {
                result = GenerateHashString(algo, text);
            }

            return result;
        }
        public string SHA1(string text)
        {
            var result = default(string);

            using (var algo = new SHA1Managed())
            {
                result = GenerateHashString(algo, text);
            }

            return result;
        }
    }
}