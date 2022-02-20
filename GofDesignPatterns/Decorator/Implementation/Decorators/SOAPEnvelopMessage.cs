﻿using Decorator.Implementation.Message;

namespace Decorator.Implementation.Decorators
{
    internal class SOAPEnvelopMessage : MessageDecorator
    {
        public SOAPEnvelopMessage(IMessage message) : base(message)
        {
        }

        public override IMessage ProcessMessage()
        {
            Message.ProcessMessage();
            Message = EnvelopMessage();
            return Message;
        }

        private IMessage EnvelopMessage()
        {
            string soap = "<soapenv:Envelope xmlns:soapenv="
                    + "\n\"http://schemas.xmlsoap.org/soap/envelope/\" "
                    + "\nxmlns:ser=\"http://service.dishweb.cl.com/\">\n"
                    + "   <soapenv:Header/>\n"
                    + "   <soapenv:Body>\n"
                    + Message.GetContent()
                    + "\n"
                    + "   </soapenv:Body>\n"
                    + "</soapenv:Envelope>";
            Message.SetContent(soap);
            return Message;
        }
    }
}
