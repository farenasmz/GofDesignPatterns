namespace Bridge.Encryption
{
    public interface IEncryptionAlgorithm
    {
        string Encrypt(string message, string password);
    }
}
