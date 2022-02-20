namespace Facade.Util
{
    public class Card
    {
        public string Prefix { get; set; }
        public string Company { get; set; }
        public string CardType { get; set; }//{Credit|Debit}

        public Card(string prefix, string company, string cardType)
        {
            this.Prefix = prefix;
            this.Company = company;
            this.CardType = cardType;
        }
    }
}
