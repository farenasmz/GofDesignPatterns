namespace Bridge.Implementation
{
    public interface IMessageEncrypt
    {
        string EncryptMessage(string message, string password);
    }
}
