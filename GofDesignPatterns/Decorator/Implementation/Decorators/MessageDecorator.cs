using Decorator.Implementation.Message;

namespace Decorator.Implementation.Decorators
{
    public abstract class MessageDecorator : IMessage
    {
        protected IMessage Message;

        public MessageDecorator(IMessage message)
        {
            Message = message;
        }

        public string GetContent()
        {
            return Message.GetContent();
        }

        public abstract IMessage ProcessMessage();

        public void SetContent(string content)
        {
            Message.SetContent(content);
        }
    }
}
