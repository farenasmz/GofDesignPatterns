namespace Builder.Dto
{
    public class Phone
    {
        public string PhoneNumber { get; set; }
        public string Ext { get; set; }
        public string PhoneType { get; set; }

        public Phone()
        {
        }

        public Phone(string phoneNumber, string ext, string phoneType)
        {
            this.PhoneNumber = phoneNumber;
            this.Ext = ext;
            this.PhoneType = phoneType;
        }
    }
}
