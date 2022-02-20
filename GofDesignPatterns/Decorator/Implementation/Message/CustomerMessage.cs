namespace Decorator.Implementation.Message
{
    public class CustomerMessage : IMessage
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public CustomerMessage(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public string GetContent()
        {
            return ToString();
        }

        public IMessage ProcessMessage()
        {
            return this;
        }

        public void SetContent(string content)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "CustomerMessage{" + "name=" + Name + ", \nemail=" + Email + ", telephone=" + Phone + '}';
        }
    }
}
