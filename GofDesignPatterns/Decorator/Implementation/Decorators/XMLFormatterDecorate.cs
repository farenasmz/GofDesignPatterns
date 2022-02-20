using Decorator.Implementation.Message;
using System.Xml.Serialization;

namespace Decorator.Implementation.Decorators
{
    internal class XMLFormatterDecorate : MessageDecorator
    {
        public XMLFormatterDecorate(IMessage message) : base(message)
        {
        }

        public override IMessage ProcessMessage()
        {
            Message = Message.ProcessMessage();
            Message = XmlMessage();
            return Message;
        }

        private IMessage XmlMessage()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(Message.GetType());

                using (StringWriter textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, Message);
                    return new TextMessage(textWriter.ToString());
                }

                throw new SystemException();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw new SystemException("XML error converting");
            }
        }
    }
}
