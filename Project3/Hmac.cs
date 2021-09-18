using System;
using System.Security.Cryptography;
using System.Text;

namespace Project3
{
    class Hmac
    {
        public static byte[] GenerateHMAC(byte[] key, String word)
        {
            HMACSHA256 hmac = new HMACSHA256(key);

            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(word));
            return computedHash;
        }
    }
}
