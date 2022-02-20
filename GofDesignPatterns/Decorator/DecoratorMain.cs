using Decorator.Implementation.Decorators;
using Decorator.Implementation.Message;

namespace Decorator
{
    public class DecoratorMain
    {
        public void Action()
        {
            CustomerMessage customerMessage = new CustomerMessage("Fabian", "farenas@gmail.com", "3193696545");
            Console.WriteLine("Original Message ==> " + customerMessage);

            IMessage message = new EncryptMessage("farenas", "ASD789", new SOAPEnvelopMessage(new XMLFormatterDecorate(customerMessage))).ProcessMessage();

            Console.WriteLine("message1 =====================================>\n"
                       + message.GetContent() + "\n\n");
        }
    }
}