using System.Security.Cryptography;
using System.Text;

namespace Bridge.Encryption
{
    internal class DESEncryption : IEncryptionAlgorithm
    {
        public string Encrypt(string message, string password)
        {
            byte[] inputArray = UTF8Encoding.UTF8.GetBytes(message);
            using TripleDESCryptoServiceProvider tripleDES = new()
            {
                Key = UTF8Encoding.UTF8.GetBytes(password),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            ICryptoTransform cTransform = tripleDES.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
