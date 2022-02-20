namespace Decorator.Implementation.Message
{
    public interface IMessage
    {
        IMessage ProcessMessage();
        string GetContent();
        void SetContent(string content);
    }
}
