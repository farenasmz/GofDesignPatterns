namespace Facade.Implementation
{
    public class GeneralPaymentException : Exception
    {
        public GeneralPaymentException(string error) : base(error)
        {

        }
    }
}
