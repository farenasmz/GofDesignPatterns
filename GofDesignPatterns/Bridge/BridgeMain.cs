using Bridge.Encryption;
using Bridge.Implementation;

namespace Bridge
{
    public class BridgeMain
    {
        public void Action()
        {
            string message = "myString";
            string password = "123-*/+";
            IMessageEncrypt aes = new DefaultMessageEncryption(new AESEncryption());
            IMessageEncrypt des = new DefaultMessageEncryption(new DESEncryption());
            Console.WriteLine(des.EncryptMessage(message, password));
            Console.WriteLine(aes.EncryptMessage(message, password));
        }
    }
}