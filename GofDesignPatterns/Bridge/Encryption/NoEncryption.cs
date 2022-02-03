namespace Bridge.Encryption
{
    internal class NoEncryption : IEncryptionAlgorithm
    {
        public string Encrypt(string message, string password)
        {
            return message;
        }
    }
}
