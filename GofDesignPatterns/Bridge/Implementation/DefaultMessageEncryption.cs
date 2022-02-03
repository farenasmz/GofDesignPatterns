using Bridge.Encryption;

namespace Bridge.Implementation
{
    public class DefaultMessageEncryption : IMessageEncrypt
    {
        IEncryptionAlgorithm EncryptionAlgorithm;

        public DefaultMessageEncryption(IEncryptionAlgorithm encryptionAlgorithm)
        {
            EncryptionAlgorithm = encryptionAlgorithm;
        }

        public string EncryptMessage(string message, string password)
        {
            return EncryptionAlgorithm.Encrypt(message, password);
        }
    }
}
