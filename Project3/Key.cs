using System.Security.Cryptography;

namespace Project3
{
    class Key
    {
        public static byte[] GenerateKey()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            var key = new byte[16];
            rng.GetBytes(key);
            return key;
        }
    }
}
