using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissors.Library.Generators
{
    public class HashGenerator
    {
        public string GenerateKey()
        {
            var numberGenerator = RandomNumberGenerator.Create();

            byte[] keyBytes = new byte[32];
            numberGenerator.GetBytes(keyBytes);

            string key = BitConverter.ToString(keyBytes).Replace("-", string.Empty);

            return key;
        }

        public string CheckValue(string message, string key)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
                string messageHmac = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                return messageHmac;
            }
        }
    }
}