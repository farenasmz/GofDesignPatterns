namespace Decorator.Implementation.Message
{
    internal class TextMessage : IMessage
    {
        private string Content;

        public TextMessage(string content)
        {
            Content = content;
        }

        public string GetContent()
        {
            return Content;
        }

        public IMessage ProcessMessage()
        {
            return this;
        }

        public void SetContent(string content)
        {
            Content = content;
        }
    }
}
